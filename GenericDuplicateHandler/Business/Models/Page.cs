namespace GenericDuplicateHandler.Business.Models
{
    public class Page
    {
        public int Id { get; set; }
        public string? FileName { get; set; }
        public string? DocumentType { get; set; }
        public DateTime ImportDate { get; set; }
        public int PageNumber { get; set; }
    }
}
