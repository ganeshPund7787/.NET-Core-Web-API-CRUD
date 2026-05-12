namespace Database_Connection_Practice.DTOs
{
    public class GetToDoResponse
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

    }
}
