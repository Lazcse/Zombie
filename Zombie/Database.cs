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
            string URL = "http://htx-elev.ucholstebro.dk/HX-20-pr-B/magn5405/_json.php";
            string data = "user=" + username + "&pass=" + password;

            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                string HtmlResult = wc.UploadString(URL, data);
            }

            string reply = new WebClient().DownloadString(URL);
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
}
