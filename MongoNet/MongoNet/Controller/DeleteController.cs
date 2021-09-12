using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoNet.Controller
{
    class DeleteController
    {
        public void deleteTrafficByObjID(string connStr, string objID)
        {
            var client = new MongoClient(connStr);
            // Assume db name is CPR_Paya_DB
            var db = client.GetDatabase("CPR_Paya_DB");
            // Assume Table or Collection name is Cars
            IMongoCollection<CarStream> car_collection = db.GetCollection<CarStream>("Cars");

            BsonObjectId obj = new BsonObjectId(new ObjectId(objID));
            var findByObjID = Builders<CarStream>.Filter.Eq("_id", obj);
            var cursor = car_collection.Find(findByObjID).ToCursor();
            var willDelPlate = cursor.ToList()[0].plate_en;

            var delQuery = car_collection.DeleteOne(findByObjID);
            var delCount = delQuery.DeletedCount;

            if (delCount == 1)
            {
                Console.WriteLine($"Delete Document with plate_EN {willDelPlate} successed!");
            } else
            {
                Console.WriteLine("Error in deleting document");
            }
            
        }
    }
}
