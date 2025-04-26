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
            _SocialMediaService.TAdd(new SocialMedia()
            {
                
                Url = createSocialMediaDto.Url,
                Title = createSocialMediaDto.Title,
                Icon = createSocialMediaDto.Icon



            }
                );
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

            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            _SocialMediaService.TUpdate(new SocialMedia()
            {
                Icon = updateSocialMediaDto.Icon,
                Title = updateSocialMediaDto.Title,

                SocialMediaID = updateSocialMediaDto.SocialMediaID,
                Url = updateSocialMediaDto.Url

            }
                );
            return Ok("Sosyal medya bilgileri başarıyla güncellendi.");

        }
    }
}
