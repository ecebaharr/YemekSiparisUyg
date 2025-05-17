using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.DtoLayer.MessageDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public IActionResult MessageList()
        {
            var result = _messageService.TGetAll();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            Message message = new Message
            {
                Mail = createMessageDto.Mail,
                MessageContent = createMessageDto.MessageContent,
                MessageSendDate = DateTime.Now,
                NameSurname = createMessageDto.NameSurname,
                Phone = createMessageDto.Phone,
                Subject = createMessageDto.Subject,
                Status = false


            };
            _messageService.TAdd(message);
            return Ok("Mesaj başarılı bir şekilde gönderildi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id)
        {
            var values = _messageService.TGetbyID(id);
            _messageService.TDelete(values);
            return Ok("Mesaj silindi.");
        }

        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            Message message = new Message
            {
                Mail = updateMessageDto.Mail,
                MessageContent = updateMessageDto.MessageContent,
                MessageSendDate = updateMessageDto.MessageSendDate,
                NameSurname = updateMessageDto.NameSurname,
                Phone = updateMessageDto.Phone,
                Subject = updateMessageDto.Subject,
                Status = false,
                MessageID = updateMessageDto.MessageID
            };

            _messageService.TUpdate(message);
            return Ok("Mesaj başarılı bir şekilde  güncellendi.");
        }


        [HttpGet("{id}")]
        public IActionResult GetMessage(int id)
        {
            var result = _messageService.TGetbyID(id);
            return Ok(result);
        }


    }
}

