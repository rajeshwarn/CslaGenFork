using System;
using Csla;
using ParentLoadRO.DataAccess.ERLevel;

namespace ParentLoadRO.Business.ERLevel
{

    /// <summary>
    /// A07_Country_Child (read only object).<br/>
    /// This is a generated base class of <see cref="A07_Country_Child"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="A06_Country"/> collection.
    /// </remarks>
    [Serializable]
    public partial class A07_Country_Child : ReadOnlyBase<A07_Country_Child>
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
        public static readonly PropertyInfo<string> Country_Child_NameProperty = RegisterProperty<string>(p => p.Country_Child_Name, "Country Child Name");
        /// <summary>
        /// Gets the Country Child Name.
        /// </summary>
        /// <value>The Country Child Name.</value>
        public string Country_Child_Name
        {
            get { return GetProperty(Country_Child_NameProperty); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="A07_Country_Child"/> object from the given A07_Country_ChildDto.
        /// </summary>
        /// <param name="data">The <see cref="A07_Country_ChildDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="A07_Country_Child"/> object.</returns>
        internal static A07_Country_Child GetA07_Country_Child(A07_Country_ChildDto data)
        {
            A07_Country_Child obj = new A07_Country_Child();
            obj.Fetch(data);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="A07_Country_Child"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public A07_Country_Child()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="A07_Country_Child"/> object from the given <see cref="A07_Country_ChildDto"/>.
        /// </summary>
        /// <param name="data">The A07_Country_ChildDto to use.</param>
        private void Fetch(A07_Country_ChildDto data)
        {
            // Value properties
            LoadProperty(Country_Child_NameProperty, data.Country_Child_Name);
            // parent properties
            country_ID1 = data.Parent_Country_ID;
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
