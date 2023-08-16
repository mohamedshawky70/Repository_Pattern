using System.Text.Json.Serialization;

namespace Repository_Pattern.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        // [JsonIgnore]
        public int AutherId { get; set; }
        //[JsonIgnore]
        public Auther Auther { get; set; }
      
    }
}
