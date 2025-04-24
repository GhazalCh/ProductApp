using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductUI.Models;
using System.Net.Http.Json;

namespace ProductUI.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly HttpClient _http;
        [Bindproperty] public Product Product {get;set;}
        public DeleteModel(IHtppClientFactory f) => _http = f.CreateClient();

        public async Task OnGetAsync(int id)
        {
            Product = await _http.GetFromJsonAsync<Product>($"/product/{id}");
        }
        public async Task<IActionResult> ONPostAsync(int id)
        {
            await _http.DeleteAsync($"/product/{id}");
            return RedirectToPage("Index");
        }
    }
}