using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using ParentLoadSoftDelete.DataAccess;
using ParentLoadSoftDelete.DataAccess.ERLevel;

namespace ParentLoadSoftDelete.DataAccess.Sql.ERLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IE03_Continent_ChildDal"/>
    /// </summary>
    public partial class E03_Continent_ChildDal : IE03_Continent_ChildDal
    {
        /// <summary>
        /// Inserts a new E03_Continent_Child object in the database.
        /// </summary>
        /// <param name="continent_ID1">The parent Continent ID1.</param>
        /// <param name="continent_Child_Name">The Continent Child Name.</param>
        public void Insert(int continent_ID1, string continent_Child_Name)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddE03_Continent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID1", continent_ID1).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Continent_Child_Name", continent_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the E03_Continent_Child object.
        /// </summary>
        /// <param name="continent_ID1">The parent Continent ID1.</param>
        /// <param name="continent_Child_Name">The Continent Child Name.</param>
        public void Update(int continent_ID1, string continent_Child_Name)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateE03_Continent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID1", continent_ID1).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Continent_Child_Name", continent_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("E03_Continent_Child");
                }
            }
        }

        /// <summary>
        /// Deletes the E03_Continent_Child object from database.
        /// </summary>
        /// <param name="continent_ID1">The parent Continent ID1.</param>
        public void Delete(int continent_ID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteE03_Continent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID1", continent_ID1).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
