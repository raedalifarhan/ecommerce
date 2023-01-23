namespace API.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public float Price { get; set; }
        public string PictureUrl { get; set; } = string.Empty;
        public string ProductType { get; set; }
        public string ProductBrand { get; set; }
    }
}