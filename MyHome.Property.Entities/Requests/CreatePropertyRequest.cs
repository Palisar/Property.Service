using MyHome.Property.Entities.Entities;

namespace MyHome.Property.Entities.Requests
{
    public class CreatePropertyRequest
    {
        //Just for example purposes, in the real world I would create a seperate request object to populate the data with.
        public PropertyModel? Model { get; set; }
    }
}
