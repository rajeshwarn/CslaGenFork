using System;
using Csla;
using ParentLoadSoftDelete.DataAccess;
using ParentLoadSoftDelete.DataAccess.ERLevel;

namespace ParentLoadSoftDelete.Business.ERLevel
{

    /// <summary>
    /// E07_Country_Child (editable child object).<br/>
    /// This is a generated base class of <see cref="E07_Country_Child"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="E06_Country"/> collection.
    /// </remarks>
    [Serializable]
    public partial class E07_Country_Child : BusinessBase<E07_Country_Child>
    {

        #region State Fields

        [NotUndoable]
        [NonSerialized]
        internal int country_ID1 = 0;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Country_Child_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Country_Child_NameProperty = RegisterProperty<string>(p => p.Country_Child_Name, "Regions Child Name");
        /// <summary>
        /// Gets or sets the Regions Child Name.
        /// </summary>
        /// <value>The Regions Child Name.</value>
        public string Country_Child_Name
        {
            get { return GetProperty(Country_Child_NameProperty); }
            set { SetProperty(Country_Child_NameProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="E07_Country_Child"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="E07_Country_Child"/> object.</returns>
        internal static E07_Country_Child NewE07_Country_Child()
        {
            return DataPortal.CreateChild<E07_Country_Child>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="E07_Country_Child"/> object from the given E07_Country_ChildDto.
        /// </summary>
        /// <param name="data">The <see cref="E07_Country_ChildDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="E07_Country_Child"/> object.</returns>
        internal static E07_Country_Child GetE07_Country_Child(E07_Country_ChildDto data)
        {
            E07_Country_Child obj = new E07_Country_Child();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(data);
            obj.MarkOld();
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="E07_Country_Child"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private E07_Country_Child()
        {
            // Prevent direct creation

            // show the framework that this is a child object
            MarkAsChild();
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="E07_Country_Child"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void Child_Create()
        {
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.Child_Create();
        }

        /// <summary>
        /// Loads a <see cref="E07_Country_Child"/> object from the given <see cref="E07_Country_ChildDto"/>.
        /// </summary>
        /// <param name="data">The E07_Country_ChildDto to use.</param>
        private void Fetch(E07_Country_ChildDto data)
        {
            // Value properties
            LoadProperty(Country_Child_NameProperty, data.Country_Child_Name);
            // parent properties
            country_ID1 = data.Parent_Country_ID;
            var args = new DataPortalHookArgs(data);
            OnFetchRead(args);
        }

        /// <summary>
        /// Inserts a new <see cref="E07_Country_Child"/> object in the database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Insert(E06_Country parent)
        {
            var dto = new E07_Country_ChildDto();
            dto.Parent_Country_ID = parent.Country_ID;
            dto.Country_Child_Name = Country_Child_Name;
            using (var dalManager = DalFactoryParentLoadSoftDelete.GetManager())
            {
                var args = new DataPortalHookArgs(dto);
                OnInsertPre(args);
                var dal = dalManager.GetProvider<IE07_Country_ChildDal>();
                using (BypassPropertyChecks)
                {
                    var resultDto = dal.Insert(dto);
                    args = new DataPortalHookArgs(resultDto);
                }
                OnInsertPost(args);
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="E07_Country_Child"/> object.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Update(E06_Country parent)
        {
            if (!IsDirty)
                return;

            var dto = new E07_Country_ChildDto();
            dto.Parent_Country_ID = parent.Country_ID;
            dto.Country_Child_Name = Country_Child_Name;
            using (var dalManager = DalFactoryParentLoadSoftDelete.GetManager())
            {
                var args = new DataPortalHookArgs(dto);
                OnUpdatePre(args);
                var dal = dalManager.GetProvider<IE07_Country_ChildDal>();
                using (BypassPropertyChecks)
                {
                    var resultDto = dal.Update(dto);
                    args = new DataPortalHookArgs(resultDto);
                }
                OnUpdatePost(args);
            }
        }

        /// <summary>
        /// Self deletes the <see cref="E07_Country_Child"/> object from database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_DeleteSelf(E06_Country parent)
        {
            using (var dalManager = DalFactoryParentLoadSoftDelete.GetManager())
            {
                var args = new DataPortalHookArgs();
                OnDeletePre(args);
                var dal = dalManager.GetProvider<IE07_Country_ChildDal>();
                using (BypassPropertyChecks)
                {
                    dal.Delete(parent.Country_ID);
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
