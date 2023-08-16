using System.Text.Json.Serialization;

namespace Repository_Pattern.Models
{
    public class Auther
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //[JsonIgnore]
        public List<Book> books { get; set; }=new List<Book>();//////////must initialize 
    }
}
