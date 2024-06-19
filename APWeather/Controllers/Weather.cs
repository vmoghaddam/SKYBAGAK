using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APWeather.Models;
using Microsoft.EntityFrameworkCore;
using APWeather.Services;

namespace APWeather.Controllers
{
     [Route("api/[controller]")]
    [ApiController]
    public class Weather : ControllerBase
    {
        private readonly ppa_vareshContext _context;
        private IWeatherService _weatherService;
        public Weather(ppa_vareshContext context, IWeatherService weatherService )
        {

            _context = context;
            _weatherService = weatherService;
           
        }

        [HttpGet]

        [Route("test")]
        public async Task<IActionResult> GetTEST()
        {
             
            return Ok(DateTime.Now);
        }


        [HttpGet]

        [Route("metar/last/{station}")]
        public async Task<IActionResult> GetMETAR_LAST(string station)
        {
            try
            {
                var result = await _weatherService.GetLastMetar(station);
                return Ok(result);
            }
            catch(Exception ex)
            {
                var msg = ex.Message;
                if (ex.InnerException != null)
                    msg += "    " + ex.InnerException.Message;
                return Ok(msg);
            }
          
        }
        [HttpGet]

        [Route("metar/last/stations/{station}")]
        public async Task<IActionResult> GetMETAR_LASTSTATIONS(string station)
        {
            try
            {
                var result = await _weatherService.GetLastMetarStations(station);
                return Ok(result);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                if (ex.InnerException != null)
                    msg += "    " + ex.InnerException.Message;
                return Ok(msg);
            }

        }
        [HttpGet]
        [Route("metar/fdp/{fdpid}")]
        public async Task<IActionResult > GetMETAR_FDP(int fdpid)
        {
            var result = await _weatherService.GetFDPMetars(fdpid);
            return Ok(result);
        }

        [HttpGet]
        [Route("metar/route/{rts}/{stns}/{std}/{sta}")]
        public async Task<IActionResult> GetMETAR_ROUTES(string rts,string stns,string std,string sta)
        {
            var result = await _weatherService.GetFDPMetarsByROUTE(stns, rts, std, sta);
            return Ok(result);
        }

        [Route("metar/flight/{flt}")]
        public async Task<IActionResult> GetMETAR_Flight(int flt)
        {
            var result = await _weatherService.GetFlightMetars(flt);
            return Ok(result);
        }

        [Route("taf/fdp/{fdpid}")]
        public async Task<IActionResult> GetTAF_FDP(int fdpid)
        {
            var result = await _weatherService.GetFDPTafs(fdpid);
            return Ok(result);
        }
        [Route("taf/flight/{flt}")]
        public async Task<IActionResult> GetTAF_Flight(int flt)
        {
            var result = await _weatherService.GetFlightTafs(flt);
            return Ok(result);
        }
        [Route("notam/fdp/{fdpid}")]
        public async Task<IActionResult> GetNOTAM_FDP(int fdpid)
        {
            var result = await _weatherService.GetFDPNOTAMs(fdpid);
            return Ok(result);
        }

        [Route("notam/flight/{flt}")]
        public async Task<IActionResult> GetNOTAM_Flight(int flt)
        {
            var result = await _weatherService.GetFlightNOTAMs(flt);
            return Ok(result);
        }

        [Route("metar/adds/all")]
        public async Task<ActionResult> GetMETARADDS_All()
        {
            //var result = await _weatherService.GetMETAR_ADDS_ALL();
            var result = await _weatherService.GetMETAR_ADDS_ALL_2024();
            if (!result.IsSuccess)
                return NotFound(result.Errors);
            return Ok(result);
        }

        [Route("metar/adds/all/new")]
        public async Task<ActionResult> GetMETARADDS_All_New()
        {
            var result = await _weatherService.GetMETAR_ADDS_ALL_NEW();
            if (!result.IsSuccess)
                return NotFound(result.Errors);
            return Ok(result);
        }

        [Route("taf/adds/all")]
        public async Task<ActionResult> GetTAFADDS_All()
        {
            var result = await _weatherService.GetTAF_ADDS_All_2024();
            if (!result.IsSuccess)
                return NotFound(result.Errors);
            return Ok(result);
        }

        [HttpGet]
        //[Authorize]
        [Route("notam/all")]
        public async Task<IActionResult> GetAirportNotamAll()
        {
            try
            {
                var result = await _weatherService.GetAirportNotamAll();
                if (!result.IsSuccess)
                    return NotFound(result.Errors);
                return Ok(result);
            }
            catch(Exception ex)
            {
                var msg = ex.Message;
                if (ex.InnerException != null)
                    msg += "  INNER:  "+ex.InnerException.Message;
                return Ok(msg);
            }
          



        }

        [Route("metars/now")]
        public async Task<ActionResult> GetMETARsNow()
        {
            var result = await _weatherService.GetMetarByDateNow();
            
            return Ok(result);
        }
        [Route("taf/now")]
        public async Task<ActionResult> GetTAFNow()
        {
            var result = await _weatherService.GetTafByDateNow();

            return Ok(result);
        }
        [Route("notam/now")]
        public async Task<ActionResult> GetNotamNow()
        {
            var result = await _weatherService.GetNotamByDateNow();

            return Ok(result);
        }

        [Route("wx")]
        public async Task<ActionResult> GetWX()
        {
            var result = await _weatherService.GetWX();

            return Ok(result);
        }
        [Route("wxmetar")]
        public async Task<ActionResult> GetWXMetar()
        {
            var result = await _weatherService.GetWXMetar();

            return Ok(result);
        }

    }
}
