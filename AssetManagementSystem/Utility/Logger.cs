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

        //
        // returns 0 on failure, else returns id of new Record in Database
        //
        // pass the exception and Level of the log
        // the function will pull out the details from exception
        public static int Record(Exception e, LogLevel level)
        {
            Log log = new Log
            {
                Application = e.Source,
                LogLevel = level.ToString(),
                Class = e.TargetSite.ReflectedType.Name,
                Method = e.TargetSite.Name,
                Message = e.Message,
                Timestamp = DateTime.UtcNow
            };

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
        //
        // returns 0 on failure, else returns id of new Record in Database
        //
        // pass the level of log, and your own message
        public static int Record(LogLevel level, string msg)
        {
            Log log = new Log
            {
                LogLevel = level.ToString(),
                Message = msg,
                Timestamp = DateTime.UtcNow
            };

            Log newlog = db.Logs.Add(log);
            try
            {
                db.SaveChanges();
            }
            catch(Exception)
            {
                return 0;
            }
            if(newlog == null)
            {
                return 0;
            }
            return newlog.Id;
        }
    }
}