namespace Resource_tracking.Models
{
    public class HealthMeasurement_Input_Params
    {
        public decimal MeasurementValue { get; set; }

        public DateTime MeasurementDate { get; set; }

        public string? Notes { get; set; }
    }

    public class HealthMeasurement_Result
    {
        public int Id { get; set; }

        public string MeasurementType { get; set; } = string.Empty;

        public string? BodyPart { get; set; }

        public decimal MeasurementValue { get; set; }

        public string Unit { get; set; } = string.Empty;

        public DateTime MeasurementDate { get; set; }

        public string? Notes { get; set; }

        public DateTime CreatedDate { get; set; }
    }
    public class HealthMeasurement_Insert_Result
    {
        public int Id { get; set; }
    }
    public class HealthMeasurement_MissingDate_Result
    {
        public DateTime MissingDate { get; set; }
    }
}
