namespace CV.Contracts.Educations
{
    public class GetEducationsResponse
    {
        public Guid Id { get; set; }

        public string SchoolName { get; set; } = null!;

        public string Department { get; set; } = null!;

        public string Degree { get; set; } = null!;

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool IsCurrent { get; set; }
    }
}
