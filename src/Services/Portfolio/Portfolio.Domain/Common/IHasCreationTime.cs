namespace Portfolio.Domain.Common
{
    public interface IHasCreationTime
    {
        DateTime CreatedAt { get; set; }
    }
}
