using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Logger
{
    public class CustomLogger
    {
        public void LogFunction(String Log)
        {
            var filename = AppDomain.CurrentDomain.BaseDirectory + "App_Data\\" + "log\\" + "logger.txt";
            var sw = new System.IO.StreamWriter(filename, true);
            sw.WriteLine(DateTime.Now.ToString() + Log);
            sw.Close();
        }
        public void ExceptionLogFunction(String Log)
        {
            var filename = AppDomain.CurrentDomain.BaseDirectory + "App_Data\\" + "log\\" + "ExplogErrors.txt";
            var sw = new System.IO.StreamWriter(filename, true);
            sw.WriteLine(DateTime.Now.ToString() + Log);
            sw.Close();
        }
    }
}