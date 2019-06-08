using System;
using System.Collections.Generic;
using System.Text;

namespace Tricker.Models
{
    public class Post
    {
        public int Id { get; set; }
        public int AmountLike { get; set; }
        public DateTime Date { get; set; }
        //!!!!!!!!!!!!!!!!!!!!public string Location найти нужный пакет
        public string Description { get; set; }
        public string State { get; set; }
        public int IdUser { get; set; }
        public Photo[] Photos { get; set; }
        public Comment[] Comments { get; set; }
    }
}
