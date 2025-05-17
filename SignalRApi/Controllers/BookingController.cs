using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;
        //private readonly IValidator<CreateBookingDto> _validator;
        public BookingController(IBookingService bookingService, IMapper mapper /*IValidator<CreateBookingDto> validator*/)
        {
            _bookingService = bookingService;
            _mapper = mapper;
            //_validator = validator;
        }
        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetAll();
            return Ok(_mapper.Map<List<ResultBookingDto>>(values));
        }

        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {

            var value =_mapper.Map<Booking>(createBookingDto);
            _bookingService.TAdd(value);
            return Ok("Rezervasyon Yapıldı");

            //var validationResult = _validator.Validate(createBookingDto);
            //if (!validationResult.IsValid)
            //{
            //    return BadRequest(validationResult.Errors);
            //}
            //var value = _mapper.Map<Booking>(createBookingDto);
            //_bookingService.TAdd(value);
            //return Ok("Rezervasyon Yapıldı");
            //// 💡 Eğer Description boşsa, varsayılan değer ver
            //if (string.IsNullOrEmpty(createBookingDto.Description))
            //{
            //    createBookingDto.Description = "Açıklama girilmedi.";
            //}

            //// 🎯 Booking entity'sini oluştur
            //var booking = new Booking
            //{
            //    Mail = createBookingDto.Mail,
            //    Date = createBookingDto.Date,
            //    Name = createBookingDto.Name,
            //    PersonCount = createBookingDto.PersonCount,
            //    Phone = createBookingDto.Phone,
            //    Description = createBookingDto.Description // ✅ unutma!
            //};

            //// ✅ Veritabanına ekle
            //_bookingService.TAdd(booking);

            //return Ok("Rezervasyonunuz başarıyla oluşturulmuştur. Sağlıcakla kalın!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var value = _bookingService.TGetbyID(id);
            _bookingService.TDelete(value);
            
            return Ok("Rezervasyonunuz başarıyla silinmiştir.");
        }
        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            var value = _mapper.Map<Booking>(updateBookingDto);
            _bookingService.TUpdate(value);
            return Ok("Rezervasyonunuz başarıyla güncellenmiştir.");
        }
        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var value = _bookingService.TGetbyID(id);
            return Ok(_mapper.Map<GetBookingDto>(value));
        }
        [HttpGet("BookingStatusApproved/{id}")]
        public IActionResult BookingStatusApproved(int id)
        {
            _bookingService.BookingStatusApproved(id);
            return Ok("Rezervasyon Açıklaması Değiştirildi");
        }
        [HttpGet("BookingStatusCancelled/{id}")]
        public IActionResult BookingStatusCancelled(int id)
        {
            _bookingService.BookingStatusCancelled(id);
            return Ok("Rezervasyon Açıklaması Değiştirildi");
        }

    }
}
