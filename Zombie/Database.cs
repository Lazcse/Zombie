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
            loginState = false;
            string URL = "http://htx-dev.ucholstebro.dk/HX-20-pr-B/magn5405/zombie/_login.php";
            string data = "?user=" + username + "&pass=" + password;
            /*e.g http://htx-elev.ucholstebro.dk/HX-20-pr-B/magn5405/zombie/_update.php?user=admin&pass=password */
            string reply = new WebClient().DownloadString(URL + data);
            Console.WriteLine(reply);
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
        }

    }
    class dbSync
    {
        public dbSync(string username)
        {
            string URL = "http://htx-dev.ucholstebro.dk/HX-20-pr-B/magn5405/zombie/_sync.php";
            string data = "?user=" + username;
            /*e.g http://htx-elev.ucholstebro.dk/HX-20-pr-B/magn5405/zombie/_sync.php?user=admin */
            string reply = new WebClient().DownloadString(URL + data);
            Console.WriteLine(reply);

            var json = JsonConvert.DeserializeObject<dbSync>(reply);
            Console.WriteLine(json.balance);
            Console.WriteLine(json.inventory);

        }

    }
    class dbUpdate
    {
        public dbUpdate(string username, int balance, string inventory)
        {

            info.balance = balance;
            info.inventory = inventory;

            string json = JsonConvert.SerializeObject(info);

            string URL = "http://htx-dev.ucholstebro.dk/HX-20-pr-B/magn5405/zombie/_update.php";
            string data = "?user=" + username + "&data=" + json;
            /*e.g http://htx-elev.ucholstebro.dk/HX-20-pr-B/magn5405/zombie/_update.php?user=admin&data={"balance": 50, "inventory": ["shoes"]} */
            string reply = new WebClient().DownloadString(URL + data);
            Console.WriteLine(reply);
            switch (reply)
            {
                case "success":
                    {
                        Console.WriteLine("Database successfully updated");
                        break;
                    }
                case "error":
                    {
                        Console.WriteLine("Error when updating database");
                        break;
                    }
            }
            http://htx-dev.ucholstebro.dk/HX-20-pr-B/magn5405/zombie/_update.php?user=admin&data={"balance": 50, "inventory": ["shoes"]}
        }
    }
}
