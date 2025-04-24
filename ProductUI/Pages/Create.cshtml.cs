using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductUI.Models;
using System.Net.Http.Json;

namespace ProductUI.Pages
{
    public class CreateModel : PageModel
    {
        private readonly HttpClient _http;
        [BindProperty]
        public ProductUI {get;set;}
        public CreateModel(IHttpClientFactory f) => _http = f.CreatteClient();
        public async Task<IActionResult> OnPostAsync()
        {
            await _http.PostAsJsonAsync("/product", Product);
            return RedirectToPage("Index");
        }
    }
}