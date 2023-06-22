using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HotelListing.IRepository;
using HotelListing.Models.HotelDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HotelListing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        private readonly ILogger<HotelController> logger;

        public HotelController(IUnitOfWork uow, IMapper mapper, ILogger<HotelController> logger)
        {
            this.uow = uow;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet("GetHotels")]
        public async Task<IActionResult> GetHotels()
        {
            try
            {
                var hotels = await uow.Hotels.GetAll();
                var hotelsDto = mapper.Map<IList<HotelDto>>(hotels);
                return Ok(hotelsDto);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Something went wrong in the {nameof(GetHotels)}");
                return StatusCode(500, "Internal server error, Something went wrong, please try again later");
            }
        }

        [Authorize]
        [HttpGet("GetHotel/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetHotel(int id)
        {
            try
            {
                var hotel = await uow.Hotels.Get(q => q.Id == id, new List<string> { "Country" });
                var hotelDto = mapper.Map<HotelDto>(hotel);
                return Ok(hotelDto);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Something went wrong in the {nameof(GetHotel)}");
                return StatusCode(500, "Internal server error, Something went wrong, please try again later");
            }
        }
    }
}
