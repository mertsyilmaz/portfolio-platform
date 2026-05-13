namespace CV.Contracts.Languages
{
    public class GetLanguagesResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Level { get; set; } = null!;
    }
}
