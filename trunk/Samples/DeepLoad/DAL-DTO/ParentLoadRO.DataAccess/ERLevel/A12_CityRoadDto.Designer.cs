using System;
using Csla;

namespace ParentLoadRO.DataAccess.ERLevel
{
    /// <summary>
    /// DTO for A12_CityRoad type
    /// </summary>
    public partial class A12_CityRoadDto
    {
        /// <summary>
        /// Gets or sets the parent City ID.
        /// </summary>
        /// <value>The City ID.</value>
        public int Parent_City_ID { get; set; }

        /// <summary>
        /// Gets or sets the City Road ID.
        /// </summary>
        /// <value>The City Road ID.</value>
        public int CityRoad_ID { get; set; }

        /// <summary>
        /// Gets or sets the City Road Name.
        /// </summary>
        /// <value>The City Road Name.</value>
        public string CityRoad_Name { get; set; }
    }
}
