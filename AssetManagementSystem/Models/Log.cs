using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssetManagementSystem.Models
{
    public enum LogLevel
    {
        Fatal,
        Error,
        Warning,
        Info,
        Debug,
        Message
    }

    public class Log
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        public string Application { get; set; }

        public string Class { get; set; }

        public string Method { get; set;  }

        [Required]
        public string LogLevel { get; set; }

        [Required]
        public string Message { get; set; }
    }
}