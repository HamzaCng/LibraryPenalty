using Penalty.Api.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Api.Core.Models
{
    public record Country : BaseModel
    { 
        public string? Name { get; set; }
        public string? Code { get; set; }

    }
}
