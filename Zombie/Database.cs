using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net;

namespace Zombie
{
    class dbLogin
    {
        public dbLogin(string username, string password, out bool loginState)
        {
            Console.WriteLine(("").PadRight(24, '-'));
            Console.WriteLine(":::dbLogin:::");

            loginState = false;
            string URL = "http://htx-elev.ucholstebro.dk/HX-20-pr-B/magn5405/zombie/_login.php";
            string data = "?user=" + username + "&pass=" + password;
            
            string reply = new WebClient().DownloadString(URL + data);
            switch (reply)
            {
                case "success":
                    {
                        Console.WriteLine("Login successful");
                        loginState = true;
                        break;
                    }
                case "wrongpass":
                    {
                        Console.WriteLine("Wrong password");
                        break;
                    }
                case "nouser":
                    {
                        Console.WriteLine("No user found with that name");
                        break;
                    }
            }
            Console.WriteLine();
        }

    }
    public class Output
    {
        public int balance { get; set; }
        public IList<string> inventory { get; set; }
    }
    class dbSync
    {
        public dbSync(string username, out int gold, out IList<string> inventory)
        {
            Console.WriteLine(("").PadRight(24, '-'));
            Console.WriteLine(":::dbSync:::");

            string URL = "http://htx-elev.ucholstebro.dk/HX-20-pr-B/magn5405/zombie/_sync.php";
            string data = "?user=" + username;
            
            string reply = new WebClient().DownloadString(URL + data);
            Console.WriteLine("reply: " + reply);

            var output = JsonConvert.DeserializeObject<Output>(reply);
            Console.WriteLine("JsonConvert.DeserializeObject: " + output);

            gold = output.balance;
            inventory = output.inventory;

            Console.WriteLine("Balance: " + output.balance);
            Console.WriteLine("Inventory: " + output.inventory);

            Console.WriteLine();
        }
    }
    public class Json
    {
        public int balance { get; set; }
        public IList<string> inventory { get; set; }
    }
    class dbUpdate
    {
        public dbUpdate(string username, int gold, IList<string> inventory)
        {
            Console.WriteLine(("").PadRight(24, '-'));
            Console.WriteLine(":::dbUpdate:::");

            Json json = new Json
            {
                balance = gold,
                inventory = inventory
            };

            string output = JsonConvert.SerializeObject(json);
            Console.WriteLine("JsonConvert.SerializeObject: " + output);

            string URL = "http://htx-elev.ucholstebro.dk/HX-20-pr-B/magn5405/zombie/_update.php";
            string data = "?user=" + username + "&data=" + output;
            
            string reply = new WebClient().DownloadString(URL + data);
            Console.WriteLine(reply);
            Console.WriteLine();
        }
    }
}
