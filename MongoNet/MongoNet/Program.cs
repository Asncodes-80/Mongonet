using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoNet.Controller;

namespace MongoNet
{
    class Program
    {
        
       

        static void Main(string[] args)
        {
            var connectionStr = "mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass&ssl=false";
            var getControl = new GetController();
            var delControl = new DeleteController();

            // ATTENTIONS TABLE:
            // List true ? show list of traffics from your datetime (timestamp) to end : show last traffic;
            // 1630730919 from 8 days ago to now (day 5) 3 day in total

            //getControl.getTrafficsGtTime(connStr: connectionStr, list: true, timestamp: 1630730919);

            // Getting specific traffic by timestamp
            //getControl.getOneTraffic(connStr: connectionStr, timestamp: 1630730919);

            // Put your object id
            //delControl.deleteTrafficByObjID(connStr: connectionStr, objID: "613da5ef39c8be2ac4bc3b8f");




            Console.ReadKey();
        }
    }
}
