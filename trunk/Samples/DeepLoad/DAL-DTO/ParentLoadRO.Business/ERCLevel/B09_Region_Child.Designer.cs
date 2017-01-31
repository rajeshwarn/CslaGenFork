using System;
using Csla;
using ParentLoadRO.DataAccess.ERCLevel;

namespace ParentLoadRO.Business.ERCLevel
{

    /// <summary>
    /// B09_Region_Child (read only object).<br/>
    /// This is a generated base class of <see cref="B09_Region_Child"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="B08_Region"/> collection.
    /// </remarks>
    [Serializable]
    public partial class B09_Region_Child : ReadOnlyBase<B09_Region_Child>
    {

        #region State Fields

        [NotUndoable]
        [NonSerialized]
        internal int region_ID1 = 0;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Region_Child_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Region_Child_NameProperty = RegisterProperty<string>(p => p.Region_Child_Name, "Region Child Name");
        /// <summary>
        /// Gets the Region Child Name.
        /// </summary>
        /// <value>The Region Child Name.</value>
        public string Region_Child_Name
        {
            get { return GetProperty(Region_Child_NameProperty); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="B09_Region_Child"/> object from the given B09_Region_ChildDto.
        /// </summary>
        /// <param name="data">The <see cref="B09_Region_ChildDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="B09_Region_Child"/> object.</returns>
        internal static B09_Region_Child GetB09_Region_Child(B09_Region_ChildDto data)
        {
            B09_Region_Child obj = new B09_Region_Child();
            obj.Fetch(data);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="B09_Region_Child"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public B09_Region_Child()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="B09_Region_Child"/> object from the given <see cref="B09_Region_ChildDto"/>.
        /// </summary>
        /// <param name="data">The B09_Region_ChildDto to use.</param>
        private void Fetch(B09_Region_ChildDto data)
        {
            // Value properties
            LoadProperty(Region_Child_NameProperty, data.Region_Child_Name);
            // parent properties
            region_ID1 = data.Parent_Region_ID;
            var args = new DataPortalHookArgs(data);
            OnFetchRead(args);
        }

        #endregion

        #region DataPortal Hooks

        /// <summary>
        /// Occurs after the low level fetch operation, before the data reader is destroyed.
        /// </summary>
        partial void OnFetchRead(DataPortalHookArgs args);

        #endregion

    }
}
