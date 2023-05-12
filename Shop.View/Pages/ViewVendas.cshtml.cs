using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

public record Order(
    int Id,
    double Total,
    Employee Employee,
    DateTime CreatedAt
);

public record Employee(
    string Name
);

namespace Shop.View.Pages
{
    public class ViewVendas : PageModel
    {
        private readonly ILogger<ViewVendas> _logger;

        public List<Order> Orders { get; set; } = new();

        public ViewVendas(ILogger<ViewVendas> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var url = "http://localhost:5135/api/order";
            using (var httpClient = new HttpClient()) {
                var request = new HttpRequestMessage();
                request.RequestUri = new(url);
                request.Method = HttpMethod.Get;

                var httpResponse = await httpClient.SendAsync(request);
                var responseString = await httpResponse.Content.ReadAsStringAsync();
                _logger.LogInformation(responseString);
                var ordersList = JsonConvert.DeserializeObject<List<Order>>(responseString);

                Orders.AddRange(ordersList);
            }
            return Page();
        }
    }
}

