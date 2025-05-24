using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUı.Dtos.BasketDtos;

namespace SignalRWebUı.Controllers
{
   
        public class BasketsController : Controller
        {
            private readonly IHttpClientFactory _httpClientFactory;

            public BasketsController(IHttpClientFactory httpClientFactory)
            {
                _httpClientFactory = httpClientFactory;
            }

            // Sepeti görüntüleme
            public async Task<IActionResult> Index(int id)
            {
                ViewBag.MenuTableId = id;

                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync($"http://localhost:5044/api/Basket/BasketListByMenuTableWithProductName?id={id}");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultBasketDto>>(jsonData);
                    return View(values);
                }

                return View();
            }

            // Sepetten ürün silme
            public async Task<IActionResult> DeleteBasket(int id, int menuTableId)
{
    var client = _httpClientFactory.CreateClient();

    // 1. Ürünü sil
    var responseMessage = await client.DeleteAsync($"http://localhost:5044/api/Basket/{id}");

    if (responseMessage.IsSuccessStatusCode)
    {
        // 2. Sepet tamamen boş kaldı mı kontrol et
        var kontrolClient = _httpClientFactory.CreateClient();
        var kontrolResponse = await kontrolClient.GetAsync($"http://localhost:5044/api/Basket/BasketListByMenuTableWithProductName?id={menuTableId}");

        if (kontrolResponse.IsSuccessStatusCode)
        {
            var json = await kontrolResponse.Content.ReadAsStringAsync();
            var kalanUrunler = JsonConvert.DeserializeObject<List<object>>(json); // Dto modelin varsa onu yaz

            if (kalanUrunler == null || kalanUrunler.Count == 0)
            {
                // 3. Masa boş hale getirilir
                await client.GetAsync($"http://localhost:5044/api/MenuTables/ChangeMenuTableStatusToFalse?id={menuTableId}");
            }
        }

        // 4. Sepet ekranına dön
        return RedirectToAction("Index", new { id = menuTableId });
    }

    return NoContent();
}

        }

    }

