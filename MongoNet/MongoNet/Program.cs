using System;
using MongoNet.Controller;

namespace MongoNet
{
    class Program
    {
        static void Main(string[] args)
        {
            // Change Connection string
            var connectionStr = "mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass&directConnection=true&ssl=false";
            var getControl = new GetController();
            var delControl = new DeleteController();
            var updateControl = new UpdateController();

            // ATTENTIONS TABLE:
            // List true ? show list of traffics from your datetime (timestamp) to end : show last traffic;
            // 1630730919 from 8 days ago to now (day 5) 3 day in total

            //getControl.getTrafficsGtTime(connStr: connectionStr, list: true, timestamp: 2555478);

            // Getting specific traffic by timestamp
            //getControl.getOneTraffic(connStr: connectionStr, timestamp: 1630730919);

            // Put your object id
            //delControl.deleteTrafficByObjID(connStr: connectionStr, objID: "613da5ef39c8be2ac4bc3b8f");

            //updateControl.collection = "Cars";
            //updateControl.updateOneCarStream(connStr: connectionStr, objID: "612609403b029f90d613c541");

            Console.ReadKey();
        }
    }
}
