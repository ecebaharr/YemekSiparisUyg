using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MenuTableDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTablesController : ControllerBase
    { private readonly IMenuTableService _menuTableService;

        public MenuTablesController(IMenuTableService menuTableService)
        {
            _menuTableService = menuTableService;
        }
        [HttpGet("MenuTableCount")]
        public IActionResult MenuTableCount()
        {return Ok(_menuTableService.TMenuTableCount()); }


        [HttpGet]
        public IActionResult MenuTableList()
        {
            var result = _menuTableService.TGetAll();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateMenuTable(CreateMenuTableDto createMenuTableDto)
        {
            MenuTable menuTable = new MenuTable()
            {
                Name = createMenuTableDto.Name,
                Status = false,

            };
            _menuTableService.TAdd(menuTable);
            return Ok("Masa başarılı bir şekilde eklendi.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMenuTable(int id)
        {
            var values = _menuTableService.TGetbyID(id);
            _menuTableService.TDelete(values);
            return Ok("Masa başarılı bir şekilde silindi.");
        }

        [HttpPut]
        public IActionResult UpdateMenuTable(UpdateMenuTableDto updateMenuTableDto)
        {
            MenuTable menuTable = new MenuTable
            {
                Name = updateMenuTableDto.Name,
                Status = false,
                MenuTableID = updateMenuTableDto.MenuTableID,

            };

            _menuTableService.TUpdate(menuTable);
            return Ok("Masa bilgisi başarılı bir şekilde güncellendi.");
        }


        [HttpGet("{id}")]
        public IActionResult GetMenuTable(int id)
        {
            var result = _menuTableService.TGetbyID(id);
            return Ok(result);
        }
    }
        }

