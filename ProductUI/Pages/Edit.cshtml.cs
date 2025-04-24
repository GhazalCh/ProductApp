using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductUI.Models;
using System.Net.Http.Json;

namespace ProductUI.Pages
{
    public class EditModel : PageModel
    {
        private readonly HttpClient _http;
        [Bindproperty] public Product Product {get;set;}
        public EditModel(IHttpClientFactory f) => _http = f.CreateClient();

        public async Task OnGetAsync(int id)
        {
            Product = await _http.GetFromJsonAsync<Product>($"/product/{id}");
        }
        public async Task<IactionResult> OnPostAsync()
        {
            await _http.PutAsJsonAsync($"product/{Product.Id}", Product);
            return redirectToPage("Index");
        }
    }
}