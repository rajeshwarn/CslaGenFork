'  This file was generated by CSLA Object Generator - CslaGenFork v4.5
'
' Filename:    FolderType
' ObjectType:  FolderType
' CSLAType:    EditableRoot

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data
Imports DocStore.Business.Util
Imports Csla.Rules
Imports Csla.Rules.CommonRules
Imports DocStore.Business.Security

Namespace DocStore.Business

    ''' <summary>
    ''' Folder type (editable root object).<br/>
    ''' This is a generated base class of <see cref="FolderType"/> business object.
    ''' </summary>
    <Serializable>
    Public Partial Class FolderType
        Inherits BusinessBase(Of FolderType)

        #Region " Static Fields "

            Private Shared _lastId As Integer

        #End Region

        #Region " Business Properties "

        ''' <summary>
        ''' Maintains metadata about <see cref="FolderTypeID"/> property.
        ''' </summary>
        <NotUndoable>
        Public Shared ReadOnly FolderTypeIDProperty As PropertyInfo(Of Integer) = RegisterProperty(Of Integer)(Function(p) p.FolderTypeID, "Folder Type ID")
        ''' <summary>
        ''' Gets the Folder Type ID.
        ''' </summary>
        ''' <value>The Folder Type ID.</value>
        Public ReadOnly Property FolderTypeID As Integer
            Get
                Return GetProperty(FolderTypeIDProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="FolderTypeName"/> property.
        ''' </summary>
        Public Shared ReadOnly FolderTypeNameProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.FolderTypeName, "Folder Type Name")
        ''' <summary>
        ''' Gets or sets the Folder Type Name.
        ''' </summary>
        ''' <value>The Folder Type Name.</value>
        Public Property FolderTypeName As String
            Get
                Return GetProperty(FolderTypeNameProperty)
            End Get
            Set(ByVal value As String)
                SetProperty(FolderTypeNameProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="CreateDate"/> property.
        ''' </summary>
        Public Shared ReadOnly CreateDateProperty As PropertyInfo(Of SmartDate) = RegisterProperty(Of SmartDate)(Function(p) p.CreateDate, "Create Date")
        ''' <summary>
        ''' Gets the Create Date.
        ''' </summary>
        ''' <value>The Create Date.</value>
        Public ReadOnly Property CreateDate As SmartDate
            Get
                Return GetProperty(CreateDateProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="CreateUserID"/> property.
        ''' </summary>
        Public Shared ReadOnly CreateUserIDProperty As PropertyInfo(Of Integer) = RegisterProperty(Of Integer)(Function(p) p.CreateUserID, "Create User ID")
        ''' <summary>
        ''' Gets the Create User ID.
        ''' </summary>
        ''' <value>The Create User ID.</value>
        Public ReadOnly Property CreateUserID As Integer
            Get
                Return GetProperty(CreateUserIDProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="ChangeDate"/> property.
        ''' </summary>
        Public Shared ReadOnly ChangeDateProperty As PropertyInfo(Of SmartDate) = RegisterProperty(Of SmartDate)(Function(p) p.ChangeDate, "Change Date")
        ''' <summary>
        ''' Gets the Change Date.
        ''' </summary>
        ''' <value>The Change Date.</value>
        Public ReadOnly Property ChangeDate As SmartDate
            Get
                Return GetProperty(ChangeDateProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="ChangeUserID"/> property.
        ''' </summary>
        Public Shared ReadOnly ChangeUserIDProperty As PropertyInfo(Of Integer) = RegisterProperty(Of Integer)(Function(p) p.ChangeUserID, "Change User ID")
        ''' <summary>
        ''' Gets the Change User ID.
        ''' </summary>
        ''' <value>The Change User ID.</value>
        Public ReadOnly Property ChangeUserID As Integer
            Get
                Return GetProperty(ChangeUserIDProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="RowVersion"/> property.
        ''' </summary>
        <NotUndoable>
        Public Shared ReadOnly RowVersionProperty As PropertyInfo(Of Byte()) = RegisterProperty(Of Byte())(Function(p) p.RowVersion, "Row Version")
        ''' <summary>
        ''' Gets the Row Version.
        ''' </summary>
        ''' <value>The Row Version.</value>
        Public ReadOnly Property RowVersion As Byte()
            Get
                Return GetProperty(RowVersionProperty)
            End Get
        End Property

        ''' <summary>
        ''' Gets the Create User Name.
        ''' </summary>
        ''' <value>The Create User Name.</value>
        Public ReadOnly Property CreateUserName As String
            Get
                Dim result = String.Empty
                If Admin.UserNVL.GetUserNVL().ContainsKey(CreateUserID) Then
                    result = Admin.UserNVL.GetUserNVL().GetItemByKey(CreateUserID).Value
                End If
                Return result
            End Get
        End Property

        ''' <summary>
        ''' Gets the Change User Name.
        ''' </summary>
        ''' <value>The Change User Name.</value>
        Public ReadOnly Property ChangeUserName As String
            Get
                Dim result = String.Empty
                If Admin.UserNVL.GetUserNVL().ContainsKey(ChangeUserID) Then
                    result = Admin.UserNVL.GetUserNVL().GetItemByKey(ChangeUserID).Value
                End If
                Return result
            End Get
        End Property

        #End Region

        #Region " BusinessBase(Of T) Overrides "

        ''' <summary>
        ''' Returns a string that represents the current <see cref="FolderType"/>
        ''' </summary>
        ''' <returns>A <see cref="System.String"/> that represents this instance.</returns>
        Public Overrides Function ToString() As String
            ' Return the Primary Key as a string
            Return FolderTypeName.ToString()
        End Function

        #End Region

        #Region " Factory Methods "

        ''' <summary>
        ''' Factory method. Creates a new <see cref="FolderType"/> object.
        ''' </summary>
        ''' <returns>A reference to the created <see cref="FolderType"/> object.</returns>
        Public Shared Function NewFolderType() As FolderType
            Return DataPortal.Create(Of FolderType)()
        End Function

        ''' <summary>
        ''' Factory method. Loads a <see cref="FolderType"/> object, based on given parameters.
        ''' </summary>
        ''' <param name="folderTypeID">The FolderTypeID parameter of the FolderType to fetch.</param>
        ''' <returns>A reference to the fetched <see cref="FolderType"/> object.</returns>
        Public Shared Function GetFolderType(folderTypeID As Integer) As FolderType
            Return DataPortal.Fetch(Of FolderType)(folderTypeID)
        End Function

        ''' <summary>
        ''' Factory method. Deletes a <see cref="FolderType"/> object, based on given parameters.
        ''' </summary>
        ''' <param name="folderTypeID">The FolderTypeID of the FolderType to delete.</param>
        Public Shared Sub DeleteFolderType(folderTypeID As Integer)
            DataPortal.Delete(Of FolderType)(folderTypeID)
        End Sub

        ''' <summary>
        ''' Factory method. Asynchronously creates a new <see cref="FolderType"/> object.
        ''' </summary>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub NewFolderType(callback As EventHandler(Of DataPortalResult(Of FolderType)))
            DataPortal.BeginCreate(Of FolderType)(callback)
        End Sub

        ''' <summary>
        ''' Factory method. Asynchronously loads a <see cref="FolderType"/> object, based on given parameters.
        ''' </summary>
        ''' <param name="folderTypeID">The FolderTypeID parameter of the FolderType to fetch.</param>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub GetFolderType(folderTypeID As Integer, ByVal callback As EventHandler(Of DataPortalResult(Of FolderType)))
            DataPortal.BeginFetch(Of FolderType)(folderTypeID, callback)
        End Sub

        ''' <summary>
        ''' Factory method. Asynchronously deletes a <see cref="FolderType"/> object, based on given parameters.
        ''' </summary>
        ''' <param name="folderTypeID">The FolderTypeID of the FolderType to delete.</param>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub DeleteFolderType(folderTypeID As Integer, callback As EventHandler(Of DataPortalResult(Of FolderType)))
            DataPortal.BeginDelete(Of FolderType)(folderTypeID, callback)
        End Sub

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="FolderType"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.
        End Sub

        #End Region

        #Region " Object Authorization "

        ''' <summary>
        ''' Adds the object authorization rules.
        ''' </summary>
        Protected Shared Sub AddObjectAuthorizationRules()
            BusinessRules.AddRule(GetType(FolderType), New IsInRole(AuthorizationActions.CreateObject, "Manager"))
            BusinessRules.AddRule(GetType(FolderType), New IsInRole(AuthorizationActions.GetObject, "User"))
            BusinessRules.AddRule(GetType(FolderType), New IsInRole(AuthorizationActions.EditObject, "Manager"))
            BusinessRules.AddRule(GetType(FolderType), New IsInRole(AuthorizationActions.DeleteObject, "Admin"))

            AddObjectAuthorizationRulesExtend()
        End Sub

        ''' <summary>
        ''' Allows the set up of custom object authorization rules.
        ''' </summary>
        Partial Private Shared Sub AddObjectAuthorizationRulesExtend()
        End Sub

        ''' <summary>
        ''' Checks if the current user can create a new FolderType object.
        ''' </summary>
        ''' <returns><c>True</c> if the user can create a new object; otherwise, <c>false</c>.</returns>
        Public Overloads Shared Function CanAddObject() As Boolean
            Return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.CreateObject, GetType(FolderType))
        End Function

        ''' <summary>
        ''' Checks if the current user can retrieve FolderType's properties.
        ''' </summary>
        ''' <returns><c>True</c> if the user can read the object; otherwise, <c>false</c>.</returns>
        Public Overloads Shared Function CanGetObject() As Boolean
            Return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.GetObject, GetType(FolderType))
        End Function

        ''' <summary>
        ''' Checks if the current user can change FolderType's properties.
        ''' </summary>
        ''' <returns><c>True</c> if the user can update the object; otherwise, <c>false</c>.</returns>
        Public Overloads Shared Function CanEditObject() As Boolean
            Return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.EditObject, GetType(FolderType))
        End Function

        ''' <summary>
        ''' Checks if the current user can delete a FolderType object.
        ''' </summary>
        ''' <returns><c>True</c> if the user can delete the object; otherwise, <c>false</c>.</returns>
        Public Overloads Shared Function CanDeleteObject() As Boolean
            Return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.DeleteObject, GetType(FolderType))
        End Function

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads default values for the <see cref="FolderType"/> object properties.
        ''' </summary>
        <RunLocal>
        Protected Overrides Sub DataPortal_Create()
            LoadProperty(FolderTypeIDProperty, System.Threading.Interlocked.Decrement(_lastId))
            LoadProperty(CreateDateProperty, new SmartDate(Date.Now))
            LoadProperty(CreateUserIDProperty, UserInformation.UserId)
            LoadProperty(ChangeDateProperty, ReadProperty(CreateDateProperty))
            LoadProperty(ChangeUserIDProperty, ReadProperty(CreateUserIDProperty))
            Dim args As New DataPortalHookArgs()
            OnCreate(args)
            MyBase.DataPortal_Create()
        End Sub

        ''' <summary>
        ''' Loads a <see cref="FolderType"/> object from the database, based on given criteria.
        ''' </summary>
        ''' <param name="folderTypeID">The Folder Type ID.</param>
        Protected Sub DataPortal_Fetch(folderTypeID As Integer)
            Using ctx = ConnectionManager(Of SqlConnection).GetManager(Database.DocStoreConnection, False)
                Using cmd = New SqlCommand("GetFolderType", ctx.Connection)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@FolderTypeID", folderTypeID).DbType = DbType.Int32
                    Dim args As New DataPortalHookArgs(cmd, folderTypeID)
                    OnFetchPre(args)
                    Fetch(cmd)
                    OnFetchPost(args)
                End Using
            End Using
            ' check all object rules and property rules
            BusinessRules.CheckRules()
        End Sub

        Private Sub Fetch(cmd As SqlCommand)
            Using dr As New SafeDataReader(cmd.ExecuteReader())
                If dr.Read() Then
                    Fetch(dr)
                End If
            End Using
        End Sub

        ''' <summary>
        ''' Loads a <see cref="FolderType"/> object from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Fetch(dr As SafeDataReader)
            ' Value properties
            LoadProperty(FolderTypeIDProperty, dr.GetInt32("FolderTypeID"))
            LoadProperty(FolderTypeNameProperty, dr.GetString("FolderTypeName"))
            LoadProperty(CreateDateProperty, dr.GetSmartDate("CreateDate", True))
            LoadProperty(CreateUserIDProperty, dr.GetInt32("CreateUserID"))
            LoadProperty(ChangeDateProperty, dr.GetSmartDate("ChangeDate", True))
            LoadProperty(ChangeUserIDProperty, dr.GetInt32("ChangeUserID"))
            LoadProperty(RowVersionProperty, TryCast(dr.GetValue("RowVersion"), Byte()))
            Dim args As New DataPortalHookArgs(dr)
            OnFetchRead(args)
        End Sub

        ''' <summary>
        ''' Inserts a new <see cref="FolderType"/> object in the database.
        ''' </summary>
        Protected Overrides Sub DataPortal_Insert()
            SimpleAuditTrail()
            Using ctx = TransactionManager(Of SqlConnection, SqlTransaction).GetManager(Database.DocStoreConnection, False)
                Using cmd = New SqlCommand("AddFolderType", ctx.Connection)
                    cmd.Transaction = ctx.Transaction
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@FolderTypeID", ReadProperty(FolderTypeIDProperty)).Direction = ParameterDirection.Output
                    cmd.Parameters.AddWithValue("@FolderTypeName", ReadProperty(FolderTypeNameProperty)).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@CreateDate", ReadProperty(CreateDateProperty).DBValue).DbType = DbType.DateTime2
                    cmd.Parameters.AddWithValue("@CreateUserID", ReadProperty(CreateUserIDProperty)).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@ChangeDate", ReadProperty(ChangeDateProperty).DBValue).DbType = DbType.DateTime2
                    cmd.Parameters.AddWithValue("@ChangeUserID", ReadProperty(ChangeUserIDProperty)).DbType = DbType.Int32
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output
                    Dim args As New DataPortalHookArgs(cmd)
                    OnInsertPre(args)
                    cmd.ExecuteNonQuery()
                    OnInsertPost(args)
                    LoadProperty(FolderTypeIDProperty, DirectCast(cmd.Parameters("@FolderTypeID").Value, Integer))
                    LoadProperty(RowVersionProperty, DirectCast(cmd.Parameters("@NewRowVersion").Value, Byte()))
                End Using
                ctx.Commit()
            End Using
        End Sub

        ''' <summary>
        ''' Updates in the database all changes made to the <see cref="FolderType"/> object.
        ''' </summary>
        Protected Overrides Sub DataPortal_Update()
            SimpleAuditTrail()
            Using ctx = TransactionManager(Of SqlConnection, SqlTransaction).GetManager(Database.DocStoreConnection, False)
                Using cmd = New SqlCommand("UpdateFolderType", ctx.Connection)
                    cmd.Transaction = ctx.Transaction
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@FolderTypeID", ReadProperty(FolderTypeIDProperty)).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@FolderTypeName", ReadProperty(FolderTypeNameProperty)).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@ChangeDate", ReadProperty(ChangeDateProperty).DBValue).DbType = DbType.DateTime2
                    cmd.Parameters.AddWithValue("@ChangeUserID", ReadProperty(ChangeUserIDProperty)).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@RowVersion", ReadProperty(RowVersionProperty)).DbType = DbType.Binary
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output
                    Dim args As New DataPortalHookArgs(cmd)
                    OnUpdatePre(args)
                    cmd.ExecuteNonQuery()
                    OnUpdatePost(args)
                    LoadProperty(RowVersionProperty, DirectCast(cmd.Parameters("@NewRowVersion").Value, Byte()))
                End Using
                ctx.Commit()
            End Using
        End Sub

        Private Sub SimpleAuditTrail()
            LoadProperty(ChangeDateProperty, Date.Now)
            LoadProperty(ChangeUserIDProperty, UserInformation.UserId)
            OnPropertyChanged("ChangeUserName")
            If IsNew Then
                LoadProperty(CreateDateProperty, ReadProperty(ChangeDateProperty))
                LoadProperty(CreateUserIDProperty, ReadProperty(ChangeUserIDProperty))
                OnPropertyChanged("CreateUserName")
            End If
        End Sub

        ''' <summary>
        ''' Self deletes the <see cref="FolderType"/> object.
        ''' </summary>
        Protected Overrides Sub DataPortal_DeleteSelf()
            DataPortal_Delete(FolderTypeID)
        End Sub

        ''' <summary>
        ''' Deletes the <see cref="FolderType"/> object from database.
        ''' </summary>
        ''' <param name="folderTypeID">The delete criteria.</param>
        Protected Sub DataPortal_Delete(folderTypeID As Integer)
            ' audit the object, just in case soft delete is used on this object
            SimpleAuditTrail()
            Using ctx = TransactionManager(Of SqlConnection, SqlTransaction).GetManager(Database.DocStoreConnection, False)
                Using cmd = New SqlCommand("DeleteFolderType", ctx.Connection)
                    cmd.Transaction = ctx.Transaction
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@FolderTypeID", folderTypeID).DbType = DbType.Int32
                    Dim args As New DataPortalHookArgs(cmd, folderTypeID)
                    OnDeletePre(args)
                    cmd.ExecuteNonQuery()
                    OnDeletePost(args)
                End Using
                ctx.Commit()
            End Using
        End Sub

        #End Region

        #Region " DataPortal Hooks "

        ''' <summary>
        ''' Occurs after setting all defaults for object creation.
        ''' </summary>
        Partial Private Sub OnCreate(args As DataPortalHookArgs)
        End Sub

        ''' <summary>
        ''' Occurs in DataPortal_Delete, after setting query parameters and before the delete operation.
        ''' </summary>
        Partial Private Sub OnDeletePre(args As DataPortalHookArgs)
        End Sub

        ''' <summary>
        ''' Occurs in DataPortal_Delete, after the delete operation, before Commit().
        ''' </summary>
        Partial Private Sub OnDeletePost(args As DataPortalHookArgs)
        End Sub

        ''' <summary>
        ''' Occurs after setting query parameters and before the fetch operation.
        ''' </summary>
        Partial Private Sub OnFetchPre(args As DataPortalHookArgs)
        End Sub

        ''' <summary>
        ''' Occurs after the fetch operation (object or collection is fully loaded and set up).
        ''' </summary>
        Partial Private Sub OnFetchPost(args As DataPortalHookArgs)
        End Sub

        ''' <summary>
        ''' Occurs after the low level fetch operation, before the data reader is destroyed.
        ''' </summary>
        Partial Private Sub OnFetchRead(args As DataPortalHookArgs)
        End Sub

        ''' <summary>
        ''' Occurs after setting query parameters and before the update operation.
        ''' </summary>
        Partial Private Sub OnUpdatePre(args As DataPortalHookArgs)
        End Sub

        ''' <summary>
        ''' Occurs in DataPortal_Insert, after the update operation, before setting back row identifiers (RowVersion) and Commit().
        ''' </summary>
        Partial Private Sub OnUpdatePost(args As DataPortalHookArgs)
        End Sub

        ''' <summary>
        ''' Occurs in DataPortal_Insert, after setting query parameters and before the insert operation.
        ''' </summary>
        Partial Private Sub OnInsertPre(args As DataPortalHookArgs)
        End Sub

        ''' <summary>
        ''' Occurs in DataPortal_Insert, after the insert operation, before setting back row identifiers (ID and RowVersion) and Commit().
        ''' </summary>
        Partial Private Sub OnInsertPost(args As DataPortalHookArgs)
        End Sub

        #End Region

    End Class

End Namespace
