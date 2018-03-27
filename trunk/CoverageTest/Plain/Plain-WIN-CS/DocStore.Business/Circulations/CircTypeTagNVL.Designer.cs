//  This file was generated by CSLA Object Generator - CslaGenFork v4.5
//
// Filename:    CircTypeTagNVL
// ObjectType:  CircTypeTagNVL
// CSLAType:    NameValueList

using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using DocStore.Business.Util;

namespace DocStore.Business.Circulations
{

    /// <summary>
    /// Active tags for circulation types (name value list).<br/>
    /// This is a generated <see cref="CircTypeTagNVL"/> business object.
    /// </summary>
    [Serializable]
    public partial class CircTypeTagNVL : NameValueListBase<int, string>
    {

        #region Private Fields

        private static CircTypeTagNVL _list;

        #endregion

        #region Cache Management Methods

        /// <summary>
        /// Clears the in-memory CircTypeTagNVL cache so it is reloaded on the next request.
        /// </summary>
        public static void InvalidateCache()
        {
            _list = null;
        }

        /// <summary>
        /// Used by async loaders to load the cache.
        /// </summary>
        /// <param name="list">The list to cache.</param>
        internal static void SetCache(CircTypeTagNVL list)
        {
            _list = list;
        }

        internal static bool IsCached
        {
            get { return _list != null; }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="CircTypeTagNVL"/> object.
        /// </summary>
        /// <returns>A reference to the fetched <see cref="CircTypeTagNVL"/> object.</returns>
        public static CircTypeTagNVL GetCircTypeTagNVL()
        {
            if (_list == null)
                _list = DataPortal.Fetch<CircTypeTagNVL>();

            return _list;
        }

        /// <summary>
        /// Factory method. Asynchronously loads a <see cref="CircTypeTagNVL"/> object.
        /// </summary>
        /// <param name="callback">The completion callback method.</param>
        public static void GetCircTypeTagNVL(EventHandler<DataPortalResult<CircTypeTagNVL>> callback)
        {
            if (_list == null)
                DataPortal.BeginFetch<CircTypeTagNVL>((o, e) =>
                    {
                        _list = e.Object;
                        callback(o, e);
                    });
            else
                callback(null, new DataPortalResult<CircTypeTagNVL>(_list, null, null));
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CircTypeTagNVL"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public CircTypeTagNVL()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="CircTypeTagNVL"/> collection from the database or from the cache.
        /// </summary>
        protected void DataPortal_Fetch()
        {
            if (IsCached)
            {
                LoadCachedList();
                return;
            }

            using (var cn = new SqlConnection(Database.DocStoreConnection))
            {
                using (var cmd = new SqlCommand("GetCircTypeTagNVL", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    var args = new DataPortalHookArgs(cmd);
                    OnFetchPre(args);
                    LoadCollection(cmd);
                    OnFetchPost(args);
                }
            }
            _list = this;
        }

        private void LoadCachedList()
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            AddRange(_list);
            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
        }

        private void LoadCollection(SqlCommand cmd)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            using (var dr = new SafeDataReader(cmd.ExecuteReader()))
            {
                while (dr.Read())
                {
                    Add(new NameValuePair(
                        dr.GetInt32("CircTypeID"),
                        dr.GetString("CircTypeTag")));
                }
            }
            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
        }

        #endregion

        #region DataPortal Hooks

        /// <summary>
        /// Occurs after setting query parameters and before the fetch operation.
        /// </summary>
        partial void OnFetchPre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after the fetch operation (object or collection is fully loaded and set up).
        /// </summary>
        partial void OnFetchPost(DataPortalHookArgs args);

        #endregion

    }
}
