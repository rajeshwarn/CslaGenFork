'  This file was generated by CSLA Object Generator - CslaGenFork v4.5
'
' Filename:    DocClassEditCollGetter
' ObjectType:  DocClassEditCollGetter
' CSLAType:    UnitOfWork

Imports System
Imports Csla
Imports DocStore.Business.Admin

Namespace DocStore.Business

    ''' <summary>
    ''' DocClassEditCollGetter (creator and getter unit of work pattern).<br/>
    ''' This is a generated base class of <see cref="DocClassEditCollGetter"/> business object.
    ''' This class is a root object that implements the Unit of Work pattern.
    ''' </summary>
    <Serializable>
    Public Partial Class DocClassEditCollGetter
        Inherits ReadOnlyBase(Of DocClassEditCollGetter)

        #Region " Business Properties "

        ''' <summary>
        ''' Maintains metadata about unit of work (child) <see cref="DocClassEditColl"/> property.
        ''' </summary>
        Public Shared ReadOnly DocClassEditCollProperty As PropertyInfo(Of DocClassEditColl) = RegisterProperty(Of DocClassEditColl)(Function(p) p.DocClassEditColl, "Doc Class Edit Coll")
        ''' <summary>
        ''' Gets the Doc Class Edit Coll object (unit of work child property).
        ''' </summary>
        ''' <value>The Doc Class Edit Coll.</value>
        Public Property DocClassEditColl As DocClassEditColl
            Get
                Return GetProperty(DocClassEditCollProperty)
            End Get
            Private Set(ByVal value As DocClassEditColl)
                LoadProperty(DocClassEditCollProperty, value)
            End Set
        End Property

        ''' <summary>
        ''' Maintains metadata about unit of work (child) <see cref="UserNVL"/> property.
        ''' </summary>
        Public Shared ReadOnly UserNVLProperty As PropertyInfo(Of UserNVL) = RegisterProperty(Of UserNVL)(Function(p) p.UserNVL, "User NVL")
        ''' <summary>
        ''' Gets the User NVL object (unit of work child property).
        ''' </summary>
        ''' <value>The User NVL.</value>
        Public Property UserNVL As UserNVL
            Get
                Return GetProperty(UserNVLProperty)
            End Get
            Private Set(ByVal value As UserNVL)
                LoadProperty(UserNVLProperty, value)
            End Set
        End Property

        #End Region

        #Region " Factory Methods "

        ''' <summary>
        ''' Factory method. Creates a new <see cref="DocClassEditCollGetter"/> unit of objects.
        ''' </summary>
        ''' <returns>A reference to the created <see cref="DocClassEditCollGetter"/> unit of objects.</returns>
        Public Shared Function NewDocClassEditCollGetter() As DocClassEditCollGetter
            ' DataPortal_Fetch is used as ReadOnlyBase<T> doesn't allow the use of DataPortal_Create.
            Return DataPortal.Fetch(Of DocClassEditCollGetter)(True)
        End Function

        ''' <summary>
        ''' Factory method. Loads a <see cref="DocClassEditCollGetter"/> unit of objects.
        ''' </summary>
        ''' <returns>A reference to the fetched <see cref="DocClassEditCollGetter"/> unit of objects.</returns>
        Public Shared Function GetDocClassEditCollGetter() As DocClassEditCollGetter
            Return DataPortal.Fetch(Of DocClassEditCollGetter)(False)
        End Function

        ''' <summary>
        ''' Factory method. Asynchronously creates a new <see cref="DocClassEditCollGetter"/> unit of objects.
        ''' </summary>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub NewDocClassEditCollGetter(callback As EventHandler(Of DataPortalResult(Of DocClassEditCollGetter)))
            ' DataPortal_Fetch is used as ReadOnlyBase<T> doesn't allow the use of DataPortal_Create.
            DataPortal.BeginFetch(Of DocClassEditCollGetter)(True, Sub(o, e)
                If e.Error IsNot Nothing Then
                    Throw e.Error
                End If
                If Not UserNVL.IsCached Then
                    UserNVL.SetCache(e.Object.UserNVL)
                End If
                callback(o, e)
            End Sub)
        End Sub

        ''' <summary>
        ''' Factory method. Asynchronously loads a <see cref="DocClassEditCollGetter"/> unit of objects.
        ''' </summary>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub GetDocClassEditCollGetter(callback As EventHandler(Of DataPortalResult(Of DocClassEditCollGetter)))
            DataPortal.BeginFetch(Of DocClassEditCollGetter)(False, Sub(o, e)
                If e.Error IsNot Nothing Then
                    Throw e.Error
                End If
                If Not UserNVL.IsCached Then
                    UserNVL.SetCache(e.Object.UserNVL)
                End If
                callback(o, e)
            End Sub)
        End Sub

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="DocClassEditCollGetter"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Unit of Work. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.
        End Sub

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Creates or loads a <see cref="DocClassEditCollGetter"/> unit of objects.
        ''' </summary>
        ''' <param name="createDocClassEditColl">if set to <c>True</c> creates a DocClassEditColl; otherwise fetches a DocClassEditColl.</param>
        Protected Overloads Sub DataPortal_Fetch(createDocClassEditColl As Boolean)
            If createDocClassEditColl Then
                LoadProperty(DocClassEditCollProperty, DocClassEditColl.NewDocClassEditColl())
            Else
                LoadProperty(DocClassEditCollProperty, DocClassEditColl.GetDocClassEditColl())
            End If
            LoadProperty(UserNVLProperty, UserNVL.GetUserNVL())
        End Sub

        #End Region

    End Class
End Namespace
