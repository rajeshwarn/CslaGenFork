using System;
using System.Data;
using Csla;

namespace ParentLoadSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for F03_Continent_ReChild type
    /// </summary>
    public partial interface IF03_Continent_ReChildDal
    {

        /// <summary>
        /// Inserts a new F03_Continent_ReChild object in the database.
        /// </summary>
        /// <param name="continent_ID">The parent Continent ID.</param>
        /// <param name="continent_Child_Name">The Continent Child Name.</param>
        
        void Insert(int continent_ID, string continent_Child_Name);

        /// <summary>
        /// Updates in the database all changes made to the F03_Continent_ReChild object.
        /// </summary>
        /// <param name="continent_ID">The parent Continent ID.</param>
        /// <param name="continent_Child_Name">The Continent Child Name.</param>
        
        void Update(int continent_ID, string continent_Child_Name);

        /// <summary>
        /// Deletes the F03_Continent_ReChild object from database.
        /// </summary>
        /// <param name="continent_ID">The parent Continent ID.</param>
        void Delete(int continent_ID);
    }
}
