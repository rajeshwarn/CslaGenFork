using System;
using System.Data;
using Csla;

namespace ParentLoadSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for F06_Country type
    /// </summary>
    public partial interface IF06_CountryDal
    {

        /// <summary>
        /// Inserts a new F06_Country object in the database.
        /// </summary>
        /// <param name="subContinent_ID">The parent Sub Continent ID.</param>
        /// <param name="country_ID">The Country ID.</param>
        /// <param name="country_Name">The Country Name.</param>
        
        void Insert(int subContinent_ID, out int country_ID, string country_Name);

        /// <summary>
        /// Updates in the database all changes made to the F06_Country object.
        /// </summary>
        /// <param name="country_ID">The Country ID.</param>
        /// <param name="country_Name">The Country Name.</param>
        
        void Update(int country_ID, string country_Name);

        /// <summary>
        /// Deletes the F06_Country object from database.
        /// </summary>
        /// <param name="country_ID">The Country ID.</param>
        void Delete(int country_ID);
    }
}
