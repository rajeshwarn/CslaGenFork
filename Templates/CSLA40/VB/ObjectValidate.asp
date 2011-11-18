<%
/*
ERRORS
1. Object namespace must be under base namespace
2. When using DAL, no DataSetLoadingScheme
3. When using DAL, no UseCustomLoading
4. When using DAL, criteria classes (with more than one property) may or may not be nested (DTO, DTO limit)
(run on Business or on DalObject)
5. When generating Data Access Region:
5.1. When generating Insert method, check Insert Procedure name isn't empty
5.2. When generating Update method, check Update Procedure name isn't empty
5.3. When generating Delete methods:
5.3.1. Check Criteria for DeleteOptions where DataPortal is set and SProc name is empty
5.3.2. Check Criteria for DeleteOptions where DataPortal is not set and SProc name is not empty (WARNINGS)
5.4. Check Criteria for GetOptions where DataPortal is set and SProc name is empty
5.5. Check Criteria for GetOptions where DataPortal is not set and SProc name is not empty (WARNINGS)
WARNINGS
6. When using DAL, unbound properties need DTO or will be excluded from DAL interaction
7. When using NOT DAL, Persistence type unshared needs database class
8. When using Silverligh 4, no Auto, Classic nor 'No Property'.
9. When using Silverligh 4, criteria classes (with more than one property) must not use Simple mode.
*/

if (Info.ObjectNamespace.IndexOf(CurrentUnit.GenerationParams.BaseNamespace) != 0)
{
    Errors.Append("Object Namespace '" + Info.ObjectNamespace + "' must be under Base namespace." + Environment.NewLine);
}

if (CurrentUnit.GenerationParams.TargetFramework == TargetFramework.CSLA40)
{
    if (Info.GenerateDataAccessRegion &&
        (Info.ObjectType == CslaObjectType.EditableRoot ||
        Info.ObjectType == CslaObjectType.DynamicEditableRoot ||
        Info.ObjectType == CslaObjectType.EditableChild ||
        Info.ObjectType == CslaObjectType.EditableSwitchable))
    {
        if (Info.GenerateDataPortalInsert)
        {
            if (string.IsNullOrEmpty(Info.InsertProcedureName))
            {
                Errors.Append("Object " + Info.ObjectName + " missing insert procedure name." + Environment.NewLine);
            }
        }
        if (Info.GenerateDataPortalUpdate)
        {
            if (string.IsNullOrEmpty(Info.UpdateProcedureName))
            {
                Errors.Append("Object " + Info.ObjectName + " missing update procedure name." + Environment.NewLine);
            }
        }
        if (Info.GenerateDataPortalDelete)
        {
            foreach (Criteria c in GetCriteriaObjects(Info))
            {
                if (c.DeleteOptions.DataPortal && c.DeleteOptions.ProcedureName == string.Empty)
                {
                    Errors.Append("Criteria " + Info.ObjectName + "." + c.Name +": DataPortal delete option is enable but is missing Delete procedure name." + Environment.NewLine);
                }
                if (!c.DeleteOptions.DataPortal && c.DeleteOptions.ProcedureName != string.Empty)
                {
                    Warnings.Append("Criteria " + Info.ObjectName + "." + c.Name +": DataPortal delete option is disable but has Delete procedure name." + Environment.NewLine);
                }
            }
        }
    }

    foreach (Criteria c in GetCriteriaObjects(Info))
    {
        if (c.GetOptions.DataPortal && c.GetOptions.ProcedureName == string.Empty)
        {
            Errors.Append("Criteria " + Info.ObjectName + "." + c.Name +": DataPortal get option is enable but is missing Get procedure name." + Environment.NewLine);
        }
        if (!c.GetOptions.DataPortal && c.GetOptions.ProcedureName != string.Empty)
        {
            Warnings.Append("Criteria " + Info.ObjectName + "." + c.Name +": DataPortal get option is disable but has Get procedure name." + Environment.NewLine);
        }
    }
}

if (Info.PersistenceType == PersistenceType.SqlConnectionUnshared &&
    !CurrentUnit.GenerationParams.GenerateDatabaseClass &&
    CurrentUnit.GenerationParams.TargetFramework == TargetFramework.CSLA40)
{
    Warnings.Append("Generation settings: 'Generate Database class' is un-checked. Persistence Type.SqlConnectionUnshared needs the database class." + Environment.NewLine);
}

foreach (ValueProperty prop in Info.GetDatabaseBoundValueProperties())
{
    if (CurrentUnit.GenerationParams.TargetFramework == TargetFramework.CSLA40DAL && !DalObjectUsesDTO(Info))
    {
        if (prop.DbBindColumn.ColumnOriginType == ColumnOriginType.None)
            Warnings.Append(Info.ObjectName + "Property " + prop.Name + " isn't database bound; must use DTO or property will be excluded from DAL interaction." + Environment.NewLine);
    }
    if (CurrentUnit.GenerationParams.GenerateSilverlight4)
    {
        if (prop.DeclarationMode != PropertyDeclaration.Managed &&
            prop.DeclarationMode != PropertyDeclaration.ManagedWithTypeConversion)
            Warnings.Append("Property " + prop.Name + ": must use Declaration Mode 'Managed' or 'ManagedWithTypeConversion' under Silverlight." + Environment.NewLine);
    }
}

if (CurrentUnit.GenerationParams.TargetFramework == TargetFramework.CSLA40DAL)
{
    if (Info.DataSetLoadingScheme)
    {
        Errors.Append("DataSet Loading Scheme isn't supported when generating DAL." + Environment.NewLine);
    }
    if (Info.UseCustomLoading)
    {
        Errors.Append("Custom Loading isn't supported when generating DAL." + Environment.NewLine);
    }
}

if (CurrentUnit.GenerationParams.GenerateSilverlight4 ||
    CurrentUnit.GenerationParams.TargetFramework == TargetFramework.CSLA40DAL)
{
    foreach (Criteria criteria in Info.CriteriaObjects)
    {
        if (criteria.Properties.Count > 1)
        {
            if (CurrentUnit.GenerationParams.GenerateSilverlight4 && criteria.CriteriaClassMode == CriteriaMode.Simple)
                Warnings.Append("Criteria " + criteria.Name + ": must use Mode 'CriteriaBase' or 'BusinessBase' under Silverlight." + Environment.NewLine);
            if (CurrentUnit.GenerationParams.TargetFramework == TargetFramework.CSLA40DAL && criteria.NestedClass && DalObjectUsesCriteria(Info))
                Errors.Append("Criteria " + criteria.Name + ": Nested criteria class isn't supported when generating DAL." + Environment.NewLine);
        }
    }
}
%>
