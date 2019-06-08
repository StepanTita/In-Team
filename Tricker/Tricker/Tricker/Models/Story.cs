using System;
using System.Collections.Generic;
using System.Text;

namespace Tricker.Models
{
    public class Story
    {
        public int Id { get; set; }
        public int URL { get; set; }
        public DateTime TimeUpload { get; set; }
        public DateTime TimeDelete { get; set; }
        public int IdUser { get; set; }
    }
}
