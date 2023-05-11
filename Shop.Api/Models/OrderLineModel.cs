using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Shop.Api.Models.Shared;

namespace Shop.Api.Models
{
    public class OrderLineModel : Entity
    {
        public OrderLineModel() { }

        public OrderLineModel(int quantity, int product_id)
        {
            Total = quantity;
            ProductId = product_id;
        }


        [Required(ErrorMessage = "O preço da venda é obrigatório")]
        public double Total { get; set; } = default!;

        [JsonIgnore]
        [Required(ErrorMessage = "O produto é obrigatório")]
        public int ProductId { get; set; } = default!;

        public ProductModel? Product { get; set; }


    }
}