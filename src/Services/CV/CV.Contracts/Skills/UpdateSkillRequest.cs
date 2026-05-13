namespace CV.Contracts.Skills
{
    public class UpdateSkillRequest
    {
        public string Name { get; set; } = null!;
        public string Level { get; set; } = null!;
        public string Category { get; set; } = null!;
    }
}
