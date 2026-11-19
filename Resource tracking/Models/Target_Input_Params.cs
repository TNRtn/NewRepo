namespace Resource_tracking.Models
{
    public class Target_Input_Params
    {
        public string Name { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }

        public DateTime TargetDate { get; set; }

        public bool IsActive { get; set; } = true;
    }

    public class Target_Result
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }

        public DateTime TargetDate { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }
    }

    public class Target_Insert_Result
    {
        public int Id { get; set; }
    }
}
