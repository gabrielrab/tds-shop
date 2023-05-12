using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Shop.Api.Models;

namespace Shop.View.Pages.Orders;

public class IndexModel : PageModel
{
    public List<ProductModel> products = new();
    public List<EmployeeModel> employees = new();

    public async Task OnGetAsync()
    {
        HttpClient client = new() { BaseAddress = new Uri("http://localhost:5135/api") };
        var response = await client.GetAsync("/product");
        var products = JsonConvert.DeserializeObject<List<ProductModel>>(
            await response.Content.ReadAsStringAsync()
        )!;

        // response = await client.GetAsync("/employee");
        // var employees = JsonConvert.DeserializeObject<List<EmployeeModel>>(
        //     await response.Content.ReadAsStringAsync()
        // )!;

    }
}
