using System;
using System.Windows.Forms;
using CslaGenerator.Metadata;
using System.IO;
using System.Text;
using CodeSmith.Engine;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace CslaGenerator.Templates
{
    /// <summary>
    /// Descripción breve de Generate.
    /// </summary>
    public class CodeGenerator : CodeGeneratorBase, ICodeGenerator
    {
        public CodeGenerator(string targetDirectory, string templatesDirectory)
        {
            _targetDirectory = targetDirectory;
            _templatesDirectory = templatesDirectory;
        }

        string _fullTemplatesPath;
        string _targetDirectory = string.Empty;
        private readonly string _templatesDirectory = string.Empty;
        bool _abortRequested = false;
        int objSuccess = 0;
        int objFailed = 0;
        private int objectWarnings = 0;
        int sprocSuccess = 0;
        int sprocFailed = 0;
        private Hashtable templates = new Hashtable();
        private readonly GenerationReportCollection _errorReport = new GenerationReportCollection();
        private readonly GenerationReportCollection _warningReport = new GenerationReportCollection();

        public string TargetDirectory
        {
            get
            {
                return _targetDirectory;
            }
            set
            {
                _targetDirectory = value;
            }
        }

        public GenerationReportCollection ErrorReport
        {
            get { return _errorReport; }
        }

        public GenerationReportCollection WarningReport
        {
            get { return _warningReport; }
        }

        public void Abort()
        {
            _abortRequested=true;
        }
        public event GenerationInformationDelegate GenerationInformation;
        public event GenerationInformationDelegate Step;
        public event EventHandler Finalized;

        void OnGenerationFileName(string e)
        {
            if (GenerationInformation != null)
                GenerationInformation(e);
            Controls.OutputWindow.Current.AddOutputInfo("\tFile: " + e);
        }
        void OnGenerationInformation(string e, int lineBreaks)
        {
            if (GenerationInformation != null)
                GenerationInformation(e);
            Controls.OutputWindow.Current.AddOutputInfo(e, lineBreaks);
        }
        void OnStep(string objectName)
        {
            if (Step != null)
                Step(objectName);
            Controls.OutputWindow.Current.AddOutputInfo(String.Format("{0}:", objectName));
        }
        void OnFinalized()
        {
            if (Finalized != null)
                Finalized(this,new EventArgs());
            Controls.OutputWindow.Current.AddOutputInfo("Done");
            if (objectWarnings > 0)
                Controls.OutputWindow.Current.AddOutputInfo(String.Format("Warnings: {0} objects.", objectWarnings));

            Controls.OutputWindow.Current.AddOutputInfo(String.Format("Classes: {0} generated. {1} failed.", (objFailed + objSuccess).ToString(), objFailed.ToString()));
            Controls.OutputWindow.Current.AddOutputInfo(String.Format("Stored Procs: {0} generated. {1} failed.", (sprocFailed + sprocSuccess).ToString(), sprocFailed.ToString()));
        }

        private void GenerateObject(CslaObjectInfo objInfo, CslaGeneratorUnit unit)
        {
            Metadata.GenerationParameters generationParams = unit.GenerationParams;
            string fileName = GetFileName(objInfo, generationParams.SeparateNamespaces, generationParams.OutputLanguage);
            string baseFileName = GetBaseFileName(objInfo, generationParams.SeparateBaseClasses, generationParams.SeparateNamespaces, generationParams.UseDotDesignerFileNameConvention, generationParams.OutputLanguage);
            try
            {
                GenerateInheritanceFile(fileName, objInfo, generationParams.ActiveObjects, unit);
                string tPath = this._fullTemplatesPath + generationParams.OutputLanguage.ToString() + @"\" + GetTemplateName(objInfo);
                CodeTemplate template = GetTemplate(objInfo, tPath);
                if (template != null)
                {
                    StringBuilder errorsOutput = new StringBuilder();
                    StringBuilder warningsOutput = new StringBuilder();
                    template.SetProperty("ActiveObjects", generationParams.ActiveObjects);
                    template.SetProperty("Errors", errorsOutput);
                    template.SetProperty("Warnings", warningsOutput);
                    template.SetProperty("CurrentUnit", unit);
                    template.SetProperty("DataSetLoadingScheme", objInfo.DataSetLoadingScheme);
                    if (generationParams.BackupOldSource && File.Exists(baseFileName))
                    {
                        FileInfo oldFile = new FileInfo(baseFileName);
                        if (File.Exists(baseFileName + ".old"))
                        {
                            File.Delete(baseFileName + ".old");
                        }
                        oldFile.MoveTo(baseFileName + ".old");
                    }
                    FileInfo fi = new FileInfo(baseFileName);
                    using (FileStream fs = fi.Open(FileMode.Create))
                    {
                        OnGenerationFileName(fi.FullName);
                        using (StreamWriter swBase = new StreamWriter(fs))
                        {

                            template.Render(swBase);
                            errorsOutput = (StringBuilder)template.GetProperty("Errors");
                            warningsOutput = (StringBuilder)template.GetProperty("Warnings");
                            if (errorsOutput.Length > 0)
                            {
                                objFailed++;
                                OnGenerationInformation("Failed:" + Environment.NewLine +
                                            errorsOutput.ToString(), 2);
                            }
                            else
                            {
                                if (warningsOutput != null)
                                {
                                    if (warningsOutput.Length > 0)
                                    {
                                        objectWarnings++;
                                        OnGenerationInformation("Warning:" + Environment.NewLine + warningsOutput, 2);
                                    }
                                }
                                objSuccess++;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                objFailed++;
                ShowExceptionInformation(e);
            }
        }

        void GenerateInheritanceFile(string fileName, CslaObjectInfo objInfo, bool activeObjects, CslaGeneratorUnit unit)
        {
            // Create Inheritance file if it does not exist
            if (!File.Exists(fileName)) //&& objInfo.ObjectType != CslaObjectType.NameValueList)
            {

                string tPath = this._fullTemplatesPath + unit.GenerationParams.OutputLanguage.ToString() + "\\InheritFromBase.cst";
                CodeTemplate template = GetTemplate(objInfo, tPath);
                if (template != null)
                {

                    template.SetProperty("ActiveObjects", activeObjects);
                    template.SetProperty("CurrentUnit", unit);
                    FileInfo fi = new FileInfo(fileName);
                    using (FileStream fs = fi.Open(FileMode.Create))
                    {
                        OnGenerationFileName(fi.FullName);
                        using (StreamWriter sw = new StreamWriter(fs))
                        {
                            try
                            {
                                template.Render(sw);
                            }
                            catch (Exception e)
                            {
                                ShowExceptionInformation(e);
                            }
                        }
                    }
                }
            }
        }

        CodeTemplate GetTemplate(CslaObjectInfo objInfo, string templatePath)
        {
            CodeTemplateCompiler compiler;

            if (!templates.ContainsKey(templatePath))
            {
                if (!File.Exists(templatePath))
                    throw new ApplicationException("The specified template could not be found: " + templatePath);
                
                compiler = new CodeTemplateCompiler(templatePath);
                compiler.Compile();
                templates.Add(templatePath,compiler);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < compiler.Errors.Count; i++)
                {
                    sb.Append(compiler.Errors[i].ToString());
                    sb.Append(Environment.NewLine);
                }
                if (compiler.Errors.Count>0)
                    throw new Exception(String.Format(
                        "Template {0} failed to compile. Objects of the same type will be ignored.", 
                        templatePath) + Environment.NewLine + sb.ToString());
            }
            else
            {
                compiler = (CodeTemplateCompiler)templates[templatePath];
            }
            if (compiler.Errors.Count > 0)
                return null;

            CodeTemplate template = compiler.CreateInstance();
            template.SetProperty("Info",objInfo);
            return template;

        }

        void ShowExceptionInformation(Exception e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("An error occurred while generating object:");
            sb.Append(Environment.NewLine);
            sb.Append(e.Message);
            sb.Append(Environment.NewLine);
            sb.Append(Environment.NewLine);
            sb.Append("Stack Trace:");
            sb.Append(Environment.NewLine);
            sb.Append(e.StackTrace);
            OnGenerationInformation(sb.ToString(), 2);
        }

        private void WriteToFile(FileInfo file, string data)
        {
            CheckDirectory(file.Directory.FullName);
            OnGenerationFileName(file.FullName);
            StreamWriter sw = null;
            try
            {
                FileInfo fi = new FileInfo(file.FullName);
                using (FileStream fs = fi.Open(FileMode.Create))
                {
                    using (sw = new StreamWriter(fs))
                    {
                        sw.Write(data);
                    }
                }
            }
            catch (Exception e)
            {
                string errorDesc = String.Format("Error writing to file {0}: {1}",
                        file.FullName, e.Message);

                OnGenerationInformation(errorDesc, 2);
            }
        }


        private bool TargetDeprecated(CslaGeneratorUnit unit)
        {
            var result = true;
            if (unit.GenerationParams.TargetFramework == TargetFramework.CSLA10)
            {
                var alert = MessageBox.Show(unit.ProjectName +
                    @" targets CSLA 1.0 that isn't supported any longer; code generation will crash.",
                    @"CslaGenFork project generation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (alert == DialogResult.Cancel)
                    result = false;
            }

            return result;
        }

        public void GenerateProject(CslaGeneratorUnit unit)
        {
            if (!TargetDeprecated(unit))
            {
                OnGenerationInformation(@"Project generation cancelled." + Environment.NewLine, 1);
                return;
            }

            objFailed = 0;
            objSuccess = 0;
            sprocFailed = 0;
            sprocSuccess = 0;
            Controls.OutputWindow.Current.ClearOutput();
            Controls.OutputWindow.Current.AddOutputInfo(string.Format("Generating code in '{0}'", _targetDirectory));
            Metadata.GenerationParameters generationParams = unit.GenerationParams;
            _abortRequested = false;
            _fullTemplatesPath = _templatesDirectory + generationParams.TargetFramework + @"\";
            templates = new Hashtable();//to recompile templates in case they changed.
            //This is just in case users add/remove objects while generating...
            List<CslaObjectInfo> list = new List<CslaObjectInfo>();
            for (int i = 0; i < unit.CslaObjects.Count; i++)
            {
                if (unit.CslaObjects[i].Generate)
                    list.Add(unit.CslaObjects[i]);
            }
            foreach (CslaObjectInfo info in list)
            {
                if (info.Generate)
                {
                    if (_abortRequested) break;
                    OnStep(info.ObjectName);
                    try
                    {
                        GenerateObject(info, unit);
                    }
                    catch (Exception ex)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendFormat("Object {0} failed to generate:", info.ObjectName);
                        sb.AppendLine();
                        sb.Append("\t");
                        sb.Append(ex.Message);
                        OnGenerationInformation(sb.ToString(), 2);
                    }
                    if (_abortRequested) break;

                    if (generationParams.GenerateSprocs && info.GenerateSprocs)
                    {
                        try
                        {

                            if (generationParams.OneSpFilePerObject)
                            {
                                GenerateAllSprocsFile(info, GetSprocFileInfo(info.ObjectName));
                            }
                            else
                            {
                                

                                GenerateSelectProcedure(info);
                                if (_abortRequested) break;

                                if (info.ObjectType != CslaObjectType.ReadOnlyObject
                                    && info.ObjectType != CslaObjectType.ReadOnlyCollection
                                    && info.ObjectType != CslaObjectType.EditableRootCollection
                                    && info.ObjectType != CslaObjectType.EditableChildCollection
                                    && info.ObjectType != CslaObjectType.NameValueList)
                                {
                                    GenerateInsertProcedure(info, _targetDirectory);
                                    if (_abortRequested) break;

                                    GenerateDeleteProcedure(info, _targetDirectory);
                                    if (_abortRequested) break;

                                    GenerateUpdateProcedure(info, _targetDirectory);
                                    if (_abortRequested) break;
                                }

                            }
                        }
                        catch (Exception ex)
                        {
                            StringBuilder GenerationErrors = new StringBuilder();
                            GenerationErrors.Append(Environment.NewLine + "	SpGeneration Crashed:");
                            GenerationErrors.Append(ex.Message);
                            GenerationErrors.AppendLine();
                            GenerationErrors.AppendLine();
                            if (ex.InnerException != null)
                            {
                                GenerationErrors.AppendLine(ex.InnerException.Message);
                                GenerationErrors.AppendLine();
                                GenerationErrors.AppendLine(ex.InnerException.StackTrace.ToString());
                            }
                            GenerationErrors.AppendLine();
                            OnGenerationInformation(GenerationErrors.ToString(), 2);
                        }


                    }
                }
            }
            if (_abortRequested)
            {
                OnGenerationInformation(Environment.NewLine + "Code Generation Cancelled!", 2);
            }
            OnFinalized();
        }


        #region Stored Procedures generation
        FileInfo GetSprocFileInfo(string fileName)
        {
            FileInfo fi = new FileInfo(_targetDirectory + @"\sprocs\" + fileName + ".sql");
            return fi;
        }
        private void GenerateAllSprocsFile(CslaObjectInfo info, FileInfo file)
        {
            StringBuilder proc = new StringBuilder();

            //make sure we don't generate selects when we don't need to.
            if (!((info.ObjectType == CslaObjectType.EditableChildCollection || info.ObjectType == CslaObjectType.EditableChild) && !info.LazyLoad))
            {
                foreach (Criteria crit in info.CriteriaObjects)
                {
                    if (crit.GetOptions.Procedure && !String.IsNullOrEmpty(crit.GetOptions.ProcedureName))
                        proc.AppendLine(GenerateProcedure(info, crit, "SelectProcedure.cst", crit.GetOptions.ProcedureName));
                }
            }


            if (info.ObjectType != CslaObjectType.ReadOnlyObject
                && info.ObjectType != CslaObjectType.ReadOnlyCollection
                && info.ObjectType != CslaObjectType.EditableRootCollection
                && info.ObjectType != CslaObjectType.EditableChildCollection
                && info.ObjectType != CslaObjectType.NameValueList)
            {
                //Insert
                if (info.InsertProcedureName != "")
                {
                    proc.AppendLine(GenerateProcedure(info, null, "InsertProcedure.cst", info.InsertProcedureName));
                }

                //update
                if (info.UpdateProcedureName != "")
                {
                    proc.AppendLine(GenerateProcedure(info, null, "UpdateProcedure.cst", info.UpdateProcedureName));
                }

                //delete
                foreach (Criteria crit in info.CriteriaObjects)
                {
                    if (crit.DeleteOptions.Procedure && !String.IsNullOrEmpty(crit.DeleteOptions.ProcedureName))
                        proc.AppendLine(GenerateProcedure(info, crit, "DeleteProcedure.cst", crit.DeleteOptions.ProcedureName));
                }
                if (info.ObjectType == CslaObjectType.EditableChild)
                {
                    proc.AppendLine(GenerateProcedure(info, null, "DeleteProcedure.cst", info.DeleteProcedureName));
                }
            }
            if (proc.Length > 0)
            {
                CheckDirectory(file.Directory.FullName);
                WriteToFile(file, proc.ToString());
            }
        }

        private void GenerateSelectProcedure(CslaObjectInfo info)
        {
            //make sure we don't generate selects when we don't need to.
            if ( !((info.ObjectType == CslaObjectType.EditableChildCollection || info.ObjectType == CslaObjectType.EditableChild) && !info.LazyLoad))
            {
                foreach (Criteria crit in info.CriteriaObjects)
                {
                    if (crit.GetOptions.Procedure && !String.IsNullOrEmpty(crit.GetOptions.ProcedureName))
                    {
                        string proc = GenerateProcedure(info, crit, "SelectProcedure.cst", crit.GetOptions.ProcedureName);

                        WriteToFile(GetSprocFileInfo(crit.GetOptions.ProcedureName), proc);
                    }
                }
            }
        }

        private void GenerateInsertProcedure(CslaObjectInfo info, string dir)
        {
            if (info.InsertProcedureName != "")
            {
                string proc = GenerateProcedure(info, null, "InsertProcedure.cst", info.InsertProcedureName);
                WriteToFile(GetSprocFileInfo(info.InsertProcedureName), proc);
            }
        }

        private void GenerateUpdateProcedure(CslaObjectInfo info, string dir)
        {
            if (info.UpdateProcedureName != "")
            {
                string proc = GenerateProcedure(info, null, "UpdateProcedure.cst", info.UpdateProcedureName);
                WriteToFile(GetSprocFileInfo(info.UpdateProcedureName), proc);
            }
        }

        private void GenerateDeleteProcedure(CslaObjectInfo info, string dir)
        {
            foreach (Criteria crit in info.CriteriaObjects)
            {
                if (crit.DeleteOptions.Procedure && !String.IsNullOrEmpty(crit.DeleteOptions.ProcedureName))
                {
                    string proc = GenerateProcedure(info, crit, "DeleteProcedure.cst", crit.DeleteOptions.ProcedureName);
                    WriteToFile(GetSprocFileInfo(crit.DeleteOptions.ProcedureName), proc);
                }
            }
            if (info.ObjectType == CslaObjectType.EditableChild)
            {
                string proc = GenerateProcedure(info, null, "DeleteProcedure.cst", info.DeleteProcedureName);
                WriteToFile(GetSprocFileInfo(info.DeleteProcedureName), proc);
            }
        }


        private string GenerateProcedure(CslaObjectInfo objInfo, Criteria crit, string templateName, string sprocName)
        {
            if (objInfo != null)
            {
                try
                {
                    if (templateName != String.Empty)
                    {
                        string path = _templatesDirectory + @"sprocs\" + templateName;
                        CodeTemplate template = GetTemplate(objInfo, path);
                        if (crit != null)
                            template.SetProperty("Criteria", crit);
                        template.SetProperty("IncludeParentProperties", objInfo.DataSetLoadingScheme);
                        if (template != null)
                        {
                            using (StringWriter sw = new StringWriter())
                            {
                                template.Render(sw);
                                sprocSuccess++;
                                return sw.ToString();
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    sprocFailed++;
                    throw (new Exception("Error generating " + GetFileNameWithoutExtension(templateName) + ": " + sprocName, e));
                }
            }
            return String.Empty;
        }


        #endregion

        #region File / Directory related functions
        private void CheckDirectory(string dir)
        {
            if(!Directory.Exists(dir))
            {
                if (dir.StartsWith(@"\\"))
                {
                    throw new ApplicationException("Illegal path: UNC paths are not supported.");
                }
                // Recursion 
                // If this folder doesn't exists, check the parent folder
                if (dir.EndsWith(@"\"))
                {
                    dir = dir.Substring(0, dir.Length - 1);
                }
                else if (dir.IndexOf(@"\") == -1)
                    throw new ApplicationException(String.Format("The output path could not be created. Check that the \"{0}\" unit exists.", dir));

                CheckDirectory(dir.Substring(0, dir.LastIndexOf(@"\")));
                Directory.CreateDirectory(dir);
            }
        }

        private string GetNamespaceDirectory(string targetDir, CslaObjectInfo info, bool baseClass, bool separateNamespaces)
        {

            if(targetDir.EndsWith(@"\") == false) { targetDir += @"\"; }
    
            if(separateNamespaces) 
            {
                string namespaceSubFolder = info.ObjectNamespace.Replace(".", @"\");
        
                targetDir += namespaceSubFolder;
                if(targetDir.EndsWith(@"\") == false) { targetDir += @"\"; }
                
            }

            if (!info.Folder.Trim().Equals(String.Empty))
                targetDir += info.Folder + @"\";
            //if(baseClass && info.ObjectType != CslaObjectType.NameValueList) { targetDir += @"Base\"; }
            if(baseClass) { targetDir += @"Base\"; }
            CheckDirectory(targetDir);

            return targetDir;
        }

        private string GetFileName(CslaObjectInfo info, bool separateNamespaces, CodeLanguage OutputLanguage)
        {
            string fileName = info.FileName;
            if (GetFileExtension(fileName) == String.Empty)
            {
                if (OutputLanguage == CodeLanguage.CSharp) fileName += ".cs";
                if (OutputLanguage == CodeLanguage.VB) fileName += ".vb";
            }

            return(GetNamespaceDirectory(_targetDirectory, info, false, separateNamespaces) + fileName);
        }

        private string GetBaseFileName(CslaObjectInfo info, bool separateBaseClasses, bool separateNamespaces, bool useDotDesigner, CodeLanguage OutputLanguage)
        {
            string fileNoExtension = GetFileNameWithoutExtension(info.FileName);
            //if (info.ObjectType != CslaObjectType.NameValueList) { fileNoExtension += "Base"; }
            if (useDotDesigner)
                fileNoExtension += ".Designer";
            else
                fileNoExtension += "Base";
            string fileExtension = GetFileExtension(info.FileName);
            if (fileExtension == String.Empty)
            {
                if (OutputLanguage == CodeLanguage.CSharp) fileNoExtension += ".cs";
                if (OutputLanguage == CodeLanguage.VB) fileNoExtension += ".vb";
            }
            else
            {
                fileNoExtension += fileExtension;
            }

            return(GetNamespaceDirectory(_targetDirectory, info, separateBaseClasses, separateNamespaces) + fileNoExtension);
        }


        private string GetFileNameWithoutExtension(string fileName)
        {
            int index = fileName.LastIndexOf(".");
            if (index >= 0)
            {
                return fileName.Substring(0,index);
            }
            return fileName;
        }

        private string GetFileExtension(string fileName)
        {
            int index = fileName.LastIndexOf(".");
            if (index >= 0)
            {
                return fileName.Substring(index+1);
            }
            return String.Empty;
        }

        private string GetTemplateName(CslaObjectInfo info)
        {
            return GetTemplateName(info.ObjectType);
        }
        private string GetTemplateName(CslaObjectType type)
        {
            return String.Format("{0}.cst", type.ToString());
        }
        #endregion
    }
}
