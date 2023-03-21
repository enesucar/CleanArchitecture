namespace Application.Features.Products.Models
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public decimal Price { get; set; }
    }
}
