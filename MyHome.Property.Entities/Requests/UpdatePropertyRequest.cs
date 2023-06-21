using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using MyHome.Property.Entities.Entities;

namespace MyHome.Property.Entities.Requests
{
    public class UpdatePropertyRequest
    {
        public PropertyModel? UpdatedModel { get; set; }
    }
}
