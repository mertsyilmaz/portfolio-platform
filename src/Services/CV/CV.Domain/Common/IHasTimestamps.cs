namespace CV.Domain.Common
{
    public interface IHasTimestamps : IHasCreationTime
    {
        DateTime UpdatedAt { get; set; }
    }
}
