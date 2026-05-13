namespace CV.Contracts.Languages
{
    public class GetLanguageByIdResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Level { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}
