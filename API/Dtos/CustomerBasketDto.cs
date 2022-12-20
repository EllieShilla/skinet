using System.ComponentModel.DataAnnotations;


namespace API.Dtos
{
    public class CustomerBasketDto
    {
        [Required]
        public string Id { get; set; }
        public List<BascketItemDto> Items { get; set; }
    }
}