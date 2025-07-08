using System.ComponentModel.DataAnnotations;

namespace EComApi.Models.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public long Price { get; set; }
        [Required]
        public string PictureUrl { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Brand { get; set; }
        public int QuantityInStock { get; set; }


    }
}
