using System;
using Csla;

namespace Invoices.DataAccess
{
    /// <summary>
    /// DTO for ProductTypeCachedInfo type
    /// </summary>
    public partial class ProductTypeCachedInfoDto
    {
        /// <summary>
        /// Gets or sets the Product Type Id.
        /// </summary>
        /// <value>The Product Type Id.</value>
        public int ProductTypeId { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        /// <value>The Name.</value>
        public string Name { get; set; }
    }
}
