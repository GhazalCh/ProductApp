using Microsoft.AspNetCore.mvc.RazorPages;
using ProductUI.Models;
using System.Net.Http.Json;

namespace ProductUI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient _http;
        public List<Product> Products {get;set} = new();
        public IndexModel(IHttpClientFactory f) => _http = f.CreateClient();
        public async Task OnGetAsync()
        {
            Products = await _http.GetFromJsonAsync<List<Product>>("/product");
        }
    }
}