using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _SocialMediaService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService SocialMediaService, IMapper mapper)
        {
            _SocialMediaService = SocialMediaService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var value = _mapper.Map<List<ResultSocialMediaDto>>(_SocialMediaService.TGetAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)

        {
            var value = _mapper.Map<SocialMedia>(createSocialMediaDto);
            _SocialMediaService.TAdd(value);
            return Ok("Sosyal medya bilgileri sisteme başarıyla eklendi.");

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSocialMedia(int id)
        {
            var value = _SocialMediaService.TGetbyID(id);
            _SocialMediaService.TDelete(value);
            return Ok("Sosyal medya bilgileri sisteme başarıyla silindi.");
        }

        [HttpGet("{id}")]

        public IActionResult GetSocialMedia(int id)
        {
            var value = _SocialMediaService.TGetbyID(id);
            return Ok(_mapper.Map<GetSocialMediaDto>(value));
        }

        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var value = _mapper.Map<SocialMedia>(updateSocialMediaDto);
            _SocialMediaService.TUpdate(value);
            return Ok("Sosyal medya bilgileri başarıyla güncellendi.");

        }
    }
}
