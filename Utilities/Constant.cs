using SampleWeb.Configuration;
using Microsoft.Extensions.Configuration;
using System;

namespace SampleWeb.Utilities
{
    class Constant
    {
        public static string currentDateTime = DateTime.Now.ToString("MM-dd-yyyy HH-mm-ss");
        public static string currentDate = DateTime.Now.ToString("MM-dd-yyyy");
        public static string currentTime = DateTime.Now.ToString("HH-mm-ss");
        public static string webLoader = "trl-l-loader__preloader";
        public static int waitTimeout = 60;
        public static string url = "https://www.google.com";
        public static string browser = "chrome";
    }
}
