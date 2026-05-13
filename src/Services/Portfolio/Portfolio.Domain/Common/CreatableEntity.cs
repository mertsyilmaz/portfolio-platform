namespace Portfolio.Domain.Common
{
    public abstract class CreatableEntity : Entity, IHasCreationTime
    {
        public DateTime CreatedAt { get; set; }
    }
}
