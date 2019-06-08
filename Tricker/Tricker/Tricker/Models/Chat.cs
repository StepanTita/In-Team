using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Tricker.Models
{
    public class Chat
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly string serverUrl = "https://tricker-server.herokuapp.com/";
        public int Id { get; set; }
        public int IdRecipient { get; set; }
        public int IdSender { get; set; }
        public List<Message> Messages { get; set; }

        public Chat(int IdRecipient, int IdSender)
        {
            GetNewId();
            this.IdRecipient = IdRecipient;
            this.IdSender = IdSender;
            Messages = new List<Message>();
        }
        private async void GetNewId()
        {
            string response = await client.GetStringAsync(serverUrl);
            Id = Convert.ToInt32(response);
        }
        public void AddMessage(string text)
        {
            Message newMessage = new Message(text, Id);
            Messages.Add(newMessage);
        }
    }
}
