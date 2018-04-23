using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AssetManagementSystem.Models;
using Utility;

namespace AssetManagementSystem.Utility
{
    public static class Logger
    {
        private static AssetManagementSystemContext db = new AssetManagementSystemContext();
        // returns 0 on failure, else returns id of new Record in Database
        // if you pass an exception the function will pull out the details from exception
        public static int Record(string msg, LogLevel level, Exception e = null)
        {
            Log log = new Log();
            log.Timestamp = DateTime.UtcNow;
            log.Message = msg;
            log.LogLevel = level.ToString();

            if (e != null)
            {
                log.Application = e.Source;
                log.Class = e.TargetSite.ReflectedType.Name;
                log.Method = e.TargetSite.Name;
            }

            log = db.Logs.Add(log);

            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {
                return 0;
            }
            if (log == null)
            {
                return 0;
            }
            return log.Id;
        }
    }
}