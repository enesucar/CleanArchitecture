using Domain.Common;

namespace Domain.Entities
{
    public class Category : Entity<Guid>
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }

        public Category()
        {
            Products = new List<Product>();
        }
    }
}
