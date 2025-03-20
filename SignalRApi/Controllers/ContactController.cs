using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ContactList()
        {
            var value = _mapper.Map<List<ResultContactDto>>(_contactService.TGetAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)

        {
            _contactService.TAdd(new Contact()
            {
               
                FooterDescripton = createContactDto.FooterDescripton,
                Location = createContactDto.Location,
                Mail = createContactDto.Mail,
                Phone = createContactDto.Phone,
               
            }
                );
            return Ok("İletişim bilgileri başarıyla sisteme eklendi.");

        }

        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var value = _contactService.TGetbyID(id);
            _contactService.TDelete(value);
            return Ok("İletişim bilgileri başarıyla sistemden silindi.");
        }

        [HttpGet("GetContact")]

        public IActionResult GetContact(int id)
        {
            var value = _contactService.TGetbyID(id);

            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            _contactService.TUpdate(new Contact()
            {
                ContactID = updateContactDto.ContactID,
               FooterDescripton = updateContactDto.FooterDescripton,
               Location = updateContactDto.Location,
               Mail = updateContactDto.Mail,
               Phone = updateContactDto.Phone,
            }
                );
            return Ok("İletişim bilgileri başarıyla güncellendi.");

        }
    }
}

