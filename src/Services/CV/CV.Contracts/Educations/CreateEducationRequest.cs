namespace CV.Contracts.Educations
{
    public class CreateEducationRequest
    {
        public string SchoolName { get; set; } = null!;

        public string Department { get; set; } = null!;

        public string Degree { get; set; } = null!;

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Description { get; set; } = null!;

        public bool IsCurrent { get; set; }
    }
}
