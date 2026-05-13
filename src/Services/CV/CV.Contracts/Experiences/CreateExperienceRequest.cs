namespace CV.Contracts.Experiences
{
    public class CreateExperienceRequest
    {
        public string CompanyName { get; set; } = null!;

        public string Position { get; set; } = null!;

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Description { get; set; } = null!;

        public bool IsCurrent { get; set; }

    }
}
