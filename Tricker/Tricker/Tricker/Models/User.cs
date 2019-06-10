using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Tricker.Models
{
    public class User
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly string serverUrl = "https://tricker-server.herokuapp.com/";
        public int Id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Birthday { get; set; }
        public string Type { get; set; }
        //public Photo Avatar { get; set; }
		public string Picture { get; set; }
        public Statistics Statistics { get; set; }
        public List<Garbage> Garbages { get; set; }
        public List<Post> Posts { get; set; }
        public List<Chat> Chats { get; set; }
		public List<Subscriber> Subscribers { get; set; }
		public List<GalleryItem> Gallery { get; set; }

		public User()
        {
            Id = 0;
            Login = null;
            Name = null;
            Email = null;
            Password = null;
            Birthday = DateTime.UtcNow;
            Type = null;
            Picture = null;
            Statistics = null;
            Garbages = null;
            Posts = null;
            Chats = null;
        }
        public void SendMessage(int IdChat, string text)
        {
            int index = SearchChat(IdChat);
            if (index == -1)
                return;
            Chats[index].AddMessage(text);
        }
        private int SearchChat(int IdChat)
        {
            for (int i = 0; i < Chats.Count; i++)
            {
                if (Chats[i].Id == IdChat)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
