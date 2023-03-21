namespace Domain.Common
{
    public class Entity
    {
    }

    public class Entity<TPrimaryKey> : Entity
    {
        public TPrimaryKey Id { get; set; }
    }
}
