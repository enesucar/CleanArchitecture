using Domain.Common;

namespace Domain.Entities
{
    public class Product : Entity<Guid>
    {
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Category Category { get; set; }

        public Product()
        {
            Category = null!;
        }
    }
}
