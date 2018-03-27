//  This file was generated by CSLA Object Generator - CslaGenFork v4.5
//
// Filename:    Role
// ObjectType:  Role
// CSLAType:    EditableRoot

using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using DocStore.Business.Util;
using Csla.Rules;
using Csla.Rules.CommonRules;
using DocStore.Business.Security;

namespace DocStore.Business.Admin
{

    /// <summary>
    /// Role (editable root object).<br/>
    /// This is a generated <see cref="Role"/> business object.
    /// </summary>
    [Serializable]
    public partial class Role : BusinessBase<Role>
    {

        #region Static Fields

        private static int _lastId;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="RoleID"/> property.
        /// </summary>
        [NotUndoable]
        public static readonly PropertyInfo<int> RoleIDProperty = RegisterProperty<int>(p => p.RoleID, "Role ID");
        /// <summary>
        /// Gets the Role ID.
        /// </summary>
        /// <value>The Role ID.</value>
        public int RoleID
        {
            get { return GetProperty(RoleIDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="RoleName"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> RoleNameProperty = RegisterProperty<string>(p => p.RoleName, "Role Name");
        /// <summary>
        /// Gets or sets the Role Name.
        /// </summary>
        /// <value>The Role Name.</value>
        public string RoleName
        {
            get { return GetProperty(RoleNameProperty); }
            set { SetProperty(RoleNameProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="IsActive"/> property.
        /// </summary>
        public static readonly PropertyInfo<bool> IsActiveProperty = RegisterProperty<bool>(p => p.IsActive, "IsActive");
        /// <summary>
        /// Gets or sets the active or deleted state.
        /// </summary>
        /// <value><c>true</c> if IsActive; otherwise, <c>false</c>.</value>
        public bool IsActive
        {
            get { return GetProperty(IsActiveProperty); }
            set { SetProperty(IsActiveProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="CreateDate"/> property.
        /// </summary>
        public static readonly PropertyInfo<SmartDate> CreateDateProperty = RegisterProperty<SmartDate>(p => p.CreateDate, "Create Date");
        /// <summary>
        /// Gets the Create Date.
        /// </summary>
        /// <value>The Create Date.</value>
        public SmartDate CreateDate
        {
            get { return GetProperty(CreateDateProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="CreateUserID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> CreateUserIDProperty = RegisterProperty<int>(p => p.CreateUserID, "Create User ID");
        /// <summary>
        /// Gets the Create User ID.
        /// </summary>
        /// <value>The Create User ID.</value>
        public int CreateUserID
        {
            get { return GetProperty(CreateUserIDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="ChangeDate"/> property.
        /// </summary>
        public static readonly PropertyInfo<SmartDate> ChangeDateProperty = RegisterProperty<SmartDate>(p => p.ChangeDate, "Change Date");
        /// <summary>
        /// Gets the Change Date.
        /// </summary>
        /// <value>The Change Date.</value>
        public SmartDate ChangeDate
        {
            get { return GetProperty(ChangeDateProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="ChangeUserID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> ChangeUserIDProperty = RegisterProperty<int>(p => p.ChangeUserID, "Change User ID");
        /// <summary>
        /// Gets the Change User ID.
        /// </summary>
        /// <value>The Change User ID.</value>
        public int ChangeUserID
        {
            get { return GetProperty(ChangeUserIDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="RowVersion"/> property.
        /// </summary>
        [NotUndoable]
        public static readonly PropertyInfo<byte[]> RowVersionProperty = RegisterProperty<byte[]>(p => p.RowVersion, "Row Version");
        /// <summary>
        /// Gets the Row Version.
        /// </summary>
        /// <value>The Row Version.</value>
        public byte[] RowVersion
        {
            get { return GetProperty(RowVersionProperty); }
        }

        /// <summary>
        /// Gets the Create User Name.
        /// </summary>
        /// <value>The Create User Name.</value>
        public string CreateUserName
        {
            get
            {
                var result = string.Empty;
                if (UserNVL.GetUserNVL().ContainsKey(CreateUserID))
                    result = UserNVL.GetUserNVL().GetItemByKey(CreateUserID).Value;
                return result;
            }
        }

        /// <summary>
        /// Gets the Change User Name.
        /// </summary>
        /// <value>The Change User Name.</value>
        public string ChangeUserName
        {
            get
            {
                var result = string.Empty;
                if (UserNVL.GetUserNVL().ContainsKey(ChangeUserID))
                    result = UserNVL.GetUserNVL().GetItemByKey(ChangeUserID).Value;
                return result;
            }
        }

        #endregion

        #region BusinessBase<T> overrides

        /// <summary>
        /// Returns a string that represents the current <see cref="Role"/>
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        public override string ToString()
        {
            // Return the Primary Key as a string
            return RoleName.ToString();
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="Role"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="Role"/> object.</returns>
        public static Role NewRole()
        {
            return DataPortal.Create<Role>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="Role"/> object, based on given parameters.
        /// </summary>
        /// <param name="roleID">The RoleID parameter of the Role to fetch.</param>
        /// <returns>A reference to the fetched <see cref="Role"/> object.</returns>
        public static Role GetRole(int roleID)
        {
            return DataPortal.Fetch<Role>(roleID);
        }

        /// <summary>
        /// Factory method. Deletes a <see cref="Role"/> object, based on given parameters.
        /// </summary>
        /// <param name="roleID">The RoleID of the Role to delete.</param>
        public static void DeleteRole(int roleID)
        {
            DataPortal.Delete<Role>(roleID);
        }

        /// <summary>
        /// Factory method. Undeletes a <see cref="Role"/> object, based on given parameters.
        /// </summary>
        /// <param name="roleID">The RoleID of the Role to undelete.</param>
        /// <returns>A reference to the undeleted <see cref="Role"/> object.</returns>
        public static Role UndeleteRole(int roleID)
        {
            var obj = DataPortal.Fetch<Role>(roleID);
            obj.IsActive = true;
            return obj.Save();
        }

        /// <summary>
        /// Factory method. Asynchronously creates a new <see cref="Role"/> object.
        /// </summary>
        /// <param name="callback">The completion callback method.</param>
        public static void NewRole(EventHandler<DataPortalResult<Role>> callback)
        {
            DataPortal.BeginCreate<Role>(callback);
        }

        /// <summary>
        /// Factory method. Asynchronously loads a <see cref="Role"/> object, based on given parameters.
        /// </summary>
        /// <param name="roleID">The RoleID parameter of the Role to fetch.</param>
        /// <param name="callback">The completion callback method.</param>
        public static void GetRole(int roleID, EventHandler<DataPortalResult<Role>> callback)
        {
            DataPortal.BeginFetch<Role>(roleID, callback);
        }

        /// <summary>
        /// Factory method. Asynchronously deletes a <see cref="Role"/> object, based on given parameters.
        /// </summary>
        /// <param name="roleID">The RoleID of the Role to delete.</param>
        /// <param name="callback">The completion callback method.</param>
        public static void DeleteRole(int roleID, EventHandler<DataPortalResult<Role>> callback)
        {
            DataPortal.BeginDelete<Role>(roleID, callback);
        }

        /// <summary>
        /// Factory method. Asynchronously undeletes a <see cref="Role"/> object, based on given parameters.
        /// </summary>
        /// <param name="roleID">The RoleID of the Role to undelete.</param>
        /// <param name="callback">The completion callback method.</param>
        public static void UndeleteRole(int roleID, EventHandler<DataPortalResult<Role>> callback)
        {
            var obj = new Role();
            DataPortal.BeginFetch<Role>(roleID, (o, e) =>
                {
                    if (e.Error != null)
                        throw e.Error;
                    else
                        obj = e.Object;
                });
            obj.IsActive = true;
            obj.BeginSave(callback);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Role"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public Role()
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
            BusinessRules.AddRule(typeof (Role), new IsInRole(AuthorizationActions.CreateObject, "Manager"));
            BusinessRules.AddRule(typeof (Role), new IsInRole(AuthorizationActions.GetObject, "User"));
            BusinessRules.AddRule(typeof (Role), new IsInRole(AuthorizationActions.EditObject, "Manager"));
            BusinessRules.AddRule(typeof (Role), new IsInRole(AuthorizationActions.DeleteObject, "Admin"));

            AddObjectAuthorizationRulesExtend();
        }

        /// <summary>
        /// Allows the set up of custom object authorization rules.
        /// </summary>
        static partial void AddObjectAuthorizationRulesExtend();

        /// <summary>
        /// Checks if the current user can create a new Role object.
        /// </summary>
        /// <returns><c>true</c> if the user can create a new object; otherwise, <c>false</c>.</returns>
        public static bool CanAddObject()
        {
            return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.CreateObject, typeof(Role));
        }

        /// <summary>
        /// Checks if the current user can retrieve Role's properties.
        /// </summary>
        /// <returns><c>true</c> if the user can read the object; otherwise, <c>false</c>.</returns>
        public static bool CanGetObject()
        {
            return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.GetObject, typeof(Role));
        }

        /// <summary>
        /// Checks if the current user can change Role's properties.
        /// </summary>
        /// <returns><c>true</c> if the user can update the object; otherwise, <c>false</c>.</returns>
        public static bool CanEditObject()
        {
            return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.EditObject, typeof(Role));
        }

        /// <summary>
        /// Checks if the current user can delete a Role object.
        /// </summary>
        /// <returns><c>true</c> if the user can delete the object; otherwise, <c>false</c>.</returns>
        public static bool CanDeleteObject()
        {
            return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.DeleteObject, typeof(Role));
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="Role"/> object properties.
        /// </summary>
        [RunLocal]
        protected override void DataPortal_Create()
        {
            LoadProperty(RoleIDProperty, System.Threading.Interlocked.Decrement(ref _lastId));
            LoadProperty(CreateDateProperty, new SmartDate(DateTime.Now));
            LoadProperty(CreateUserIDProperty, UserInformation.UserId);
            LoadProperty(ChangeDateProperty, ReadProperty(CreateDateProperty));
            LoadProperty(ChangeUserIDProperty, ReadProperty(CreateUserIDProperty));
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.DataPortal_Create();
        }

        /// <summary>
        /// Loads a <see cref="Role"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="roleID">The Role ID.</param>
        protected void DataPortal_Fetch(int roleID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager(Database.DocStoreConnection, false))
            {
                using (var cmd = new SqlCommand("GetRole", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RoleID", roleID).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd, roleID);
                    OnFetchPre(args);
                    Fetch(cmd);
                    OnFetchPost(args);
                }
            }
            // check all object rules and property rules
            BusinessRules.CheckRules();
        }

        private void Fetch(SqlCommand cmd)
        {
            using (var dr = new SafeDataReader(cmd.ExecuteReader()))
            {
                if (dr.Read())
                {
                    Fetch(dr);
                }
            }
        }

        /// <summary>
        /// Loads a <see cref="Role"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(RoleIDProperty, dr.GetInt32("RoleID"));
            LoadProperty(RoleNameProperty, dr.GetString("RoleName"));
            LoadProperty(IsActiveProperty, dr.GetBoolean("IsActive"));
            LoadProperty(CreateDateProperty, dr.GetSmartDate("CreateDate", true));
            LoadProperty(CreateUserIDProperty, dr.GetInt32("CreateUserID"));
            LoadProperty(ChangeDateProperty, dr.GetSmartDate("ChangeDate", true));
            LoadProperty(ChangeUserIDProperty, dr.GetInt32("ChangeUserID"));
            LoadProperty(RowVersionProperty, dr.GetValue("RowVersion") as byte[]);
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Inserts a new <see cref="Role"/> object in the database.
        /// </summary>
        protected override void DataPortal_Insert()
        {
            SimpleAuditTrail();
            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager(Database.DocStoreConnection, false))
            {
                using (var cmd = new SqlCommand("AddRole", ctx.Connection))
                {
                    cmd.Transaction = ctx.Transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RoleID", ReadProperty(RoleIDProperty)).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@RoleName", ReadProperty(RoleNameProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@IsActive", ReadProperty(IsActiveProperty)).DbType = DbType.Boolean;
                    cmd.Parameters.AddWithValue("@CreateDate", ReadProperty(CreateDateProperty).DBValue).DbType = DbType.DateTime2;
                    cmd.Parameters.AddWithValue("@CreateUserID", ReadProperty(CreateUserIDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@ChangeDate", ReadProperty(ChangeDateProperty).DBValue).DbType = DbType.DateTime2;
                    cmd.Parameters.AddWithValue("@ChangeUserID", ReadProperty(ChangeUserIDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    var args = new DataPortalHookArgs(cmd);
                    OnInsertPre(args);
                    cmd.ExecuteNonQuery();
                    OnInsertPost(args);
                    LoadProperty(RoleIDProperty, (int) cmd.Parameters["@RoleID"].Value);
                    LoadProperty(RowVersionProperty, (byte[]) cmd.Parameters["@NewRowVersion"].Value);
                }
                ctx.Commit();
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="Role"/> object.
        /// </summary>
        protected override void DataPortal_Update()
        {
            SimpleAuditTrail();
            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager(Database.DocStoreConnection, false))
            {
                using (var cmd = new SqlCommand("UpdateRole", ctx.Connection))
                {
                    cmd.Transaction = ctx.Transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RoleID", ReadProperty(RoleIDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@RoleName", ReadProperty(RoleNameProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@IsActive", ReadProperty(IsActiveProperty)).DbType = DbType.Boolean;
                    cmd.Parameters.AddWithValue("@ChangeDate", ReadProperty(ChangeDateProperty).DBValue).DbType = DbType.DateTime2;
                    cmd.Parameters.AddWithValue("@ChangeUserID", ReadProperty(ChangeUserIDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@RowVersion", ReadProperty(RowVersionProperty)).DbType = DbType.Binary;
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    var args = new DataPortalHookArgs(cmd);
                    OnUpdatePre(args);
                    cmd.ExecuteNonQuery();
                    OnUpdatePost(args);
                    LoadProperty(RowVersionProperty, (byte[]) cmd.Parameters["@NewRowVersion"].Value);
                }
                ctx.Commit();
            }
        }

        private void SimpleAuditTrail()
        {
            LoadProperty(ChangeDateProperty, DateTime.Now);
            LoadProperty(ChangeUserIDProperty, UserInformation.UserId);
            OnPropertyChanged("ChangeUserName");
            if (IsNew)
            {
                LoadProperty(CreateDateProperty, ReadProperty(ChangeDateProperty));
                LoadProperty(CreateUserIDProperty, ReadProperty(ChangeUserIDProperty));
                OnPropertyChanged("CreateUserName");
            }
        }

        /// <summary>
        /// Self deletes the <see cref="Role"/> object.
        /// </summary>
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(RoleID);
        }

        /// <summary>
        /// Deletes the <see cref="Role"/> object from database.
        /// </summary>
        /// <param name="roleID">The delete criteria.</param>
        protected void DataPortal_Delete(int roleID)
        {
            // audit the object, just in case soft delete is used on this object
            SimpleAuditTrail();
            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager(Database.DocStoreConnection, false))
            {
                using (var cmd = new SqlCommand("DeleteRole", ctx.Connection))
                {
                    cmd.Transaction = ctx.Transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RoleID", roleID).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd, roleID);
                    OnDeletePre(args);
                    cmd.ExecuteNonQuery();
                    OnDeletePost(args);
                }
                ctx.Commit();
            }
        }

        #endregion

        #region DataPortal Hooks

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
