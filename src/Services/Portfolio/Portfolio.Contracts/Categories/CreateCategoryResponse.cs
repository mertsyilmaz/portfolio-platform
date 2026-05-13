namespace Portfolio.Contracts.Categories
{
    public class CreateCategoryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
