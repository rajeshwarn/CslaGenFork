using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Rules;
using Csla.Rules.CommonRules;
using UsingLibrary;

namespace TestProject.Business
{

    /// <summary>
    /// Document type basic information (read only object).<br/>
    /// This is a generated base class of <see cref="DocTypeInfo"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="DocTypeList"/> collection.
    /// This is a remark
    /// </remarks>
    [Attributable]
    [Serializable]
    public partial class DocTypeInfo : ReadOnlyBase<DocTypeInfo>, IHaveInterface
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="DocTypeID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> DocTypeIDProperty = RegisterProperty<int>(p => p.DocTypeID, "Doc Type ID", -1);
        /// <summary>
        /// Gets the Doc Type ID.
        /// </summary>
        /// <value>The Doc Type ID.</value>
        public int DocTypeID
        {
            get { return GetProperty(DocTypeIDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="DocTypeName"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> DocTypeNameProperty = RegisterProperty<string>(p => p.DocTypeName, "Doc Type Name");
        /// <summary>
        /// Gets the Doc Type Name.
        /// </summary>
        /// <value>The Doc Type Name.</value>
        public string DocTypeName
        {
            get { return GetProperty(DocTypeNameProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="IsActive"/> property.
        /// </summary>
        public static readonly PropertyInfo<bool> IsActiveProperty = RegisterProperty<bool>(p => p.IsActive, "IsActive");
        /// <summary>
        /// Gets the active or deleted state.
        /// </summary>
        /// <value><c>true</c> if IsActive; otherwise, <c>false</c>.</value>
        public bool IsActive
        {
            get { return GetProperty(IsActiveProperty); }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DocTypeInfo"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public DocTypeInfo()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Object Authorization

        /// <summary>
        /// Adds the object authorization rules.
        /// </summary>
        protected static void AddObjectAuthorizationRules()
        {
            BusinessRules.AddRule(typeof (DocTypeInfo), new IsInRole(AuthorizationActions.GetObject, "User"));

            AddObjectAuthorizationRulesExtend();
        }

        /// <summary>
        /// Allows the set up of custom object authorization rules.
        /// </summary>
        static partial void AddObjectAuthorizationRulesExtend();

        /// <summary>
        /// Checks if the current user can retrieve DocTypeInfo's properties.
        /// </summary>
        /// <returns><c>true</c> if the user can read the object; otherwise, <c>false</c>.</returns>
        public static bool CanGetObject()
        {
            return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.GetObject, typeof(DocTypeInfo));
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="DocTypeInfo"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Child_Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(DocTypeIDProperty, dr.GetInt32("DocTypeID"));
            LoadProperty(DocTypeNameProperty, dr.GetString("DocTypeName"));
            LoadProperty(IsActiveProperty, dr.GetBoolean("IsActive"));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
            // check all object rules and property rules
            BusinessRules.CheckRules();
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