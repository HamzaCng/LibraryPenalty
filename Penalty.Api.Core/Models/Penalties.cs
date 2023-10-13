using Penalty.Api.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Api.Core.Models
{
    public record Penalties : BaseModel
    {
        public DateTime CheckedOutDate { get; set; }
        public DateTime ReturnedDate { get; set; }
        public int PenaltyDay { get; set; }
        public decimal Price { get; set; }

        //for difrent country weekend
        public Country? Countries { get; set; }

    }
}
