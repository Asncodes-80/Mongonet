using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoNet
{
    class Program
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
        static void Main(string[] args)
        {
            var client = new MongoClient("mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass&directConnection=true&ssl=false");
            var db = client.GetDatabase("CPR_Paya_DB");
            IMongoCollection<CarStream> car_collection = db.GetCollection<CarStream>("Car");
            var filter = Builders<CarStream>.Filter.Gt("entry_datetime", 1629885620);
            var tims = car_collection.Find(filter).FirstOrDefault();
            Console.WriteLine(tims.building);

            Console.ReadKey();
        }
    }
}
