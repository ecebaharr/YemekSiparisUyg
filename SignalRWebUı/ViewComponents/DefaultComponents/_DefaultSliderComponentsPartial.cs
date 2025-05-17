using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUı.Dtos.SliderDtos;

namespace SignalRWebUı.ViewComponents.DefaultComponents
{
    public class _DefaultSliderComponentsPartial : ViewComponent
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultSliderComponentsPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5044/api/Slider");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultSliderDto>>(jsonData);
            return View(values);
        }
    }
}