namespace CV.Contracts.Hobbies
{
    public class GetHobbiesResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;
    }
}
