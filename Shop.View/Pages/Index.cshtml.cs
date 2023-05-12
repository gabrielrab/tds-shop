using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Shop.Api.Models;

namespace Shop.View.Pages;

public class IndexModel : PageModel
{
    public List<ProductModel> products = new();

    public async Task OnGetAsync()
    {
        HttpClient client = new() { BaseAddress = new Uri("http://localhost:5135/api/product") };
        var response = await client.GetAsync("");
        if (response.IsSuccessStatusCode)
        {
            products = JsonConvert.DeserializeObject<List<ProductModel>>(
                await response.Content.ReadAsStringAsync()
            )!;
        }
    }
}
