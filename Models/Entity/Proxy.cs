using System;
using System.Collections.Generic;
using Models.Enums;

namespace Models.Entity
{
    public class Proxy : Base
    {
        public string Ip { get; set; }
        public string Port { get; set; }
        public decimal Speed { get; set; }
        public bool IsWorked { get; set; }
        public DateTime DateLastCheck { get; set; }
        public DateTime DateNexCheck { get; set; }
        public IEnumerable<Site> Sites { get; set; }
        public Country Country { get; set; }
        public TypeProxy TypeProxy { get; set; }

        public override string ToString()
        {
            return $"{Ip}:{Port}";
        }
    }
}