using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Bson;

namespace MongoNet.Controller
{
    class UpdateController
    {
        public string collection;
        public void updateOneCarStream(string connStr, string objID)
        {
            try
            {
                var client = new MongoClient(connStr);
                // Assume db name is CPR_Paya_DB
                var db = client.GetDatabase("CPR_Paya_DB");
                // Assume Table or Collection name is Cars
                IMongoCollection<CarStream> car_collection = db.GetCollection<CarStream>("Car");

                BsonObjectId obj = new BsonObjectId(new ObjectId(objID));
                var findByObjID = Builders<CarStream>.Filter.Eq("_id", obj);

                dynamic[,] document = {
                    { "plate_en", "85-y-1234546" },
                    { "Plate_img", "Sample image base64 format" },
                    { "car_img", "Sample image base64 format" },
                    { "car_img_exit", "Sample image base64 format" },
                    { "Plate_img_exit", "Sample image base64 format" },
                    { "confidence", 0.999 },
                    { "camera_id", 3 },
                    { "entry_datetime", 123456789 },
                    { "status", 1 },
                    { "slot", "2Huawei-101" },
                    { "exit_datetime", 123456789 },
                    { "device", "rtsp://192.168.1.214:554/11" },
                    { "building", "Huawei" },
                    { "type", "Unlimit" },
                    { "direction", 2 },
                    { "type_entry", "cxzzc" },
                    { "is_fetched_entry", 0 },
                    { "is_fetched_exit", -1 },
                    { "is_fetched", 1 },
                    { "is_new", 1 }
                };

                for (int i = 0; i < 20; i++)
                {
                    var updateChecksum = Builders<CarStream>.Update.Set(document[i, 0], document[i, 1]);
                    car_collection.UpdateOne(findByObjID, updateChecksum);
                }

            } catch(Exception err)
            {
                Console.WriteLine("There is no data with this Object iD! more info followin Exception:");
                Console.WriteLine(err);
            }
        }
    }
}
