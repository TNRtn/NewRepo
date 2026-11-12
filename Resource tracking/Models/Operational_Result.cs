namespace Resource_tracking.Models
{
    public class Operational_Result<T>
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public T? Data { get; set; }

        public string? Error { get; set; }

        public Operational_Result()
        {
            Message = string.Empty;
        }
    }
}
