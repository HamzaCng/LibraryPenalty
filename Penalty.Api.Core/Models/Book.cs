using Penalty.Api.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Api.Core.Models
{
    public record Book : BaseModel
    {
        public string? Name { get; set; }     
        public Penalties? Penaltyies{ get; set; }
    }
}
