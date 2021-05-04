using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net;

namespace Zombie
{
    class dbLogin
    {
        public dbLogin(string username, string password)
        {
            string URL = "http://htx-dev.ucholstebro.dk/HX-20-pr-B/magn5405/_json.php";
            string data = "?user=" + username + "&pass=" + password;

            string reply = new WebClient().DownloadString(URL + data);
            switch (reply)
            {
                case "success":
                    {
                        Console.WriteLine("Login successful");
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
}
