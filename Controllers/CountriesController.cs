using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelListing.API.Data;
using HotelListing.API.Models.Country;
using AutoMapper;
using HotelListing.API.Contracts;
using HotelListing.API.Repository;
using System.Diagnostics.Metrics;

namespace HotelListing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICountriesRepository _countriesRepository;

        public CountriesController(IMapper mapper, ICountriesRepository countriesRepository)
        {
            _mapper = mapper;
            _countriesRepository = countriesRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCountryDto>>> GetCountries()
        {
            List<Country> countries = await _countriesRepository.GetAllAsync();
            List<GetCountryDto> mappedCountries = _mapper.Map<List<GetCountryDto>>(countries);
            return Ok(mappedCountries);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDto>> GetCountry(int id)
        {
            Country country = await _countriesRepository.GetDetailsAsync(id);
            if (country is null)
            {
                var data = new { status = false, message = $"not found country with id [{id}]" };
                return NotFound(data);
            }

            CountryDto countryDto = _mapper.Map<CountryDto>(country);

            return Ok(countryDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, UpdateCountryDto updateCountryDto)
        {
            if (id != updateCountryDto.Id)
            {
                return BadRequest("Invalid Record Id");
            }

            Country country = await _countriesRepository.GetAsync(id);
            if (country is null)
            {
                var data = new { status = false, message = $"not found country with id [{id}]" };
                return NotFound(data);
            }

            _mapper.Map(updateCountryDto, country);
            try 
            {
                await _countriesRepository.UpdateAsync(country);
            }
            catch (DbUpdateConcurrencyException) 
            {
                if (!await CountryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(CreateCountryDto createCountryDto)
        {

            Country country = _mapper.Map<Country>(createCountryDto);
            await _countriesRepository.AddAsync(country);

            return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            Country country = await _countriesRepository.GetAsync(id);
            if (country is null)
            {
                var data = new { status = false, message = $"not found country with id [{id}]" };
                return NotFound(data);
            }

            await _countriesRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> CountryExists(int id)
        {
            return await _countriesRepository.Exists(id);
        }
    }
}
