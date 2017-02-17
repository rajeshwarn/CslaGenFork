'  This file was generated by CSLA Object Generator - CslaGenFork v4.5
'
' Filename:    DocStatusEditDyna
' ObjectType:  DocStatusEditDyna
' CSLAType:    DynamicEditableRoot

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data
Imports DocStore.Business.Util
Imports DocStore.Business.Security
Imports UsingLibrary

Namespace DocStore.Business

    ''' <summary>
    ''' DocStatusEditDyna (dynamic root object).<br/>
    ''' This is a generated base class of <see cref="DocStatusEditDyna"/> business object.
    ''' </summary>
    ''' <remarks>
    ''' This class is an item of <see cref="DocStatusEditDynaColl"/> collection.
    ''' </remarks>
    <Serializable>
    Public Partial Class DocStatusEditDyna
        Inherits BusinessBase(Of DocStatusEditDyna)
        Implements IHaveInterface, IHaveGenericInterface(Of DocStatusEditDyna)

        #Region " Static Fields "

            Private Shared _lastId As Integer

        #End Region

        #Region " Business Properties "

        ''' <summary>
        ''' Maintains metadata about <see cref="DocStatusID"/> property.
        ''' </summary>
        <NotUndoable>
        Public Shared ReadOnly DocStatusIDProperty As PropertyInfo(Of Integer) = RegisterProperty(Of Integer)(Function(p) p.DocStatusID, "Doc Status ID")
        ''' <summary>
        ''' Row version counter for concurrency control
        ''' </summary>
        ''' <value>The Doc Status ID.</value>
        Public ReadOnly Property DocStatusID As Integer
            Get
                Return GetProperty(DocStatusIDProperty)
            End Get
        End Property

        ''' <summary>
        ''' Maintains metadata about <see cref="DocStatusName"/> property.
        ''' </summary>
        Public Shared ReadOnly DocStatusNameProperty As PropertyInfo(Of String) = RegisterProperty(Of String)(Function(p) p.DocStatusName, "Doc Status Name")
        ''' <summary>
        ''' Gets or sets the Doc Status Name.
        ''' </summary>
        ''' <value>The Doc Status Name.</value>
        Public Property DocStatusName As String
            Get
                Return GetProperty(DocStatusNameProperty)
            End Get
            Set(ByVal value As String)
                SetProperty(DocStatusNameProperty, value)
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

        #End Region

        #Region " Factory Methods "

        ''' <summary>
        ''' Factory method. Creates a new <see cref="DocStatusEditDyna"/> object.
        ''' </summary>
        ''' <returns>A reference to the created <see cref="DocStatusEditDyna"/> object.</returns>
        Friend Shared Function NewDocStatusEditDyna() As DocStatusEditDyna
            Return DataPortal.Create(Of DocStatusEditDyna)()
        End Function

        ''' <summary>
        ''' Factory method. Loads a <see cref="DocStatusEditDyna"/> object from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        ''' <returns>A reference to the fetched <see cref="DocStatusEditDyna"/> object.</returns>
        Friend Shared Function GetDocStatusEditDyna(dr As SafeDataReader) As DocStatusEditDyna
            Dim obj As DocStatusEditDyna = New DocStatusEditDyna()
            obj.Fetch(dr)
            obj.MarkOld()
            ' check all object rules and property rules
            obj.BusinessRules.CheckRules()
            Return obj
        End Function

        ''' <summary>
        ''' Factory method. Deletes a <see cref="DocStatusEditDyna"/> object, based on given parameters.
        ''' </summary>
        ''' <param name="docStatusID">The DocStatusID of the DocStatusEditDyna to delete.</param>
        Friend Shared Sub DeleteDocStatusEditDyna(docStatusID As Integer)
            DataPortal.Delete(Of DocStatusEditDyna)(docStatusID)
        End Sub

        ''' <summary>
        ''' Factory method. Asynchronously creates a new <see cref="DocStatusEditDyna"/> object.
        ''' </summary>
        ''' <param name="callback">The completion callback method.</param>
        Friend Shared Sub NewDocStatusEditDyna(callback As EventHandler(Of DataPortalResult(Of DocStatusEditDyna)))
            DataPortal.BeginCreate(Of DocStatusEditDyna)(callback)
        End Sub

        ''' <summary>
        ''' Factory method. Asynchronously deletes a <see cref="DocStatusEditDyna"/> object, based on given parameters.
        ''' </summary>
        ''' <param name="docStatusID">The DocStatusID of the DocStatusEditDyna to delete.</param>
        ''' <param name="callback">The completion callback method.</param>
        Friend Shared Sub DeleteDocStatusEditDyna(docStatusID As Integer, callback As EventHandler(Of DataPortalResult(Of DocStatusEditDyna)))
            DataPortal.BeginDelete(Of DocStatusEditDyna)(docStatusID, callback)
        End Sub

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="DocStatusEditDyna"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.
        End Sub

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads default values for the <see cref="DocStatusEditDyna"/> object properties.
        ''' </summary>
        <RunLocal>
        Protected Overrides Sub DataPortal_Create()
            LoadProperty(DocStatusIDProperty, System.Threading.Interlocked.Decrement(_lastId))
            LoadProperty(CreateDateProperty, new SmartDate(Date.Now))
            LoadProperty(CreateUserIDProperty, UserInformation.UserId)
            LoadProperty(ChangeDateProperty, ReadProperty(CreateDateProperty))
            LoadProperty(ChangeUserIDProperty, ReadProperty(CreateUserIDProperty))
            Dim args As New DataPortalHookArgs()
            OnCreate(args)
            MyBase.DataPortal_Create()
        End Sub

        ''' <summary>
        ''' Loads a <see cref="DocStatusEditDyna"/> object from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Fetch(dr As SafeDataReader)
            ' Value properties
            LoadProperty(DocStatusIDProperty, dr.GetInt32("DocStatusID"))
            LoadProperty(DocStatusNameProperty, dr.GetString("DocStatusName"))
            LoadProperty(CreateDateProperty, dr.GetSmartDate("CreateDate", True))
            LoadProperty(CreateUserIDProperty, dr.GetInt32("CreateUserID"))
            LoadProperty(ChangeDateProperty, dr.GetSmartDate("ChangeDate", True))
            LoadProperty(ChangeUserIDProperty, dr.GetInt32("ChangeUserID"))
            LoadProperty(RowVersionProperty, TryCast(dr.GetValue("RowVersion"), Byte()))
            Dim args As New DataPortalHookArgs(dr)
            OnFetchRead(args)
        End Sub

        ''' <summary>
        ''' Inserts a new <see cref="DocStatusEditDyna"/> object in the database.
        ''' </summary>
        Protected Overrides Sub DataPortal_Insert()
            SimpleAuditTrail()
            Using ctx = TransactionManager(Of SqlConnection, SqlTransaction).GetManager(Database.DocStoreConnection, False)
                Using cmd = New SqlCommand("AddDocStatusEditDyna", ctx.Connection)
                    cmd.Transaction = ctx.Transaction
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@DocStatusID", ReadProperty(DocStatusIDProperty)).Direction = ParameterDirection.Output
                    cmd.Parameters.AddWithValue("@DocStatusName", ReadProperty(DocStatusNameProperty)).DbType = DbType.String
                    cmd.Parameters.AddWithValue("@CreateDate", ReadProperty(CreateDateProperty).DBValue).DbType = DbType.DateTime2
                    cmd.Parameters.AddWithValue("@CreateUserID", ReadProperty(CreateUserIDProperty)).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@ChangeDate", ReadProperty(ChangeDateProperty).DBValue).DbType = DbType.DateTime2
                    cmd.Parameters.AddWithValue("@ChangeUserID", ReadProperty(ChangeUserIDProperty)).DbType = DbType.Int32
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output
                    Dim args As New DataPortalHookArgs(cmd)
                    OnInsertPre(args)
                    cmd.ExecuteNonQuery()
                    OnInsertPost(args)
                    LoadProperty(DocStatusIDProperty, DirectCast(cmd.Parameters("@DocStatusID").Value, Integer))
                    LoadProperty(RowVersionProperty, DirectCast(cmd.Parameters("@NewRowVersion").Value, Byte()))
                End Using
                ctx.Commit()
            End Using
        End Sub

        ''' <summary>
        ''' Updates in the database all changes made to the <see cref="DocStatusEditDyna"/> object.
        ''' </summary>
        Protected Overrides Sub DataPortal_Update()
            SimpleAuditTrail()
            Using ctx = TransactionManager(Of SqlConnection, SqlTransaction).GetManager(Database.DocStoreConnection, False)
                Using cmd = New SqlCommand("UpdateDocStatusEditDyna", ctx.Connection)
                    cmd.Transaction = ctx.Transaction
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@DocStatusID", ReadProperty(DocStatusIDProperty)).DbType = DbType.Int32
                    cmd.Parameters.AddWithValue("@DocStatusName", ReadProperty(DocStatusNameProperty)).DbType = DbType.String
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
            If IsNew Then
                LoadProperty(CreateDateProperty, ReadProperty(ChangeDateProperty))
                LoadProperty(CreateUserIDProperty, ReadProperty(ChangeUserIDProperty))
            End If
        End Sub

        ''' <summary>
        ''' Self deletes the <see cref="DocStatusEditDyna"/> object.
        ''' </summary>
        Protected Overrides Sub DataPortal_DeleteSelf()
            DataPortal_Delete(DocStatusID)
        End Sub

        ''' <summary>
        ''' Deletes the <see cref="DocStatusEditDyna"/> object from database.
        ''' </summary>
        ''' <param name="docStatusID">The delete criteria.</param>
        Protected Sub DataPortal_Delete(docStatusID As Integer)
            ' audit the object, just in case soft delete is used on this object
            SimpleAuditTrail()
            Using ctx = TransactionManager(Of SqlConnection, SqlTransaction).GetManager(Database.DocStoreConnection, False)
                Using cmd = New SqlCommand("DeleteDocStatusEditDyna", ctx.Connection)
                    cmd.Transaction = ctx.Transaction
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@DocStatusID", docStatusID).DbType = DbType.Int32
                    Dim args As New DataPortalHookArgs(cmd, docStatusID)
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
