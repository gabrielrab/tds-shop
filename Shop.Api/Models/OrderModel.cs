using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Shop.Api.Models.Shared;

namespace Shop.Api.Models
{
    public class OrderModel : Entity
    {
        public OrderModel() { }

        public OrderModel(DateTime created_at, double total, int employee_id)
        {
            this.Total = total;
            this.CreatedAt = created_at;
            this.EmployeeId = employee_id;
        }


        [Required(ErrorMessage = "O preço da venda é obrigatório")]
        public double Total { get; set; } = default!;

        [Required(ErrorMessage = "A data da venda é obrigatório")]
        public DateTime CreatedAt { get; set; } = default!;

        [Required(ErrorMessage = "O funcionário é obrigatório")]
        public int EmployeeId { get; set; } = default!;

        public EmployeeModel? Employee { get; set; }

        public List<OrderLineModel>? OrderLines { get; set; }


    }
}