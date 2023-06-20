using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHome.Property.Entities.Entities;


namespace MyHome.Property.Entities.Responses
{
    public class SearchResponse
    {
        public IReadOnlyCollection<PropertyModel> SearchResults { get; set; }
    }
}
