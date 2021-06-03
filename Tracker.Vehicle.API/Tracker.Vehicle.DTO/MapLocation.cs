using System;
using System.Collections.Generic;
using System.Text;

namespace Tracker.Vehicle.DTO
{
    /// <summary>
    /// The type to serailize the Map box response.
    /// </summary>
    public class MapLocation
    {
        public string Type { get; set; }
        public IList<AddressMap> Features { get; set; }
    }

    public class AddressMap
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Place_Name { get; set; }
    }
}
