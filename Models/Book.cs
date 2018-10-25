namespace QL_Sach.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string IdBook { get; set; }
        public string NameBook { get; set; }
        public string Author { get; set; }
        public int? NumPage { get; set; }
        public string TypeBook { get; set; }
        public string PublishingCompany { get; set; }
        public double? Price { get; set; }

    }
}