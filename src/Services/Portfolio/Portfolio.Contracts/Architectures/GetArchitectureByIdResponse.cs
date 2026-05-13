namespace Portfolio.Contracts.Architectures
{
    public class GetArchitectureByIdResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
