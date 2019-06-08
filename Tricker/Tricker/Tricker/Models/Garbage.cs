using System;
using System.Collections.Generic;
using System.Text;

namespace Tricker.Models
{
    public class Garbage
    {
        public int Id { get; set; }
        public string State { get; set; }
        // ЛОКАЦИЯ !!!!!!!!!!!!public int Id { get; set; }
        public int DangerLevel { get; set; }
        public int IdUser { get; set; }
    }
}
