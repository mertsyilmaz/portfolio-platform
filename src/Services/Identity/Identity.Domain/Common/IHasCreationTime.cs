namespace Identity.Domain.Common
{
    public interface IHasCreationTime
    {
        DateTime CreatedAt { get; set; }
    }
}
