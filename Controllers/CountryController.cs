using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HotelListing.IRepository;
using HotelListing.Models.Country;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelListing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly ILogger<CountryController> _logger;
        private readonly IMapper mapper;

        public CountryController(IUnitOfWork uow, ILogger<CountryController> logger, IMapper mapper)
        {
            _uow = uow;
            _logger = logger;
            this.mapper = mapper;
        }

        [HttpGet("GetCountries")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                var countries = await _uow.Countries.GetAll();
                var countriesDto = mapper.Map<IList<CountryDto>>(countries);
                return Ok(countriesDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetCountries)}");
                return StatusCode(500, "Internal server error, Something went wrong, please try again later");
            }
        }

        [HttpGet("GetCountry/{id:int}")]
        public async Task<IActionResult> GetCountry(int id)
        {
            try
            {
                var country = await _uow.Countries.Get(q=>q.Id == id, new List<string> { "Hotels"});
                var countryDto = mapper.Map<CountryDto>(country);
                return Ok(countryDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetCountry)}");
                return StatusCode(500, "Internal server error, Something went wrong, please try again later");
            }
        }
    }
}
