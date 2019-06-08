using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Tricker.Models
{
    public class Message
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly string serverUrl = "https://tricker-server.herokuapp.com/";
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }
        public int IdChat { get; set; }
        public Message(string Text, int IdChat)
        {
            GetNewId();
            this.Date = DateTime.UtcNow;
            this.Text = Text;
            this.Type = "Simple";
            this.IdChat = IdChat;
        }
        private async void GetNewId()
        {
            string response = await client.GetStringAsync(serverUrl);
            Id = Convert.ToInt32(response);
        }
    }
}
