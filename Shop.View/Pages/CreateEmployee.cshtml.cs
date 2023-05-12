using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

public record CreateEmployeeModel(
    string Name,
    string Email,
    string Password,
    string Phone,
    string Position
);

namespace Shop.View.Pages
{
    public class CreateEmployee : PageModel
    {
        private readonly ILogger<CreateEmployee> _logger;

        public CreateEmployee(ILogger<CreateEmployee> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var Name = Request.Form["name"];
            var Email = Request.Form["email"];
            var Password = Request.Form["password"];
            var Position = Request.Form["position"];
            var Phone = Request.Form["phone"];

            var url = "http://localhost:5135/api/employee";
            using (var httpClient = new HttpClient()) {
                var request = new HttpRequestMessage();
                var createEmployeeModel = new CreateEmployeeModel(Name, Email, Password, Position, Phone);

                var serializedEmployeeModel = JsonConvert.SerializeObject(createEmployeeModel);
                
                var buffer = System.Text.Encoding.UTF8.GetBytes(serializedEmployeeModel);
                var byteContent = new ByteArrayContent(buffer);   
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await httpClient.PostAsync(url, byteContent);

                var responseString = await response.Content.ReadAsStringAsync();

                return RedirectToPage("/CreateEmployee");
            }
        }
    }
}