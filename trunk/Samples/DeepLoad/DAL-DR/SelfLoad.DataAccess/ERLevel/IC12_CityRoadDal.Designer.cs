using System;
using System.Data;
using Csla;

namespace SelfLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for C12_CityRoad type
    /// </summary>
    public partial interface IC12_CityRoadDal
    {

        /// <summary>
        /// Inserts a new C12_CityRoad object in the database.
        /// </summary>
        /// <param name="city_ID">The parent City ID.</param>
        /// <param name="cityRoad_ID">The City Road ID.</param>
        /// <param name="cityRoad_Name">The City Road Name.</param>
        
        void Insert(int city_ID, out int cityRoad_ID, string cityRoad_Name);

        /// <summary>
        /// Updates in the database all changes made to the C12_CityRoad object.
        /// </summary>
        /// <param name="cityRoad_ID">The City Road ID.</param>
        /// <param name="cityRoad_Name">The City Road Name.</param>
        
        void Update(int cityRoad_ID, string cityRoad_Name);

        /// <summary>
        /// Deletes the C12_CityRoad object from database.
        /// </summary>
        /// <param name="cityRoad_ID">The City Road ID.</param>
        void Delete(int cityRoad_ID);
    }
}
