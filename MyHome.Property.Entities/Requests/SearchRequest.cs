using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Property.Entities.Requests
{
    public class SearchRequest
    {
        public string Region{ get; set; }
        public IEnumerable<string> LocalAreas { get; set; }
        public decimal MaxPrice { get; set; }
        public int MaxBeds { get; set; }

    }
}
