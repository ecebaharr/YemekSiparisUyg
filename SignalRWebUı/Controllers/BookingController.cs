using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUı.Dtos.BookingDtos;
using SignalRWebUı.Dtos.CategoryDtos;

namespace SignalRWebUı.Controllers
{
    public class BookingController : Controller
    {
       
            private readonly IHttpClientFactory _httpClientFactory;

            public BookingController(IHttpClientFactory httpClientFactory)
            {
                _httpClientFactory = httpClientFactory;
            }

            public async Task<IActionResult> Index()
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync("http://localhost:5044/api/Booking");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
                    return View(values);
                }
                return View();
            }
            [HttpGet]
            public IActionResult CreateBooking()
            {
                return View();
            }
            [HttpPost]
            public async Task<IActionResult> CreateBooking(CreateBookingDto createBookingDto)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(createBookingDto);
                StringContent StringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = client.PostAsync("http://localhost:5044/api/Booking", StringContent).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
            public async Task<IActionResult> DeleteBooking(int id)
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.DeleteAsync($"http://localhost:5044/api/Booking/{id}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
            [HttpGet]
            public async Task<IActionResult> UpdateBooking(int id)
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync($"http://localhost:5044/api/Booking/{id}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<UpdateBookingDto>(jsonData);
                    return View(values);
                }
                return View();
            }
            [HttpPost]
            public async Task<IActionResult> UpdateBooking(UpdateBookingDto updateBookingDto)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(updateBookingDto);
                StringContent StringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("http://localhost:5044/api/Booking", StringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
        }
    }

