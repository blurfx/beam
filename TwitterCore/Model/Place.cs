using System.Collections.Generic;

namespace Beam.TwitterCore.Model
{
    public class Place
    {
        private object attributes { get; set; } // i'll not implement this field
        public BoundingBox bounding_box { get; set; }
        public string country { get; set; }
        public string country_code { get; set; }
        public string full_name { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string place_type { get; set; }
        public string url { get; set; }

    }

    public class BoundingBox
    {
        public List<List<List<double>>> coordinates { get; set; }
        public string type { get; set; }
    }
}
