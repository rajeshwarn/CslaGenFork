using System;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DTO for G07_Country_Child type
    /// </summary>
    public partial class G07_Country_ChildDto
    {
        /// <summary>
        /// Gets or sets the parent Country ID.
        /// </summary>
        /// <value>The Country ID.</value>
        public int Parent_Country_ID { get; set; }

        /// <summary>
        /// Gets or sets the Regions Child Name.
        /// </summary>
        /// <value>The Country Child Name.</value>
        public string Country_Child_Name { get; set; }
    }
}