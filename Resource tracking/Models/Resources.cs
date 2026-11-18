namespace Resource_tracking.Models
{
    public class Resources_params_Result
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public bool IsActive { get; set; }
        public string? ReferenceKeys { get; set; }
        public string? ReferenceNoteLinks { get; set; }
        public string? KeyPoints { get; set; }

        public int? RevisionCount { get; set; }
    }

    public class Resources_Input_params
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public int? CategoryId { get; set; }

        public int? RevisionCount { get; set; }
    }

    public class Resources_Add_Params
    {
        public int? Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public string? ReferenceKeys { get; set; }
        public string? ReferenceNoteLinks { get; set; }
        public string? KeyPoints { get; set; }

        public int RevisionCount { get; set; } = 0;
    }
}
