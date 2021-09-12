using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;

namespace MongoNet
{
    class GetController
    {
        // Tools method section
        static DateTime convertToHuman(int timestamp)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(timestamp).ToLocalTime();
            return dtDateTime;
        }

        static void showDetails(CarStream document)
        {
            Console.WriteLine($"Doc object ID: {document.Id}");
            Console.WriteLine($"Plate EN: {document.plate_en}");
            Console.WriteLine($"Confidence of Capture: {document.confidence}");
            Console.WriteLine($"Camera ID: {document.camera_id}");

            Console.WriteLine($"Entry vehicle (timestamp): " +
                $"{document.entry_datetime} To Human DateTime {convertToHuman(timestamp: document.entry_datetime)}");

            Console.WriteLine($"Exit vehicle (timestamp): " +
                $"{document.exit_datetime} To Human DateTime {convertToHuman(timestamp: document.entry_datetime)} ");
            Console.WriteLine($"Building: {document.building}");
            Console.WriteLine();
            Console.WriteLine();
        }


        // Main method
        public void getTrafficsGtTime(string connStr, bool list, int timestamp)
        {
            var client = new MongoClient(connStr);
            // Assume db name is CPR_Paya_DB
            var db = client.GetDatabase("CPR_Paya_DB");
            // Assume Table or Collection name is Cars
            IMongoCollection<CarStream> car_collection = db.GetCollection<CarStream>("Cars");

            var filter = Builders<CarStream>.Filter.Gt("entry_datetime", timestamp);
            //var tims = car_collection.Find(filter).FirstOrDefault();
            var cursor = car_collection.Find(filter).ToCursor();

            if (list)
            {
                foreach (var document in cursor.ToEnumerable())
                {
                    showDetails(document: document);
                }
            }
            else
            {
                List<CarStream> cursorLs = cursor.ToList();
                // Change index if you want first or last of list
                // 0 => first 
                // cursorLs.count => last
                Console.WriteLine($"Length of list: {cursorLs.Count}");
                Console.WriteLine("------------------------------------");
                int index = cursorLs.Count - 1;
                showDetails(document: cursorLs[index]);
            }
        }

        public void getOneTraffic(string connStr, int timestamp)
        {
            var client = new MongoClient(connStr);
            // Assume db name is CPR_Paya_DB
            var db = client.GetDatabase("CPR_Paya_DB");
            // Assume Table or Collection name is Cars
            IMongoCollection<CarStream> car_collection = db.GetCollection<CarStream>("Cars");

            var filter = Builders<CarStream>.Filter.Eq("entry_datetime", timestamp);
            //var tims = car_collection.Find(filter).FirstOrDefault();
            var cursor = car_collection.Find(filter).ToCursor();

            List<CarStream> cursorLs = cursor.ToList();
            showDetails(document: cursorLs[0]);
        }
    }
}
