using System.Collections.Generic;

namespace Chat.Data.Models
{
    public class ChatModel
    {
        public List<int> Data { get; set; }
        public string Label { get; set; }
        public ChatModel()
        {
            Data = new List<int>();
        }
    }
}
