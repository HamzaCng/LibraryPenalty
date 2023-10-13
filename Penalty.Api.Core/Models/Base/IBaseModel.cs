using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Api.Core.Models.Base
{
    public interface IBaseModel
    {
        /// <summary>
        /// Gets or sets the creation time
        /// </summary>
        DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the modifier user name
        /// </summary>
        DateTime UpdatedDate { get; set; }

        /// <summary>
        /// Gets or sets the is deleted date
        /// </summary>
        DateTime DeletedDate { get; set; }

        /// <summary>
        /// Gets or sets the is deleted
        /// </summary>
        bool Deleted { get; set; }
    }
}
