namespace SpeakEase.Models
{
    public class Response<T> 
    {
        public bool Success { get; set; }
        public string? Message { get; set; } 
        public IEnumerable<T>? Data { get; set; }
        public T? ObjectData { get; set; }   
        public string? status_code { get; set; }
        public string? error { get; set; }
        public int? CountOfData { get; set; }
        public int? paggingNumber { get; set; }
        
    }
}
