using System;
using MongoDB.Bson;

namespace MongoNet
{
    public class CarStream
    {
        public ObjectId Id { get; set; }
        public String plate_en { get; set; }
        public String plate0 { get; set; }
        public String plate1 { get; set; }
        public String plate2 { get; set; }
        public String plate3 { get; set; }
        public String Plate_img { get; set; }
        public String car_img { get; set; }
        public String car_img_exit { get; set; }
        public String Plate_img_exit { get; set; }
        public Double confidence { get; set; }
        public String camera_id { get; set; }
        public Int32 entry_datetime { get; set; }
        public int status { get; set; }
        public String slot { get; set; }
        public Int32 exit_datetime { get; set; }
        public String device { get; set; }
        public String building { get; set; }
        public String type { get; set; }
        public Int32 direction { get; set; }
        public String type_entry { get; set; }
        public Int32 is_fetched_entry { get; set; }
        public Int32 is_fetched_exit { get; set; }
        public Int32 is_fetched { get; set; }
        public Int32 is_new { get; set; }
    }

}
