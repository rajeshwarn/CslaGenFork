'  This file was generated by CSLA Object Generator - CslaGenFork v4.5
'
' Filename:    DocContentList
' ObjectType:  DocContentList
' CSLAType:    ReadOnlyCollection

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data
Imports DocStore.Business.Util
Imports UsingLibrary

Namespace DocStore.Business

    ''' <summary>
    ''' Collection of contents of this document (read only list).<br/>
    ''' This is a generated base class of <see cref="DocContentList"/> business object.
    ''' </summary>
    ''' <remarks>
    ''' This class is child of <see cref="Doc"/> editable root object.<br/>
    ''' The items of the collection are <see cref="DocContentInfo"/> objects.
    ''' </remarks>
    <Serializable>
    Public Partial Class DocContentList
#If WINFORMS Then
        Inherits ReadOnlyBindingListBase(Of DocContentList, DocContentInfo)
        Implements IHaveInterface, IHaveGenericInterface(Of DocContentList)
#Else
        Inherits ReadOnlyListBase(Of DocContentList, DocContentInfo)
        Implements IHaveInterface, IHaveGenericInterface(Of DocContentList)
#End If
    
        #Region " Collection Business Methods "

        ''' <summary>
        ''' Determines whether a <see cref="DocContentInfo"/> item is in the collection.
        ''' </summary>
        ''' <param name="docContentID">The DocContentID of the item to search for.</param>
        ''' <returns><c>True</c> if the DocContentInfo is a collection item; otherwise, <c>false</c>.</returns>
        Public Overloads Function Contains(docContentID As Integer) As Boolean
            For Each item As DocContentInfo In Me
                If item.DocContentID = docContentID Then
                    Return True
                End If
            Next
            Return False
        End Function

        #End Region

        #Region " Factory Methods "

        ''' <summary>
        ''' Factory method. Loads a <see cref="DocContentList"/> object from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        ''' <returns>A reference to the fetched <see cref="DocContentList"/> object.</returns>
        Friend Shared Function GetDocContentList(dr As SafeDataReader) As DocContentList
            Dim obj As DocContentList = New DocContentList()
            obj.Fetch(dr)
            Return obj
        End Function

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="DocContentList"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.

            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = False
            AllowNew = False
            AllowEdit = False
            AllowRemove = False
            RaiseListChangedEvents = rlce
        End Sub

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads all <see cref="DocContentList"/> collection items from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Fetch(dr As SafeDataReader)
            IsReadOnly = False
            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = False
            Dim args As New DataPortalHookArgs(dr)
            OnFetchPre(args)
            While dr.Read()
                Add(DocContentInfo.GetDocContentInfo(dr))
            End While
            OnFetchPost(args)
            RaiseListChangedEvents = rlce
            IsReadOnly = True
        End Sub

        #End Region

        #Region " DataPortal Hooks "

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

        #End Region

    End Class
End Namespace
