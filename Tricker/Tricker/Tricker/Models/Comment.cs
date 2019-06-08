using System;
using System.Collections.Generic;
using System.Text;

namespace Tricker.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int AmountLike { get; set; }
        public DateTime Date { get; set; }
        public int IdUser { get; set; }
        public int IdPublication { get; set; }
    }
}
