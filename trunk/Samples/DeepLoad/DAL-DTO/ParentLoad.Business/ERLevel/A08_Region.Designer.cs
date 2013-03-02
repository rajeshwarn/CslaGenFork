using System;
using Csla;
using ParentLoad.DataAccess;
using ParentLoad.DataAccess.ERLevel;

namespace ParentLoad.Business.ERLevel
{

    /// <summary>
    /// A08_Region (editable child object).<br/>
    /// This is a generated base class of <see cref="A08_Region"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="A09_CityObjects"/> of type <see cref="A09_CityColl"/> (1:M relation to <see cref="A10_City"/>)<br/>
    /// This class is an item of <see cref="A07_RegionColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class A08_Region : BusinessBase<A08_Region>
    {

        #region Static Fields

        private static int _lastID;

        #endregion

        #region State Fields

        [NotUndoable]
        [NonSerialized]
        internal int parent_Country_ID = 0;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Region_ID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> Region_IDProperty = RegisterProperty<int>(p => p.Region_ID, "Region ID");
        /// <summary>
        /// Gets the Region ID.
        /// </summary>
        /// <value>The Region ID.</value>
        public int Region_ID
        {
            get { return GetProperty(Region_IDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Region_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Region_NameProperty = RegisterProperty<string>(p => p.Region_Name, "Region Name");
        /// <summary>
        /// Gets or sets the Region Name.
        /// </summary>
        /// <value>The Region Name.</value>
        public string Region_Name
        {
            get { return GetProperty(Region_NameProperty); }
            set { SetProperty(Region_NameProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="A09_Region_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<A09_Region_Child> A09_Region_SingleObjectProperty = RegisterProperty<A09_Region_Child>(p => p.A09_Region_SingleObject, "A09 Region Single Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the A09 Region Single Object ("parent load" child property).
        /// </summary>
        /// <value>The A09 Region Single Object.</value>
        public A09_Region_Child A09_Region_SingleObject
        {
            get { return GetProperty(A09_Region_SingleObjectProperty); }
            private set { LoadProperty(A09_Region_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="A09_Region_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<A09_Region_ReChild> A09_Region_ASingleObjectProperty = RegisterProperty<A09_Region_ReChild>(p => p.A09_Region_ASingleObject, "A09 Region ASingle Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the A09 Region ASingle Object ("parent load" child property).
        /// </summary>
        /// <value>The A09 Region ASingle Object.</value>
        public A09_Region_ReChild A09_Region_ASingleObject
        {
            get { return GetProperty(A09_Region_ASingleObjectProperty); }
            private set { LoadProperty(A09_Region_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="A09_CityObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<A09_CityColl> A09_CityObjectsProperty = RegisterProperty<A09_CityColl>(p => p.A09_CityObjects, "A09 City Objects", RelationshipTypes.Child);
        /// <summary>
        /// Gets the A09 City Objects ("parent load" child property).
        /// </summary>
        /// <value>The A09 City Objects.</value>
        public A09_CityColl A09_CityObjects
        {
            get { return GetProperty(A09_CityObjectsProperty); }
            private set { LoadProperty(A09_CityObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="A08_Region"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="A08_Region"/> object.</returns>
        internal static A08_Region NewA08_Region()
        {
            return DataPortal.CreateChild<A08_Region>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="A08_Region"/> object from the given A08_RegionDto.
        /// </summary>
        /// <param name="data">The <see cref="A08_RegionDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="A08_Region"/> object.</returns>
        internal static A08_Region GetA08_Region(A08_RegionDto data)
        {
            A08_Region obj = new A08_Region();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(data);
            obj.LoadProperty(A09_CityObjectsProperty, A09_CityColl.NewA09_CityColl());
            obj.MarkOld();
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="A08_Region"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private A08_Region()
        {
            // Prevent direct creation

            // show the framework that this is a child object
            MarkAsChild();
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="A08_Region"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void Child_Create()
        {
            LoadProperty(Region_IDProperty, System.Threading.Interlocked.Decrement(ref _lastID));
            LoadProperty(A09_Region_SingleObjectProperty, DataPortal.CreateChild<A09_Region_Child>());
            LoadProperty(A09_Region_ASingleObjectProperty, DataPortal.CreateChild<A09_Region_ReChild>());
            LoadProperty(A09_CityObjectsProperty, DataPortal.CreateChild<A09_CityColl>());
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.Child_Create();
        }

        /// <summary>
        /// Loads a <see cref="A08_Region"/> object from the given <see cref="A08_RegionDto"/>.
        /// </summary>
        /// <param name="data">The A08_RegionDto to use.</param>
        private void Fetch(A08_RegionDto data)
        {
            // Value properties
            LoadProperty(Region_IDProperty, data.Region_ID);
            LoadProperty(Region_NameProperty, data.Region_Name);
            // parent properties
            parent_Country_ID = data.Parent_Country_ID;
            var args = new DataPortalHookArgs(data);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child <see cref="A09_Region_Child"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(A09_Region_Child child)
        {
            LoadProperty(A09_Region_SingleObjectProperty, child);
        }

        /// <summary>
        /// Loads child <see cref="A09_Region_ReChild"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(A09_Region_ReChild child)
        {
            LoadProperty(A09_Region_ASingleObjectProperty, child);
        }

        /// <summary>
        /// Inserts a new <see cref="A08_Region"/> object in the database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Insert(A06_Country parent)
        {
            var dto = new A08_RegionDto();
            dto.Parent_Country_ID = parent.Country_ID;
            dto.Region_Name = Region_Name;
            using (var dalManager = DalFactoryParentLoad.GetManager())
            {
                var args = new DataPortalHookArgs(dto);
                OnInsertPre(args);
                var dal = dalManager.GetProvider<IA08_RegionDal>();
                using (BypassPropertyChecks)
                {
                    var resultDto = dal.Insert(dto);
                    LoadProperty(Region_IDProperty, resultDto.Region_ID);
                    args = new DataPortalHookArgs(resultDto);
                }
                OnInsertPost(args);
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="A08_Region"/> object.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Update()
        {
            var dto = new A08_RegionDto();
            dto.Region_ID = Region_ID;
            dto.Region_Name = Region_Name;
            using (var dalManager = DalFactoryParentLoad.GetManager())
            {
                var args = new DataPortalHookArgs(dto);
                OnUpdatePre(args);
                var dal = dalManager.GetProvider<IA08_RegionDal>();
                using (BypassPropertyChecks)
                {
                    var resultDto = dal.Update(dto);
                    args = new DataPortalHookArgs(resultDto);
                }
                OnUpdatePost(args);
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
            }
        }

        /// <summary>
        /// Self deletes the <see cref="A08_Region"/> object from database.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_DeleteSelf()
        {
            using (var dalManager = DalFactoryParentLoad.GetManager())
            {
                var args = new DataPortalHookArgs();
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
                OnDeletePre(args);
                var dal = dalManager.GetProvider<IA08_RegionDal>();
                using (BypassPropertyChecks)
                {
                    dal.Delete(ReadProperty(Region_IDProperty));
                }
                OnDeletePost(args);
            }
        }

        #endregion

        #region Pseudo Events

        /// <summary>
        /// Occurs after setting all defaults for object creation.
        /// </summary>
        partial void OnCreate(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Delete, after setting query parameters and before the delete operation.
        /// </summary>
        partial void OnDeletePre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Delete, after the delete operation, before Commit().
        /// </summary>
        partial void OnDeletePost(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after setting query parameters and before the fetch operation.
        /// </summary>
        partial void OnFetchPre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after the fetch operation (object or collection is fully loaded and set up).
        /// </summary>
        partial void OnFetchPost(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after the low level fetch operation, before the data reader is destroyed.
        /// </summary>
        partial void OnFetchRead(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after setting query parameters and before the update operation.
        /// </summary>
        partial void OnUpdatePre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Insert, after the update operation, before setting back row identifiers (RowVersion) and Commit().
        /// </summary>
        partial void OnUpdatePost(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Insert, after setting query parameters and before the insert operation.
        /// </summary>
        partial void OnInsertPre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Insert, after the insert operation, before setting back row identifiers (ID and RowVersion) and Commit().
        /// </summary>
        partial void OnInsertPost(DataPortalHookArgs args);

        #endregion

    }
}