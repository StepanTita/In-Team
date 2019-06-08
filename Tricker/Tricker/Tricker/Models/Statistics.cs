using System;
using System.Collections.Generic;
using System.Text;

namespace Tricker.Models
{
    public class Statistics
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int Expierence { get; set; }
        public Achievment[] Achievments { get; set; }
    }
}
