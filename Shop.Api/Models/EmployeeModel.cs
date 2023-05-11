using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Shop.Api.Models.Shared;

namespace Shop.Api.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class EmployeeModel : Entity
    {
        public EmployeeModel() { }

        public EmployeeModel(int id, string name, string email, string password, string phone, string position)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            Phone = phone;
            Position = position;
        }

        [Required(ErrorMessage = "O nome do empregado é obrigatório")]
        public string Name { get; set; } = default!;

        [Required(ErrorMessage = "O email do empregado é obrigatório")]
        public string Email { get; set; } = default!;

        [Required(ErrorMessage = "A senha do empregado é obrigatório")]
        public string Password { get; set; } = default!;

        [Required(ErrorMessage = "O telefone do empregado é obrigatório")]
        public string Phone { get; set; } = default!;

        [Required(ErrorMessage = "O cargo do empregado é obrigatório")]
        public string Position { get; set; } = default!;

    }
}