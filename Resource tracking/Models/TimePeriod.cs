namespace Resource_tracking.Models
{
    public class TimePeriod_Params
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public DateTime PeriodDate { get; set; }

        public string? Description { get; set; }

        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }

        public string? KeyNotes { get; set; }

        public string? KeyReferenceLinks { get; set; }
    }

    public class Timperiod_Input_params
    {
        public int? Id { get; set; } 

        public string? Name { get; set; }
        public int? CategoryId { get; set; }
        public string? SortOrder { get; set; }
    
    }

    public class Timperiod_Add_params
    {
        public int? Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public DateTime? PeriodDate { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public string? KeyNotes { get; set; }
        public string? KeyReferenceLinks { get; set; }

    }
}
