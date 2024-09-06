using APWeather.Models;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.Net.Mime;
using System.Runtime.InteropServices.ComTypes;
using System.Net.Http;

using System.Text.RegularExpressions;
using System.Xml.Linq;
using HtmlAgilityPack;
using Newtonsoft.Json;

namespace APWeather.Services
{
    public interface IWeatherService
    {
        Task<DataResponse> GetLastMetar(string station);
        Task<DataResponse> GetLastMetarStations(string station);
        Task<DataResponse> GetFDPMetars(int fdpId);
        Task<DataResponse> GetFDPMetarsByROUTE(string stns, string rts, string std, string sta);
        Task<DataResponse> GetFDPNOTAMs(int fdpId);
        Task<DataResponse> GetFDPTafs(int fdpId);

        Task<DataResponse> GetFlightMetars(int flt);
        Task<DataResponse> GetFlightNOTAMs(int flt);
        Task<DataResponse> GetFlightTafs(int flt);

        Task<DataResponse> GetMETAR_ADDS_ALL();
        Task<DataResponse> GetMETAR_ADDS_ALL_2024();
        Task<DataResponse> GetMETAR_ADDS_ALL_NEW();
        Task<DataResponse> GetTAF_ADDS_All();
        Task<DataResponse> GetTAF_ADDS_All_2024();
        Task<DataResponse> GetAirportNotamAll();


        Task<DataResponse> GetWX();
        Task<DataResponse> GetWXMetar();
        Task<object> GetMetarByDateNow();
        Task<object> GetTafByDateNow();
        Task<object> GetNotamByDateNow();

    }
    public class WeatherService : IWeatherService
    {
        private readonly ppa_vareshContext _context;
        private IConfiguration _configuration;
        public WeatherService(ppa_vareshContext context, IConfiguration configuration)
        {
            _context = context;

            _configuration = configuration;
        }

        public async Task<DataResponse> GetFDPMetars(int fdpId)
        {
            try
            {

                var flights = await _context.AppCrewFlight.Where(q =>
                       q.FDPId == fdpId
                ).OrderBy(q => q.STD).ToListAsync();
                var _stations = new List<string>();
                var routes = new List<string>();
                foreach (var f in flights)
                {
                    _stations.Add(f.FromAirportIATA);
                    _stations.Add(f.ToAirportIATA);
                    routes.Add(f.FromAirportIATA + "-" + f.ToAirportIATA);
                    if (!string.IsNullOrEmpty(f.ALT1))
                        _stations.Add(f.ALT1);
                    if (!string.IsNullOrEmpty(f.ALT2))
                        _stations.Add(f.ALT2);
                }
                _stations = _stations.Distinct().ToList();
                var escape = await _context.ViewEscapeRoute.Where(q => routes.Contains(q.Route)).ToListAsync();
                foreach (var es in escape)
                {
                    if (_stations.IndexOf(es.R1) == -1)
                        _stations.Add(es.R1);
                    if (_stations.IndexOf(es.R2) == -1)
                        _stations.Add(es.R2);
                    if (_stations.IndexOf(es.R3) == -1)
                        _stations.Add(es.R3);
                    if (_stations.IndexOf(es.R4) == -1)
                        _stations.Add(es.R4);
                    if (_stations.IndexOf(es.R5) == -1)
                        _stations.Add(es.R5);
                }
                _stations = _stations.Where(q => q != "-").Distinct().ToList();
                var stations = string.Join(',', _stations);


                var baseDate = (DateTime.Now).Date;
                var metars = await _context.WeatherMetar.Where(q => q.DateDay == baseDate && stations.Contains(q.StationId)).ToListAsync();
                foreach (var m in metars)
                    m.temp_c = -1000;
                var result = metars.OrderBy(q => stations.IndexOf(q.StationId)).OrderByDescending(q => q.observation_time).ToList();
                return new DataResponse
                {
                    Data = result,
                    Errors = null,
                    IsSuccess = true
                };


            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                if (ex.InnerException != null)
                    msg += " INNER: " + ex.InnerException.Message;
                return new DataResponse
                {
                    Data = null,
                    Errors = new List<string>() { msg },
                    IsSuccess = true
                };
            }


        }

        //2024-05-11
        public async Task<DataResponse> GetFDPMetarsByROUTE(string stns, string rts, string std, string sta)
        {
            try
            {

                // var flights = await _context.AppCrewFlight.Where(q =>
                //        q.FDPId == fdpId
                // ).OrderBy(q => q.STD).ToListAsync();
                var _stations = stns.Split('*').ToList();
                var routes = rts.Split('*').ToList();
                //foreach (var f in flights)
                //{
                //    _stations.Add(f.FromAirportIATA);
                //    _stations.Add(f.ToAirportIATA);
                //    routes.Add(f.FromAirportIATA + "-" + f.ToAirportIATA);
                //    if (!string.IsNullOrEmpty(f.ALT1))
                //        _stations.Add(f.ALT1);
                //    if (!string.IsNullOrEmpty(f.ALT2))
                //        _stations.Add(f.ALT2);
                //}
                //_stations = _stations.Distinct().ToList();
                var escape = await _context.ViewEscapeRoute.Where(q => routes.Contains(q.Route)).ToListAsync();
                foreach (var es in escape)
                {
                    if (_stations.IndexOf(es.R1) == -1)
                        _stations.Add(es.R1);
                    if (_stations.IndexOf(es.R2) == -1)
                        _stations.Add(es.R2);
                    if (_stations.IndexOf(es.R3) == -1)
                        _stations.Add(es.R3);
                    if (_stations.IndexOf(es.R4) == -1)
                        _stations.Add(es.R4);
                    if (_stations.IndexOf(es.R5) == -1)
                        _stations.Add(es.R5);
                }
                _stations = _stations.Where(q => q != "-").Distinct().ToList();
                var stations = string.Join(',', _stations);

                var _dates = new List<DateTime?>();
                _dates.Add(str_to_datetime(std));
                _dates.Add(str_to_datetime(sta));

                var dt_std = str_to_datetime(std);
                var dt_sta = str_to_datetime(sta).AddHours(2);

                var date_to = dt_sta;
                var date_from = dt_sta.AddHours(-12);


                // var baseDate = (DateTime.Now).Date;

                var url = "https://aviationweather.gov/api/data/metar?format=json&ids=" + stations + "&hours=12&date=" + date_to.ToString("yyyyMMdd_HHmm59");   //"20240511_235959Z";
                try
                {
                    List<WeatherMetar> online_result = new List<WeatherMetar>();
                    using (WebClient webClient = new WebClient())
                    {

                        var str_metar = webClient.DownloadString(url);
                        var res = JsonConvert.DeserializeObject<List<metar_response_obj>>(str_metar);

                        foreach (var row in res)
                        {
                            var metar = new Models.WeatherMetar()
                            {
                                DateDay = cast_as_date(row.reportTime).Date,
                                DateCreate = DateTime.Now,
                                RawText = row.rawOb,
                                StationId = row.icaoId,
                                // observation_time = string.IsNullOrEmpty((string)item.Element("observation_time")) ? null : (Nullable<DateTime>)Convert.ToDateTime((string)item.Element("observation_time")).ToUniversalTime(),
                                observation_time = cast_as_date(row.reportTime),
                                metar_id = row.metar_id,
                                temp_c=-1000,
                                Id=(int)row.metar_id,
                               // response_text = JsonConvert.SerializeObject(row),


                            };
                            

                            online_result.Add(metar);
                        }
                        online_result = online_result.OrderByDescending(q => q.observation_time).ToList();
                        return new DataResponse
                        {
                            Data = online_result,
                            Errors = null,
                            IsSuccess = true
                        };
                    }

                }
                catch (Exception ex)
                {
                    var metars = await _context.WeatherMetar.Where(q => q.observation_time >= date_from && q.observation_time <= date_to && stations.Contains(q.StationId)).ToListAsync();
                    foreach (var m in metars)
                        m.temp_c = -1000;
                    var result = metars.OrderBy(q => stations.IndexOf(q.StationId)).OrderByDescending(q => q.observation_time).ToList();
                    return new DataResponse
                    {
                        Data = result,
                        Errors = null,
                        IsSuccess = true
                    };

                }


            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                if (ex.InnerException != null)
                    msg += " INNER: " + ex.InnerException.Message;
                return new DataResponse
                {
                    Data = null,
                    Errors = new List<string>() { msg },
                    IsSuccess = true
                };
            }


        }


        public async Task<DataResponse> GetLastMetar(string station)
        {
            try
            {

                var metar = await _context.WeatherMetar.Where(q => q.StationId == station).OrderByDescending(q => q.observation_time).FirstOrDefaultAsync();



                return new DataResponse
                {
                    Data = metar,
                    Errors = null,
                    IsSuccess = true
                };


            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                if (ex.InnerException != null)
                    msg += " INNER: " + ex.InnerException.Message;
                return new DataResponse
                {
                    Data = null,
                    Errors = new List<string>() { msg },
                    IsSuccess = true
                };
            }


        }

        public async Task<DataResponse> GetLastMetarStations(string station)
        {
            try
            {
                var stn = station.Split("_").ToList();
                // var metar = await _context.WeatherMetar.Where(q =>stn.Contains( q.StationId)).OrderByDescending(q => q.observation_time).FirstOrDefaultAsync();
                var query = (from x in _context.WeatherMetar
                             group x by new { x.StationId } into grp
                             select new
                             {
                                 station = grp.Key.StationId,
                                 items = grp.OrderByDescending(q => q.observation_time).Select(q => q.RawText).Take(20)

                             });
                var res = await query.ToListAsync();



                return new DataResponse
                {
                    Data = res,
                    Errors = null,
                    IsSuccess = true
                };


            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                if (ex.InnerException != null)
                    msg += " INNER: " + ex.InnerException.Message;
                return new DataResponse
                {
                    Data = null,
                    Errors = new List<string>() { msg },
                    IsSuccess = true
                };
            }


        }

        public async Task<DataResponse> GetFlightMetars(int flt)
        {
            var flight = await _context.AppCrewFlight.Where(q =>
                   q.FlightId == flt
            ).FirstOrDefaultAsync();
            var _stations = new List<string>();
            var routes = new List<string>();

            _stations.Add(flight.FromAirportIATA);
            _stations.Add(flight.ToAirportIATA);
            routes.Add(flight.FromAirportIATA + "-" + flight.ToAirportIATA);
            if (!string.IsNullOrEmpty(flight.ALT1))
                _stations.Add(flight.ALT1);
            if (!string.IsNullOrEmpty(flight.ALT2))
                _stations.Add(flight.ALT2);

            _stations = _stations.Distinct().ToList();
            var escape = await _context.ViewEscapeRoute.Where(q => routes.Contains(q.Route)).ToListAsync();
            foreach (var es in escape)
            {
                if (_stations.IndexOf(es.R1) == -1)
                    _stations.Add(es.R1);
                if (_stations.IndexOf(es.R2) == -1)
                    _stations.Add(es.R2);
                if (_stations.IndexOf(es.R3) == -1)
                    _stations.Add(es.R3);
                if (_stations.IndexOf(es.R4) == -1)
                    _stations.Add(es.R4);
                if (_stations.IndexOf(es.R5) == -1)
                    _stations.Add(es.R5);
            }
            _stations = _stations.Where(q => q != "-").Distinct().ToList();
            var stations = string.Join(',', _stations);


            //var baseDate = (DateTime.Now).Date;
            var baseDate = ((DateTime)flight.STDDay).Date;
            var metars = await _context.WeatherMetar.Where(q => q.DateDay == baseDate && stations.Contains(q.StationId)).ToListAsync();
            foreach (var m in metars)
                m.temp_c = -1000;
            var result = metars.OrderBy(q => stations.IndexOf(q.StationId)).OrderByDescending(q => q.observation_time).ToList();
            return new DataResponse
            {
                Data = result,
                Errors = null,
                IsSuccess = true
            };


        }

        public async Task<DataResponse> GetFDPTafs(int fdpId)
        {
            var flights = await _context.AppCrewFlight.Where(q =>
                   q.FDPId == fdpId
            ).OrderBy(q => q.STD).ToListAsync();
            var _stations = new List<string>();
            var routes = new List<string>();
            foreach (var f in flights)
            {
                _stations.Add(f.FromAirportIATA);
                _stations.Add(f.ToAirportIATA);
                routes.Add(f.FromAirportIATA + "-" + f.ToAirportIATA);
                if (!string.IsNullOrEmpty(f.ALT1))
                    _stations.Add(f.ALT1);
                if (!string.IsNullOrEmpty(f.ALT2))
                    _stations.Add(f.ALT2);
            }
            _stations = _stations.Distinct().ToList();
            var escape = await _context.ViewEscapeRoute.Where(q => routes.Contains(q.Route)).ToListAsync();
            foreach (var es in escape)
            {
                if (_stations.IndexOf(es.R1) == -1)
                    _stations.Add(es.R1);
                if (_stations.IndexOf(es.R2) == -1)
                    _stations.Add(es.R2);
                if (_stations.IndexOf(es.R3) == -1)
                    _stations.Add(es.R3);
                if (_stations.IndexOf(es.R4) == -1)
                    _stations.Add(es.R4);
                if (_stations.IndexOf(es.R5) == -1)
                    _stations.Add(es.R5);
            }
            _stations = _stations.Where(q => q != "-").Distinct().ToList();
            var stations = string.Join(',', _stations);


            var baseDate = (DateTime.Now).Date;
            var tafs = await _context.WeatherTaf.Where(q => q.DateDay == baseDate && stations.Contains(q.StationId)).ToListAsync();
            var result = tafs.OrderBy(q => stations.IndexOf(q.StationId)).OrderByDescending(q => q.IssueTime).ToList();
            return new DataResponse
            {
                Data = result,
                Errors = null,
                IsSuccess = true
            };


        }

        public async Task<DataResponse> GetFlightTafs(int flt)
        {
            var flight = await _context.AppCrewFlight.Where(q =>
                   q.FlightId == flt
            ).FirstOrDefaultAsync();
            var _stations = new List<string>();
            var routes = new List<string>();
            _stations.Add(flight.FromAirportIATA);
            _stations.Add(flight.ToAirportIATA);
            routes.Add(flight.FromAirportIATA + "-" + flight.ToAirportIATA);
            if (!string.IsNullOrEmpty(flight.ALT1))
                _stations.Add(flight.ALT1);
            if (!string.IsNullOrEmpty(flight.ALT2))
                _stations.Add(flight.ALT2);
            _stations = _stations.Distinct().ToList();
            var escape = await _context.ViewEscapeRoute.Where(q => routes.Contains(q.Route)).ToListAsync();
            foreach (var es in escape)
            {
                if (_stations.IndexOf(es.R1) == -1)
                    _stations.Add(es.R1);
                if (_stations.IndexOf(es.R2) == -1)
                    _stations.Add(es.R2);
                if (_stations.IndexOf(es.R3) == -1)
                    _stations.Add(es.R3);
                if (_stations.IndexOf(es.R4) == -1)
                    _stations.Add(es.R4);
                if (_stations.IndexOf(es.R5) == -1)
                    _stations.Add(es.R5);
            }
            _stations = _stations.Where(q => q != "-").Distinct().ToList();
            var stations = string.Join(',', _stations);


            //var baseDate = (DateTime.Now).Date;
            var baseDate = ((DateTime)flight.STDDay).Date;
            var tafs = await _context.WeatherTaf.Where(q => q.DateDay == baseDate && stations.Contains(q.StationId)).ToListAsync();
            var result = tafs.OrderBy(q => stations.IndexOf(q.StationId)).OrderByDescending(q => q.IssueTime).ToList();
            return new DataResponse
            {
                Data = result,
                Errors = null,
                IsSuccess = true
            };


        }


        public async Task<DataResponse> GetFDPNOTAMs(int fdpId)
        {
            var flights = await _context.AppCrewFlight.Where(q =>
                   q.FDPId == fdpId
            ).OrderBy(q => q.STD).ToListAsync();
            var _stations = new List<string>();
            var routes = new List<string>();
            foreach (var f in flights)
            {
                _stations.Add(f.FromAirportIATA);
                _stations.Add(f.ToAirportIATA);
                routes.Add(f.FromAirportIATA + "-" + f.ToAirportIATA);
                if (!string.IsNullOrEmpty(f.ALT1))
                    _stations.Add(f.ALT1);
                if (!string.IsNullOrEmpty(f.ALT2))
                    _stations.Add(f.ALT2);
            }
            _stations = _stations.Distinct().ToList();
            _stations.Add("OIIX");
            var escape = await _context.ViewEscapeRoute.Where(q => routes.Contains(q.Route)).ToListAsync();
            foreach (var es in escape)
            {
                if (_stations.IndexOf(es.R1) == -1)
                    _stations.Add(es.R1);
                if (_stations.IndexOf(es.R2) == -1)
                    _stations.Add(es.R2);
                if (_stations.IndexOf(es.R3) == -1)
                    _stations.Add(es.R3);
                if (_stations.IndexOf(es.R4) == -1)
                    _stations.Add(es.R4);
                if (_stations.IndexOf(es.R5) == -1)
                    _stations.Add(es.R5);
            }
            _stations = _stations.Where(q => q != "-").Distinct().ToList();
            var stations = string.Join(',', _stations);


            var baseDate = (DateTime.Now).Date;
            var notams = await _context.NOTAM.Where(q => q.DateDay == baseDate && _stations.Contains(q.StationId)).ToListAsync();
            var notamIds = notams.Select(q => q.Id).ToList();
            var notamItems = await _context.NOTAMItem.Where(q => notamIds.Contains(q.NOTAMId)).ToListAsync();
            foreach (var notam in notams)
                notam.NOTAMItem = notamItems.Where(q => q.NOTAMId == notam.Id).ToList();
            var result = notams.OrderBy(q => _stations.IndexOf(q.StationId)).OrderBy(q => q.Id).ToList();
            return new DataResponse
            {
                Data = result,
                Errors = null,
                IsSuccess = true
            };


        }


        public async Task<DataResponse> GetFlightNOTAMs(int flt)
        {
            var flight = await _context.AppCrewFlight.Where(q =>
                   q.FlightId == flt
            ).FirstOrDefaultAsync();
            var _stations = new List<string>();
            var routes = new List<string>();
            _stations.Add(flight.FromAirportIATA);
            _stations.Add(flight.ToAirportIATA);
            routes.Add(flight.FromAirportIATA + "-" + flight.ToAirportIATA);
            if (!string.IsNullOrEmpty(flight.ALT1))
                _stations.Add(flight.ALT1);
            if (!string.IsNullOrEmpty(flight.ALT2))
                _stations.Add(flight.ALT2);

            _stations = _stations.Distinct().ToList();
            _stations.Add("OIIX");
            var escape = await _context.ViewEscapeRoute.Where(q => routes.Contains(q.Route)).ToListAsync();
            foreach (var es in escape)
            {
                if (_stations.IndexOf(es.R1) == -1)
                    _stations.Add(es.R1);
                if (_stations.IndexOf(es.R2) == -1)
                    _stations.Add(es.R2);
                if (_stations.IndexOf(es.R3) == -1)
                    _stations.Add(es.R3);
                if (_stations.IndexOf(es.R4) == -1)
                    _stations.Add(es.R4);
                if (_stations.IndexOf(es.R5) == -1)
                    _stations.Add(es.R5);
            }
            _stations = _stations.Where(q => q != "-").Distinct().ToList();
            var stations = string.Join(',', _stations);


            //var baseDate = (DateTime.Now).Date;
            var baseDate = ((DateTime)flight.STDDay).Date;
            var notams = await _context.NOTAM.Where(q => q.DateDay == baseDate && _stations.Contains(q.StationId)).ToListAsync();
            var notamIds = notams.Select(q => q.Id).ToList();
            var notamItems = await _context.NOTAMItem.Where(q => notamIds.Contains(q.NOTAMId)).ToListAsync();
            foreach (var notam in notams)
                notam.NOTAMItem = notamItems.Where(q => q.NOTAMId == notam.Id).ToList();
            var result = notams.OrderBy(q => _stations.IndexOf(q.StationId)).OrderBy(q => q.Id).ToList();
            return new DataResponse
            {
                Data = result,
                Errors = null,
                IsSuccess = true
            };


        }
        //2024-02-06
        public class metar_obj
        {
            public string station { get; set; }
            public string time { get; set; }
            public string metar { get; set; }
            public DateTime obs_time { get; set; }
        }
        public async Task<DataResponse> GetMETAR_ADDS_ALL_NEW()
        {
            var stations = await _context.Airport.Where(q =>
            q.ICAO.StartsWith("OR")
            || q.ICAO.StartsWith("OI") 
           //|| q.ICAO.StartsWith("OR")
            || q.ICAO.StartsWith("UT")
           || q.ICAO.StartsWith("UG")
            || q.ICAO.StartsWith("OK")
             || q.ICAO.StartsWith("LT")
             || q.ICAO.StartsWith("UDYZ")

           ).Select(q => q.ICAO).ToListAsync();

            var station_dic = new Dictionary<string, List<string>>();
            station_dic.Add("OI", stations.Where(q => q.StartsWith("OI")).ToList());
            station_dic.Add("OR", stations.Where(q => q.StartsWith("OR")).ToList());
            station_dic.Add("UT", stations.Where(q => q.StartsWith("UT")).ToList());
            station_dic.Add("UG", stations.Where(q => q.StartsWith("UG")).ToList());
            station_dic.Add("OK", stations.Where(q => q.StartsWith("OK")).ToList());
            station_dic.Add("LT", stations.Where(q => q.StartsWith("LT")).ToList());

            station_dic.Add("UD", stations.Where(q => q.StartsWith("UD")).ToList());

            foreach (var kv in station_dic)
            {
                var key = kv.Key;

            }

            var _year = DateTime.Now.Year;
            var _month = DateTime.Now.Month;
            var _index = 0;
            var _station_grps = stations.GroupBy(x => _index++ / 10).ToList();
            List<metar_obj> raws = new List<metar_obj>();
            List<string> commands = new List<string>();

            foreach (var station in stations /*var station_grp in _station_grps*/)
            {
                // var _station_str = string.Join(',', station_grp.ToList());
                using (WebClient webClient = new WebClient())
                {
                    try
                    {
                        var url = "https://aviationweather.gov/cgi-bin/data/metar.php?ids=" + station + "&hours=0&order=id%20C-obs&sep=true";
                        var str = webClient.DownloadString(url);
                        str = str.Replace("\n", "");
                        if (!string.IsNullOrEmpty(str))
                        {
                            //LTAG 061120Z
                            var _time = str.Split(' ')[1];
                            var _day = Convert.ToInt32(str.Substring(5, 2));
                            var _hour = Convert.ToInt32(str.Substring(7, 2));
                            var _minute = Convert.ToInt32(str.Substring(9, 2));
                            var _key = str.Substring(5, 7);

                            var _obs_time = new DateTime(_year, _month, _day, _hour, _minute, 0);
                            commands.Add("DELETE FROM WeatherMetar WHERE STATIONID='" + station + "' AND flight_category='" + _key + "';");



                            // var _obs_time = new DateTime(_year, _month, _day, )) ;; ;
                            raws.Add(new metar_obj() { station = station, metar = str, time = _time, obs_time = _obs_time });
                        }

                    }
                    catch (Exception ex)
                    {
                        var fff = 0;
                    }



                }

            }

            if (commands.Count > 0)
            {
                _context.Database.ExecuteSqlCommand(string.Join("", commands));
            }
            await _context.SaveAsync();
            foreach (var x in raws)
            {
                _context.WeatherMetar.Add(new WeatherMetar()
                {
                    StationId = x.station,
                    observation_time = x.obs_time,
                    DateCreate = DateTime.Now,
                    DateDay = x.obs_time.Date,
                    RawText = x.metar,
                    flight_category = x.time,
                });
            }
            await _context.SaveAsync();





            return new DataResponse
            {
                Data = raws,
                Errors = null,
                IsSuccess = true
            };

        }
        public async Task<DataResponse> GetMETAR_ADDS_ALL()
        {

            var stations = await _context.Airport.Where(q => q.ICAO.StartsWith("OI") || q.ICAO.StartsWith("OR")
             || q.ICAO.StartsWith("UT")
             || q.ICAO.StartsWith("UG")
              || q.ICAO.StartsWith("OK")
               || q.ICAO.StartsWith("LT")
               || q.ICAO.StartsWith("UDYZ")

            ).Select(q => q.ICAO).ToListAsync();


            //var stations = await _context.Airport.Where(q =>  q.ICAO.StartsWith("OR")
            //).Select(q => q.ICAO).ToListAsync();
            //  stations = new List<string>() { "OIII" };
            // var oldTafs = await _context.WeatherTafs.Where(q => stations.Contains(q.StationId)).ToListAsync();

            var baseDate = DateTime.Now.Date;
            var tz1 = Math.Abs(TimeZoneInfo.Local.GetUtcOffset(baseDate).TotalMinutes);
            var offset1 = "";
            if (tz1 == 210)
                offset1 = "+0330";
            else
                offset1 = "+0430";
            //var from = baseDate.Date.ToString("yyyy-MM-dd") + "T00:00:00" + offset1;
            var from = DateTime.Now.ToString("yyyy-MM-dd") + "T" + DateTime.Now.AddHours(-2).ToString("HH:mm") + ":00" + offset1;
            var to = DateTime.Now.Date.AddDays(1).Date.ToString("yyyy-MM-dd") + "T00:00:00" + offset1;

            var d_from = DateTime.Now.AddHours(-2);
            var d_to = DateTime.Now.AddDays(1).Date;

            //var exist = await _context.WeatherMetar.Where(q => q.DateDay == baseDate && stations.Contains(q.StationId)).Select(q=>q.Id).ToListAsync();
            //if (exist.Count > 0)
            //{
            //    var exist_ids = string.Join(',', exist);

            //    _context.Database.ExecuteSqlCommand("Delete from WeatherMetar where id in (" + exist_ids + ")");

            //    var saveResult1 = await _context.SaveAsync();
            //}

            var station_dic = new Dictionary<string, List<string>>();
            station_dic.Add("OI", stations.Where(q => q.StartsWith("OI")).ToList());
            station_dic.Add("OR", stations.Where(q => q.StartsWith("OR")).ToList());
            station_dic.Add("UT", stations.Where(q => q.StartsWith("UT")).ToList());
            station_dic.Add("UG", stations.Where(q => q.StartsWith("UG")).ToList());
            station_dic.Add("OK", stations.Where(q => q.StartsWith("OK")).ToList());
            station_dic.Add("LT", stations.Where(q => q.StartsWith("LT")).ToList());

            station_dic.Add("UD", stations.Where(q => q.StartsWith("UD")).ToList());


            List<Models.WeatherMetar> result = new List<Models.WeatherMetar>();
            foreach (var kv in station_dic)
            {
                var key = kv.Key;

            }


            var _index = 0;
            var _station_grps = stations.GroupBy(x => _index++ / 10).ToList();

            var obs_times = new List<DateTime?>();
            foreach (/*var station in stations*/ var station_grp in _station_grps)
            {
                try
                {
                    var _station_str = string.Join(',', station_grp.ToList());
                    //  var url = "https://www.aviationweather.gov/adds/dataserver_current/httpparam?dataSource=metars&requestType=retrieve&format=xml&stationString="
                    var url = "https://aviationweather.gov/cgi-bin/data/dataserver.php?dataSource=metars&requestType=retrieve&format=xml&stationString="
                  //+ station
                  + _station_str
                  + "&hoursBeforeNow=8"
                  //+ "&startTime=" + from
                  //+ "&endTime=" + to
                  ;

                    XElement xml = XElement.Load(url);
                    var tafElements = xml.Descendants("METAR").ToList();
                    foreach (var item in tafElements)
                    {
                        var metar = new Models.WeatherMetar()
                        {
                            DateDay = baseDate.Date,
                            DateCreate = DateTime.Now,
                            RawText = (string)item.Element("raw_text"),
                            StationId = (string)item.Element("station_id"),
                            observation_time = string.IsNullOrEmpty((string)item.Element("observation_time")) ? null : (Nullable<DateTime>)Convert.ToDateTime((string)item.Element("observation_time")).ToUniversalTime(),

                            // latitude = Convert.ToDouble((string)item.Element("latitude")),
                            // longitude = Convert.ToDouble((string)item.Element("longitude")),
                            // temp_c = Convert.ToDouble((string)item.Element("temp_c")),

                            // dewpoint_c = Convert.ToDouble((string)item.Element("dewpoint_c")),
                            // wind_dir_degrees = Convert.ToInt32((string)item.Element("wind_dir_degrees")),
                            // wind_speed_kt = Convert.ToInt32((string)item.Element("wind_speed_kt")),
                            //  wind_gust_kt = Convert.ToInt32((string)item.Element("wind_gust_kt")),
                            //  visibility_statute_mi = Convert.ToDouble((string)item.Element("visibility_statute_mi")),
                            //  altim_in_hg = Convert.ToDouble((string)item.Element("altim_in_hg")),
                            // sea_level_pressure_mb = Convert.ToDouble((string)item.Element("sea_level_pressure_mb")),
                            // flight_category = (string)item.Element("flight_category"),
                            // three_hr_pressure_tendency_mb = Convert.ToDouble((string)item.Element("three_hr_pressure_tendency_mb")),
                            // maxT_c = Convert.ToDouble((string)item.Element("maxT_c")),
                            //  minT_c = Convert.ToDouble((string)item.Element("minT_c")),
                            // maxT24hr_c = Convert.ToDouble((string)item.Element("maxT24hr_c")),
                            // minT24hr_c = Convert.ToDouble((string)item.Element("minT24hr_c")),
                            //  precip_in = Convert.ToDouble((string)item.Element("precip_in")),
                            // pcp3hr_in = Convert.ToDouble((string)item.Element("pcp3hr_in")),
                            // pcp6hr_in = Convert.ToDouble((string)item.Element("pcp6hr_in")),
                            // pcp24hr_in = Convert.ToDouble((string)item.Element("pcp24hr_in")),
                            // snow_in = Convert.ToDouble((string)item.Element("snow_in")),
                            // vert_vis_ft = Convert.ToInt32((string)item.Element("vert_vis_ft")),
                            //  metar_type = (string)item.Element("metar_type"),
                            // elevation_m = Convert.ToDouble((string)item.Element("elevation_m")),

                            FlightId = null,
                            FDPId = null,

                        };
                        obs_times.Add((DateTime)metar.observation_time);
                        // metar.WeatherMetarSkyCondition = getSkyConditionsMETAR(item);
                        // metar.WeatherMetarQualityControl = getQualityControlMETAR(item);
                        //_context.WeatherMetar.Add(metar);
                        result.Add(metar);
                    }
                }
                catch (Exception ex)
                {

                }
            }
            obs_times = obs_times.Distinct().ToList();
            //var exist = await _context.WeatherMetar.Where(q => q.DateDay == baseDate && stations.Contains(q.StationId)).ToListAsync();
            //_context.WeatherMetar.RemoveRange(exist);


            //var exist = await _context.WeatherMetar.Where(q => q.DateDay == baseDate && stations.Contains(q.StationId)).Select(q => q.Id).ToListAsync();
            var exist = await _context.WeatherMetar.Where(q => q.DateDay == baseDate && stations.Contains(q.StationId) && obs_times.Contains(q.observation_time)).Select(q => q.Id).ToListAsync();
            if (exist.Count > 0)
            {
                var exist_ids = string.Join(',', exist);

                _context.Database.ExecuteSqlCommand("Delete from WeatherMetar where id in (" + exist_ids + ")");

                var saveResult1 = await _context.SaveAsync();
            }


            //var cnn = Configuration.GetConnectionString("EPDB");
            //  ppa_vareshContext _scontext = new ppa_vareshContext();
            // _scontext.ChangeTracker.AutoDetectChangesEnabled = false;
            var _sc_i = 0;
            foreach (var m in result)
            {
                _context.WeatherMetar.Add(m);
                _sc_i++;
                if (_sc_i % 100 == 0)
                {
                    var _sc_result = await _context.SaveAsync();
                    if (true)
                    {
                        _sc_i = 0;

                    }
                }
            }

            if (result.Count <= 100)
                await _context.SaveAsync();

            // var saveResult = await _context.SaveAsync();
            return new DataResponse
            {
                Data = result.Count,
                Errors = null,
                IsSuccess = true
            };


        }


        public class metar_response_obj
        {
            public int? metar_id { get; set; }
            public string icaoId { get; set; }
            public string receiptTime { get; set; }
            public string obsTime { get; set; }
            public string reportTime { get; set; }
            public string temp { get; set; }
            public string dewp { get; set; }
            public string wdir { get; set; }
            public string wspd { get; set; }
            public object wgst { get; set; }
            public string visib { get; set; }
            public string altim { get; set; }
            public object slp { get; set; }
            public string qcField { get; set; }
            public object wxString { get; set; }
            public object presTend { get; set; }
            public object maxT { get; set; }
            public object minT { get; set; }
            public object maxT24 { get; set; }
            public object minT24 { get; set; }
            public object precip { get; set; }
            public object pcp3hr { get; set; }
            public object pcp6hr { get; set; }
            public object pcp24hr { get; set; }
            public object snow { get; set; }
            public object vertVis { get; set; }
            public string metarType { get; set; }
            public string rawOb { get; set; }
            public string mostRecent { get; set; }
            public string lat { get; set; }
            public string lon { get; set; }
            public string elev { get; set; }
            public string prior { get; set; }
            public string name { get; set; }
            public List<metar_cloud> clouds { get; set; }
        }
        public class metar_cloud
        {
            public string cover { get; set; }
            public string @base { get; set; }
        }

        public DateTime cast_as_date(string str)
        {
            var prts = str.Split(' ');
            //2024-05-10 07:00:00
            //  var _dt_prts = prts[0].Split(':') .ToList();
            //   var _time_prts = prts[1].Split(':') .ToList();


            var dt_prts = prts[0].Split('-').Select(q => Convert.ToInt32(q)).ToList();
            var time_prts = prts[1].Split(':').Select(q => Convert.ToInt32(q)).ToList();

            var dt = new DateTime(dt_prts[0], dt_prts[1], dt_prts[2], time_prts[0], time_prts[1], time_prts[2]);
            return dt;
        }

        public DateTime str_to_datetime(string str)
        {
            var ys = Convert.ToInt32(str.Substring(0, 4));
            var ms = Convert.ToInt32(str.Substring(4, 2));
            var ds = Convert.ToInt32(str.Substring(6, 2));

            var th = Convert.ToInt32(str.Substring(8, 2));
            var tm = Convert.ToInt32(str.Substring(10, 2));
           // var ts = Convert.ToInt32(str.Substring(12, 2));


            var dt = new DateTime(ys, ms, ds,th,tm,0);
            return dt;
        }
        public async Task<DataResponse> GetMETAR_ADDS_ALL_2024()
        {

            var stations = await _context.Airport.Where(q => q.ICAO.StartsWith("OI")
            || q.ICAO.StartsWith("OR")
             || q.ICAO.StartsWith("UT")
             || q.ICAO.StartsWith("UG")
              || q.ICAO.StartsWith("OK")
               || q.ICAO.StartsWith("LT")
               || q.ICAO.StartsWith("UD")

            ).Select(q => q.ICAO).ToListAsync();


            //var stations = await _context.Airport.Where(q =>  q.ICAO.StartsWith("OR")
            //).Select(q => q.ICAO).ToListAsync();
            //  stations = new List<string>() { "OIII" };
            // var oldTafs = await _context.WeatherTafs.Where(q => stations.Contains(q.StationId)).ToListAsync();

            var baseDate = DateTime.Now.Date;
            var tz1 = Math.Abs(TimeZoneInfo.Local.GetUtcOffset(baseDate).TotalMinutes);
            var offset1 = "";
            if (tz1 == 210)
                offset1 = "+0330";
            else
                offset1 = "+0430";
            //var from = baseDate.Date.ToString("yyyy-MM-dd") + "T00:00:00" + offset1;
            var from = DateTime.Now.ToString("yyyy-MM-dd") + "T" + DateTime.Now.AddHours(-2).ToString("HH:mm") + ":00" + offset1;
            var to = DateTime.Now.Date.AddDays(1).Date.ToString("yyyy-MM-dd") + "T00:00:00" + offset1;

            var d_from = DateTime.Now.AddHours(-2);
            var d_to = DateTime.Now.AddDays(1).Date;



            var station_dic = new Dictionary<string, List<string>>();
            station_dic.Add("OI", stations.Where(q => q.StartsWith("OI")).ToList());
            station_dic.Add("OR", stations.Where(q => q.StartsWith("OR")).ToList());
            station_dic.Add("UT", stations.Where(q => q.StartsWith("UT")).ToList());
            station_dic.Add("UG", stations.Where(q => q.StartsWith("UG")).ToList());
            station_dic.Add("OK", stations.Where(q => q.StartsWith("OK")).ToList());
            station_dic.Add("LT", stations.Where(q => q.StartsWith("LT")).ToList());

            station_dic.Add("UD", stations.Where(q => q.StartsWith("UD")).ToList());


            List<Models.WeatherMetar> result = new List<Models.WeatherMetar>();
            foreach (var kv in station_dic)
            {
                var key = kv.Key;

            }


            var _index = 0;
            var _station_grps = stations.GroupBy(x => _index++ / 10).ToList();

            var obs_times = new List<DateTime?>();
            foreach (var station_grp in _station_grps)
            {
                List<metar_response_obj> res = new List<metar_response_obj>();
                try
                {
                    var _station_str = string.Join(',', station_grp.ToList());
                    var x_url = "https://aviationweather.gov/api/data/metar?ids=" + _station_str + "&format=json&hours=8";
                    using (WebClient webClient = new WebClient())
                    {

                        var str_metar = webClient.DownloadString(x_url);
                        res = JsonConvert.DeserializeObject<List<metar_response_obj>>(str_metar);

                        foreach (var row in res)
                        {
                            var metar = new Models.WeatherMetar()
                            {
                                DateDay = baseDate.Date,
                                DateCreate = DateTime.Now,
                                RawText = row.rawOb,
                                StationId = row.icaoId,
                                // observation_time = string.IsNullOrEmpty((string)item.Element("observation_time")) ? null : (Nullable<DateTime>)Convert.ToDateTime((string)item.Element("observation_time")).ToUniversalTime(),
                                observation_time = cast_as_date(row.reportTime),
                                metar_id = row.metar_id,
                                response_text = JsonConvert.SerializeObject(row),



                                FlightId = null,
                                FDPId = null,

                            };
                            obs_times.Add((DateTime)metar.observation_time);

                            result.Add(metar);
                        }

                    }




                    //   var url = "https://aviationweather.gov/cgi-bin/data/dataserver.php?dataSource=metars&requestType=retrieve&format=xml&stationString="
                    // + _station_str
                    //+ "&hoursBeforeNow=8"
                    //;

                    //  XElement xml = XElement.Load(url);
                    //  var tafElements = xml.Descendants("METAR").ToList();
                    //  foreach (var item in tafElements)
                    //  {
                    //      var metar = new Models.WeatherMetar()
                    //      {
                    //          DateDay = baseDate.Date,
                    //          DateCreate = DateTime.Now,
                    //          RawText = (string)item.Element("raw_text"),
                    //          StationId = (string)item.Element("station_id"),
                    //          observation_time = string.IsNullOrEmpty((string)item.Element("observation_time")) ? null : (Nullable<DateTime>)Convert.ToDateTime((string)item.Element("observation_time")).ToUniversalTime(),



                    //          FlightId = null,
                    //          FDPId = null,

                    //      };
                    //      obs_times.Add((DateTime)metar.observation_time);

                    //      result.Add(metar);
                    //  }
                }
                catch (Exception ex)
                {

                }
            }
            obs_times = obs_times.Distinct().ToList();
            var exist = await _context.WeatherMetar.Where(q => q.DateDay == baseDate && stations.Contains(q.StationId) && obs_times.Contains(q.observation_time)).Select(q => q.Id).ToListAsync();
            if (exist.Count > 0)
            {
                var exist_ids = string.Join(',', exist);

                _context.Database.ExecuteSqlCommand("Delete from WeatherMetar where id in (" + exist_ids + ")");

                var saveResult1 = await _context.SaveAsync();
            }


            var _sc_i = 0;
            foreach (var m in result)
            {
                _context.WeatherMetar.Add(m);
                _sc_i++;
                if (_sc_i % 100 == 0)
                {
                    var _sc_result = await _context.SaveAsync();
                    if (true)
                    {
                        _sc_i = 0;

                    }
                }
            }

            if (result.Count <= 100)
                await _context.SaveAsync();

            return new DataResponse
            {
                Data = result.Count,
                Errors = null,
                IsSuccess = true
            };


        }

        public class Cloud
        {
            public string cover { get; set; }
            public string @base { get; set; }
            public string type { get; set; }
        }

        public class Fcst
        {
            public string timeGroup { get; set; }
            public string timeFrom { get; set; }
            public string timeTo { get; set; }
            public string timeBec { get; set; }
            public string fcstChange { get; set; }
            public string probability { get; set; }
            public string wdir { get; set; }
            public string wspd { get; set; }
            public object wgst { get; set; }
            public object wshearHgt { get; set; }
            public object wshearDir { get; set; }
            public object wshearSpd { get; set; }
            public string visib { get; set; }
            public object altim { get; set; }
            public object vertVis { get; set; }
            public object wxString { get; set; }
            public object notDecoded { get; set; }
            public List<Cloud> clouds { get; set; }
            public List<object> icgTurb { get; set; }
            public List<object> temp { get; set; }
        }

        public class taf_obj
        {
            public int tafId { get; set; }
            public string icaoId { get; set; }
            public string dbPopTime { get; set; }
            public string bulletinTime { get; set; }
            public string issueTime { get; set; }
            public int? validTimeFrom { get; set; }
            public int? validTimeTo { get; set; }
            public string rawTAF { get; set; }
            public string mostRecent { get; set; }
            public string remarks { get; set; }
            public string lat { get; set; }
            public string lon { get; set; }
            public string elev { get; set; }
            public string prior { get; set; }
            public string name { get; set; }
            public List<Fcst> fcsts { get; set; }
        }
        public DateTime UnixTimeStampToDateTime(int? unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            var dbl = Convert.ToDouble(unixTimeStamp);
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(dbl);
            return dateTime;
        }

        public async Task<DataResponse> GetTAF_ADDS_All_2024()
        {
            var stations = await _context.Airport.Where(q => q.ICAO.StartsWith("OI")
            || q.ICAO.StartsWith("OR")

             || q.ICAO.StartsWith("UT")
             || q.ICAO.StartsWith("UG")
              || q.ICAO.StartsWith("OK")
               || q.ICAO.StartsWith("LT")
               || q.ICAO.StartsWith("UD")
            ).Select(q => q.ICAO).ToListAsync();


            var baseDate = DateTime.Now.Date;
            var tz1 = Math.Abs(TimeZoneInfo.Local.GetUtcOffset(baseDate).TotalMinutes);
            var offset1 = "";
            if (tz1 == 210)
                offset1 = "+0330";
            else
                offset1 = "+0430";
            var from = baseDate.Date.ToString("yyyy-MM-dd") + "T00:00:00" + offset1;
            var to = baseDate.Date.AddDays(1).Date.ToString("yyyy-MM-dd") + "T00:00:00" + offset1;

            // var exist = await _context.WeatherTaf.Where(q => q.DateDay == baseDate && stations.Contains(q.StationId)).Select(q => q.Id).ToListAsync();
            //if (exist.Count > 0)
            // {
            //      var exist_ids = string.Join(',', exist);

            //     _context.Database.ExecuteSqlCommand("Delete from WeatherTaf where id in (" + exist_ids + ")");

            //     var saveResult1 = await _context.SaveAsync();
            // }
            var _index = 0;
            var _station_grps = stations.GroupBy(x => _index++ / 5).ToList();
            List<Models.WeatherTaf> result = new List<Models.WeatherTaf>();
            foreach (/*var station in stations*/var _sg in _station_grps)
            {
                try
                {
                    var _station_str = string.Join(',', _sg.ToList());

                    //https://aviationweather.gov/api/data/taf?ids=OIII&format=json

                    var x_url = "https://aviationweather.gov/api/data/taf?ids=" + _station_str + "&format=json";
                    using (WebClient webClient = new WebClient())
                    {

                        var str_taf = webClient.DownloadString(x_url);
                        var res = JsonConvert.DeserializeObject<List<taf_obj>>(str_taf);
                        var str_taf_raw = webClient.DownloadString("https://aviationweather.gov/api/data/taf?ids=" + _station_str + "&format=raw");
                        var raw_parts = str_taf_raw.Split("TAF ").Where(q => !string.IsNullOrEmpty(q)).ToList();
                        foreach (var rw in raw_parts)
                        {
                            var rw_key = rw.Split(' ').FirstOrDefault();
                            var obj_item = res.Where(q => q.icaoId == rw_key).FirstOrDefault();
                            if (obj_item == null)
                            {
                                rw_key = rw.Split(' ')[1];
                                obj_item = res.Where(q => q.icaoId == rw_key).FirstOrDefault();
                            }
                            if (obj_item != null)
                            {
                                string[] lines = rw.Split(
                                            new string[] { "\r\n", "\r", "\n" },
                                             StringSplitOptions.None
                            );
                                var new_raw = string.Join('*', lines);
                                obj_item.rawTAF = new_raw;
                            }




                        }
                        foreach (var row in res)
                        {
                            var taf = new Models.WeatherTaf()
                            {
                                DateDay = baseDate.Date,
                                DateCreate = DateTime.Now,
                                RawText = row.rawTAF,
                                StationId = row.icaoId,
                                taf_id = row.tafId,
                                ValidTimeFrom = UnixTimeStampToDateTime(row.validTimeFrom),
                                ValidTimeTo = UnixTimeStampToDateTime(row.validTimeTo),
                                IssueTime = cast_as_date(row.issueTime),
                                BulletinTime = cast_as_date(row.bulletinTime),
                                // Latitude = Convert.ToDecimal((string)item.Element("latitude")),
                                // Longitude = Convert.ToDecimal((string)item.Element("longitude")),
                                // EvaluationM = Convert.ToDecimal((string)item.Element("elevation_m")),
                                response_text = JsonConvert.SerializeObject(row),
                            };
                            result.Add(taf);
                        }



                    }

                    // var url = "https://aviationweather.gov/cgi-bin/data/dataserver.php?dataSource=tafs&requestType=retrieve&format=xml"
                    // + "&startTime=" + from//"2021-08-10T00:00:00+0430"
                    // + "&endTime=" + to//"2021-08-11T00:00:00+0430"
                    //                   // + "&hoursBeforeNow=3"
                    //+ "&timeType=valid"
                    //+ "&stationString=" + _station_str //station//"OISS,OIII";
                    //;

                    // XElement xml = XElement.Load(url);
                    // var tafElements = xml.Descendants("TAF").ToList();
                    // foreach (var item in tafElements)
                    // {
                    //     var taf = new Models.WeatherTaf()
                    //     {
                    //         DateDay = baseDate.Date,
                    //         DateCreate = DateTime.Now,
                    //         RawText = (string)item.Element("raw_text"),
                    //         StationId = (string)item.Element("station_id"),
                    //         //BulletinTime = string.IsNullOrEmpty((string)item.Element("bulletin_time")) ? null : (Nullable<DateTime>)Convert.ToDateTime((string)item.Element("bulletin_time")).ToUniversalTime(),
                    //         // ValidTimeFrom = string.IsNullOrEmpty((string)item.Element("valid_time_from")) ? null : (Nullable<DateTime>)Convert.ToDateTime((string)item.Element("valid_time_from")).ToUniversalTime(),
                    //         // ValidTimeTo = string.IsNullOrEmpty((string)item.Element("valid_time_to")) ? null : (Nullable<DateTime>)Convert.ToDateTime((string)item.Element("valid_time_to")).ToUniversalTime(),
                    //         IssueTime = string.IsNullOrEmpty((string)item.Element("issue_time")) ? null : (Nullable<DateTime>)Convert.ToDateTime((string)item.Element("issue_time")).ToUniversalTime(),
                    //         // Latitude = Convert.ToDecimal((string)item.Element("latitude")),
                    //         // Longitude = Convert.ToDecimal((string)item.Element("longitude")),
                    //         // EvaluationM = Convert.ToDecimal((string)item.Element("elevation_m")),
                    //     };

                    //     result.Add(taf);
                    // }
                }
                catch (Exception ex)
                {

                }



            }

            var taf_ids = result.Select(q => q.taf_id).ToList();
            var exists = await _context.WeatherTaf.Where(q => taf_ids.Contains(q.taf_id)).ToListAsync();
            _context.WeatherTaf.RemoveRange(exists);

            //var _stations = result.Select(q => q.StationId).ToList();

            var _sc_i = 0;
            foreach (var m in result)
            {
                _context.WeatherTaf.Add(m);
                _sc_i++;
                if (_sc_i % 100 == 0)
                {
                    var _sc_result = await _context.SaveAsync();
                    if (true)
                    {
                        _sc_i = 0;

                    }
                }
            }

            if (result.Count <= 100)
            {
                var __sresult = await _context.SaveAsync();
            }
            return new DataResponse
            {
                Data = result.Count,
                Errors = null,
                IsSuccess = true
            };
        }

        public async Task<DataResponse> GetTAF_ADDS_All()
        {
            var stations = await _context.Airport.Where(q => q.ICAO.StartsWith("OI") || q.ICAO.StartsWith("OR")

             || q.ICAO.StartsWith("UT")
             || q.ICAO.StartsWith("UG")
              || q.ICAO.StartsWith("OK")
               || q.ICAO.StartsWith("LT")
               || q.ICAO.StartsWith("UDYZ")
            ).Select(q => q.ICAO).ToListAsync();
            // var oldTafs = await _context.WeatherTafs.Where(q => stations.Contains(q.StationId)).ToListAsync();

            var baseDate = DateTime.Now.Date;
            var tz1 = Math.Abs(TimeZoneInfo.Local.GetUtcOffset(baseDate).TotalMinutes);
            var offset1 = "";
            if (tz1 == 210)
                offset1 = "+0330";
            else
                offset1 = "+0430";
            var from = baseDate.Date.ToString("yyyy-MM-dd") + "T00:00:00" + offset1;
            var to = baseDate.Date.AddDays(1).Date.ToString("yyyy-MM-dd") + "T00:00:00" + offset1;

            var exist = await _context.WeatherTaf.Where(q => q.DateDay == baseDate && stations.Contains(q.StationId)).Select(q => q.Id).ToListAsync();
            if (exist.Count > 0)
            {
                var exist_ids = string.Join(',', exist);
                // _context.WeatherMetar.RemoveRange(exist);
                _context.Database.ExecuteSqlCommand("Delete from WeatherTaf where id in (" + exist_ids + ")");

                var saveResult1 = await _context.SaveAsync();
            }
            var _index = 0;
            var _station_grps = stations.GroupBy(x => _index++ / 10).ToList();
            List<Models.WeatherTaf> result = new List<Models.WeatherTaf>();
            foreach (/*var station in stations*/var _sg in _station_grps)
            {
                try
                {
                    var _station_str = string.Join(',', _sg.ToList());
                    // var station = apt.ICAO;
                    //  var url = "https://www.aviationweather.gov/adds/dataserver_current/httpparam?dataSource=tafs&requestType=retrieve&format=xml"
                    var url = "https://aviationweather.gov/cgi-bin/data/dataserver.php?dataSource=tafs&requestType=retrieve&format=xml"
                    + "&startTime=" + from//"2021-08-10T00:00:00+0430"
                    + "&endTime=" + to//"2021-08-11T00:00:00+0430"
                                      // + "&hoursBeforeNow=3"
                   + "&timeType=valid"
                   + "&stationString=" + _station_str //station//"OISS,OIII";
                   ;

                    XElement xml = XElement.Load(url);
                    var tafElements = xml.Descendants("TAF").ToList();
                    foreach (var item in tafElements)
                    {
                        var taf = new Models.WeatherTaf()
                        {
                            DateDay = baseDate.Date,
                            DateCreate = DateTime.Now,
                            RawText = (string)item.Element("raw_text"),
                            StationId = (string)item.Element("station_id"),
                            //BulletinTime = string.IsNullOrEmpty((string)item.Element("bulletin_time")) ? null : (Nullable<DateTime>)Convert.ToDateTime((string)item.Element("bulletin_time")).ToUniversalTime(),
                            // ValidTimeFrom = string.IsNullOrEmpty((string)item.Element("valid_time_from")) ? null : (Nullable<DateTime>)Convert.ToDateTime((string)item.Element("valid_time_from")).ToUniversalTime(),
                            // ValidTimeTo = string.IsNullOrEmpty((string)item.Element("valid_time_to")) ? null : (Nullable<DateTime>)Convert.ToDateTime((string)item.Element("valid_time_to")).ToUniversalTime(),
                            IssueTime = string.IsNullOrEmpty((string)item.Element("issue_time")) ? null : (Nullable<DateTime>)Convert.ToDateTime((string)item.Element("issue_time")).ToUniversalTime(),
                            // Latitude = Convert.ToDecimal((string)item.Element("latitude")),
                            // Longitude = Convert.ToDecimal((string)item.Element("longitude")),
                            // EvaluationM = Convert.ToDecimal((string)item.Element("elevation_m")),
                        };
                        //  taf.WeatherTafForecast = getForecasts(item);
                        // _context.WeatherTaf.Add(taf);

                        result.Add(taf);
                    }
                }
                catch (Exception ex)
                {

                }



            }


            var _stations = result.Select(q => q.StationId).ToList();
            // var exist = await _context.WeatherTaf.Where(q => q.DateDay == baseDate && _stations.Contains(q.StationId)).ToListAsync();
            // _context.WeatherTaf.RemoveRange(exist);

            //var saveResult = await _context.SaveAsync();
            var _sc_i = 0;
            foreach (var m in result)
            {
                _context.WeatherTaf.Add(m);
                _sc_i++;
                if (_sc_i % 100 == 0)
                {
                    var _sc_result = await _context.SaveAsync();
                    if (true)
                    {
                        _sc_i = 0;

                    }
                }
            }

            return new DataResponse
            {
                Data = result.Count,
                Errors = null,
                IsSuccess = true
            };
        }

        public List<WeatherMetarSkyCondition> getSkyConditionsMETAR(XElement elem)
        {
            List<WeatherMetarSkyCondition> result = new List<WeatherMetarSkyCondition>();
            var items = elem.Elements("sky_condition").ToList();
            foreach (var item in items)
            {
                var obj = new WeatherMetarSkyCondition()
                {


                    sky_cover = item.Attribute("sky_cover") != null ? (string)item.Attribute("sky_cover") : null,
                    cloud_base_ft_agl = item.Attribute("cloud_base_ft_agl") != null ? (Nullable<int>)Convert.ToInt32((string)item.Attribute("cloud_base_ft_agl")) : null,


                };

                result.Add(obj);

            }
            return result;
        }

        public List<WeatherMetarQualityControl> getQualityControlMETAR(XElement elem)
        {
            List<WeatherMetarQualityControl> result = new List<WeatherMetarQualityControl>();
            var items = elem.Elements("quality_control_flags").ToList();
            foreach (var item in items)
            {
                var obj = new WeatherMetarQualityControl()
                {



                    corrected = item.Element("corrected") != null ? (string)item.Element("corrected") : null,
                    auto = item.Element("auto") != null ? (string)item.Element("auto") : null,
                    auto_station = item.Element("auto_station") != null ? (string)item.Element("auto_station") : null,
                    maintenance_indicator_on = item.Element("maintenance_indicator_on") != null ? (string)item.Element("maintenance_indicator_on") : null,
                    no_signal = item.Element("no_signal") != null ? (string)item.Element("no_signal") : null,
                    lightning_sensor_off = item.Element("lightning_sensor_off") != null ? (string)item.Element("lightning_sensor_off") : null,
                    freezing_rain_sensor_off = item.Element("freezing_rain_sensor_off") != null ? (string)item.Element("freezing_rain_sensor_off") : null,
                    present_weather_sensor_off = item.Element("present_weather_sensor_off") != null ? (string)item.Element("present_weather_sensor_off") : null,
                };

                result.Add(obj);

            }
            return result;
        }
        public List<WeatherTafForecast> getForecasts(XElement elem)
        {
            List<WeatherTafForecast> result = new List<WeatherTafForecast>();
            var forecasts = elem.Elements("forecast").ToList();
            foreach (var item in forecasts)
            {
                var forecast = new WeatherTafForecast();
                forecast.fcst_time_from = item.Element("fcst_time_from") != null ? getDateTimeFromElement(item.Element("fcst_time_from")) : null;
                forecast.fcst_time_to = item.Element("fcst_time_to") != null ? getDateTimeFromElement(item.Element("fcst_time_to")) : null;
                forecast.time_becoming = item.Element("time_becoming") != null ? getDateTimeFromElement(item.Element("time_becoming")) : null;
                forecast.change_indicator = item.Element("change_indicator") != null ? (string)item.Element("change_indicator") : null;

                forecast.probability = item.Element("probability") != null ? (Nullable<double>)Convert.ToDouble((string)item.Element("probability")) : null;
                forecast.wind_dir_degrees = item.Element("wind_dir_degrees") != null ? (Nullable<double>)Convert.ToDouble((string)item.Element("wind_dir_degrees")) : null;
                forecast.wind_speed_kt = item.Element("wind_speed_kt") != null ? (Nullable<double>)Convert.ToDouble((string)item.Element("wind_speed_kt")) : null;
                forecast.wind_gust_kt = item.Element("wind_gust_kt") != null ? (Nullable<double>)Convert.ToDouble((string)item.Element("wind_gust_kt")) : null;
                forecast.wind_shear_hgt_ft_agl = item.Element("wind_shear_hgt_ft_agl") != null ? (Nullable<double>)Convert.ToDouble((string)item.Element("wind_shear_hgt_ft_agl")) : null;
                forecast.wind_shear_dir_degrees = item.Element("wind_shear_dir_degrees") != null ? (Nullable<double>)Convert.ToDouble((string)item.Element("wind_shear_dir_degrees")) : null;
                forecast.wind_shear_speed_kt = item.Element("wind_shear_speed_kt") != null ? (Nullable<double>)Convert.ToDouble((string)item.Element("wind_shear_speed_kt")) : null;
                forecast.visibility_statute_mi = item.Element("visibility_statute_mi") != null ? (Nullable<double>)Convert.ToDouble((string)item.Element("visibility_statute_mi")) : null;
                forecast.altim_in_hg = item.Element("altim_in_hg") != null ? (Nullable<double>)Convert.ToDouble((string)item.Element("altim_in_hg")) : null;
                forecast.vert_vis_ft = item.Element("vert_vis_ft") != null ? (Nullable<double>)Convert.ToDouble((string)item.Element("vert_vis_ft")) : null;
                forecast.wx_string = item.Element("wx_string") != null ? (string)item.Element("wx_string") : null;
                forecast.not_decoded = item.Element("not_decoded") != null ? (string)item.Element("not_decoded") : null;
                forecast.WeatherForecastSkyCondition = getSkyConditions(item);
                forecast.WeatherForecastTurbulence = getTurbulenceConditions(item);
                forecast.WeatherForecastIcingCondition = getIcingConditions(item);
                forecast.WeatherForecastTemperature = getTemperatures(item);

                result.Add(forecast);

            }
            return result;
        }

        DateTime? getDateTimeFromElement(XElement x)
        {
            return string.IsNullOrEmpty((string)x) ? null : (Nullable<DateTime>)Convert.ToDateTime((string)x).ToUniversalTime();
        }
        public List<WeatherForecastSkyCondition> getSkyConditions(XElement elem)
        {
            List<WeatherForecastSkyCondition> result = new List<WeatherForecastSkyCondition>();
            var items = elem.Elements("sky_condition").ToList();
            foreach (var item in items)
            {
                var obj = new WeatherForecastSkyCondition()
                {


                    sky_cover = item.Attribute("sky_cover") != null ? (string)item.Attribute("sky_cover") : null,
                    cloud_base_ft_agl = item.Attribute("cloud_base_ft_agl") != null ? (Nullable<double>)Convert.ToDouble((string)item.Attribute("cloud_base_ft_agl")) : null,
                    cloud_type = item.Attribute("cloud_type") != null ? (string)item.Attribute("cloud_type") : null,

                };

                result.Add(obj);

            }
            return result;
        }


        public List<WeatherForecastTurbulence> getTurbulenceConditions(XElement elem)
        {
            List<WeatherForecastTurbulence> result = new List<WeatherForecastTurbulence>();
            var items = elem.Elements("turbulence_condition").ToList();
            foreach (var item in items)
            {
                var obj = new WeatherForecastTurbulence()
                {

                    turbulence_intensity = item.Element("turbulence_intensity") != null ? (string)item.Element("turbulence_intensity") : null,
                    turbulence_min_alt_ft_agl = item.Element("turbulence_min_alt_ft_agl") != null ? (Nullable<double>)Convert.ToDouble((string)item.Element("turbulence_min_alt_ft_agl")) : null,
                    turbulence_max_alt_ft_agl = item.Element("turbulence_max_alt_ft_agl") != null ? (Nullable<double>)Convert.ToDouble((string)item.Element("turbulence_max_alt_ft_agl")) : null,



                };

                result.Add(obj);

            }
            return result;
        }


        public List<WeatherForecastIcingCondition> getIcingConditions(XElement elem)
        {
            List<WeatherForecastIcingCondition> result = new List<WeatherForecastIcingCondition>();
            var items = elem.Elements("icing_condition").ToList();
            foreach (var item in items)
            {
                var obj = new WeatherForecastIcingCondition()
                {

                    icing_intensity = item.Element("icing_intensity") != null ? (string)item.Element("icing_intensity") : null,
                    icing_min_alt_ft_agl = item.Element("icing_min_alt_ft_agl") != null ? (Nullable<double>)Convert.ToDouble((string)item.Element("icing_min_alt_ft_agl")) : null,
                    icing_max_alt_ft_agl = item.Element("icing_max_alt_ft_agl") != null ? (Nullable<double>)Convert.ToDouble((string)item.Element("icing_max_alt_ft_agl")) : null,

                };

                result.Add(obj);

            }
            return result;
        }


        public List<WeatherForecastTemperature> getTemperatures(XElement elem)
        {
            List<WeatherForecastTemperature> result = new List<WeatherForecastTemperature>();
            var items = elem.Elements("temperature").ToList();
            foreach (var item in items)
            {
                var obj = new WeatherForecastTemperature()
                {

                    valid_time = item.Element("valid_time") != null ? getDateTimeFromElement(item.Element("valid_time")) : null,
                    sfc_temp_c = item.Element("sfc_temp_c") != null ? (Nullable<double>)Convert.ToDouble((string)item.Element("sfc_temp_c")) : null,
                    max_temp_c = item.Element("max_temp_c") != null ? (string)item.Element("max_temp_c") : null,
                    min_temp_c = item.Element("min_temp_c") != null ? (string)item.Element("min_temp_c") : null,


                };

                result.Add(obj);

            }
            return result;
        }



        public async Task<DataResponse> GetWX()
        {
            try
            {
                var baseDate = DateTime.Now.Date;

                var url = "http://185.213.164.43/weather/api/weather/metars/now";
                string str_metar = string.Empty;
                List<WeatherMetar> obj_metar = new List<WeatherMetar>();
                using (WebClient webClient = new WebClient())
                {

                    str_metar = webClient.DownloadString(url);
                    obj_metar = JsonConvert.DeserializeObject<List<WeatherMetar>>(str_metar);



                }

                List<DateTime?> obs_times = obj_metar.Select(q => q.observation_time).Distinct().ToList();
                var exist = await _context.WeatherMetar.Where(q => /*q.DateDay == baseDate*/ obs_times.Contains(q.observation_time)).Select(q => q.Id).ToListAsync();
                if (exist.Count > 0)
                {
                    var exist_ids = string.Join(',', exist);

                    _context.Database.ExecuteSqlCommand("Delete from WeatherMetar where id in (" + exist_ids + ")");
                    await _context.SaveAsync();
                    // var saveResult1 = await _context.SaveAsync();
                }

                foreach (var x in obj_metar)
                {
                    x.Id = 0;
                    _context.WeatherMetar.Add(x);
                }

                //var fffff = obj_metar.Where(q => q.StationId == "OIII").OrderByDescending(q => q.observation_time).ToList();
                var _sc_i = 0;
                //foreach (var x in obj_metar)
                //{
                //    x.Id = 0;
                //    _context.WeatherMetar.Add(x);
                //    _sc_i++;
                //    if (_sc_i % 100 == 0)
                //    {
                //        var _sc_result = await _context.SaveAsync();
                //        if (true)
                //        {
                //            _sc_i = 0;

                //        }
                //    }
                //}


                var saveResult1 = await _context.SaveAsync();

                ////////NOTAM////////////////
                var url2 = "http://185.213.164.43/weather/api/weather/notam/now";
                string str_notam = string.Empty;
                List<NOTAM> obj_notam = new List<NOTAM>();
                using (WebClient webClient = new WebClient())
                {

                    str_notam = webClient.DownloadString(url2);
                    obj_notam = JsonConvert.DeserializeObject<List<NOTAM>>(str_notam);



                }
                var exists2 = await _context.NOTAM.Where(q => q.DateDay == baseDate).ToListAsync();
                if (exists2.Count > 0)
                    _context.NOTAM.RemoveRange(exists2);
                await _context.SaveAsync();
                foreach (var x in obj_notam)
                {
                    x.Id = 0;
                    foreach (var y in x.NOTAMItem)
                        y.Id = 0;
                    _context.NOTAM.Add(x);
                }
                var saveResult2 = await _context.SaveAsync();
                // _sc_i = 0;
                //foreach (var x in obj_notam)
                //{
                //    x.Id = 0;
                //    foreach (var y in x.NOTAMItem)
                //        y.Id = 0;
                //    _context.NOTAM.Add(x);
                //    _sc_i++;
                //    if (_sc_i % 100 == 0)
                //    {
                //        var _sc_result = await _context.SaveAsync();
                //        if (true)
                //        {
                //            _sc_i = 0;

                //        }
                //    }
                //  }


                ////////TAF////////////////
                var url3 = "http://185.213.164.43/weather/api/weather/taf/now";
                string str_taf = string.Empty;
                List<WeatherTaf> obj_taf = new List<WeatherTaf>();
                using (WebClient webClient = new WebClient())
                {

                    str_taf = webClient.DownloadString(url3);
                    obj_taf = JsonConvert.DeserializeObject<List<WeatherTaf>>(str_taf);



                }
                var issue = DateTime.Now.AddHours(-6);
                var exists3 = await _context.WeatherTaf.Where(q => q.DateDay == baseDate && q.IssueTime >= issue).Select(q => q.Id).ToListAsync();
                if (exists3.Count > 0)
                {
                    var exist_ids3 = string.Join(',', exists3);
                    // _context.WeatherMetar.RemoveRange(exist);
                    _context.Database.ExecuteSqlCommand("Delete from WeatherTaf where id in (" + exist_ids3 + ")");

                    var _xxx = await _context.SaveAsync();
                }
                foreach (var x in obj_taf)
                {
                    x.Id = 0;

                    _context.WeatherTaf.Add(x);
                }
                var saveResult3 = await _context.SaveAsync();
                //_sc_i = 0;
                //foreach (var x in obj_taf)
                //{
                //    x.Id = 0;
                //    _context.WeatherTaf.Add(x);
                //    _sc_i++;
                //    if (_sc_i % 100 == 0)
                //    {
                //        var _sc_result = await _context.SaveAsync();
                //        if (true)
                //        {
                //            _sc_i = 0;

                //        }
                //    }
                //}
                return new DataResponse() { Data = true };
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                if (ex.InnerException != null)
                    msg += ex.InnerException.Message;
                return new DataResponse() { Data = msg };
            }
        }


        public async Task<DataResponse> GetWXMetar()
        {
            try
            {
                var baseDate = DateTime.Now.Date;

                var url = "http://185.213.164.43/weather/api/weather/metars/now";
                string str_metar = string.Empty;
                List<WeatherMetar> obj_metar = new List<WeatherMetar>();
                using (WebClient webClient = new WebClient())
                {

                    str_metar = webClient.DownloadString(url);
                    obj_metar = JsonConvert.DeserializeObject<List<WeatherMetar>>(str_metar);



                }

                List<DateTime?> obs_times = obj_metar.Select(q => q.observation_time).Distinct().ToList();
                var exist = await _context.WeatherMetar.Where(q => /*q.DateDay == baseDate*/ obs_times.Contains(q.observation_time)).Select(q => q.Id).ToListAsync();
                if (exist.Count > 0)
                {
                    var exist_ids = string.Join(',', exist);

                    _context.Database.ExecuteSqlCommand("Delete from WeatherMetar where id in (" + exist_ids + ")");
                    await _context.SaveAsync();
                    // var saveResult1 = await _context.SaveAsync();
                }

                foreach (var x in obj_metar)
                {
                    x.Id = 0;
                    _context.WeatherMetar.Add(x);
                }

                //var fffff = obj_metar.Where(q => q.StationId == "OIII").OrderByDescending(q => q.observation_time).ToList();
                var _sc_i = 0;
                //foreach (var x in obj_metar)
                //{
                //    x.Id = 0;
                //    _context.WeatherMetar.Add(x);
                //    _sc_i++;
                //    if (_sc_i % 100 == 0)
                //    {
                //        var _sc_result = await _context.SaveAsync();
                //        if (true)
                //        {
                //            _sc_i = 0;

                //        }
                //    }
                //}


                var saveResult1 = await _context.SaveAsync();


                return new DataResponse() { Data = obj_metar };
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                if (ex.InnerException != null)
                    msg += ex.InnerException.Message;
                return new DataResponse() { Data = msg };
            }
        }

        public async Task<object> GetMetarByDateNow()
        {
            var baseDate = DateTime.Now.Date;
            var dt = DateTime.Now;//.AddMinutes(-210);
            var df = DateTime.Now.AddMinutes(-210).AddHours(-3);

            // var metars = await _context.WeatherMetar.Where(q => q.DateDay == baseDate).ToListAsync();
            var metars = await _context.WeatherMetar.Where(q => q.observation_time >= df && q.observation_time <= dt).ToListAsync();
            return metars;

        }

        public async Task<object> GetTafByDateNow()
        {
            var baseDate = DateTime.Now.Date;
            var issue = DateTime.Now.AddHours(-24);
            var metars = await _context.WeatherTaf.Where(q => q.DateDay == baseDate && q.IssueTime >= issue).ToListAsync();
            return metars;

        }

        public async Task<object> GetNotamByDateNow()
        {
            var baseDate = DateTime.Now.Date;
            var notams = await _context.NOTAM.Where(q => q.DateDay == baseDate).ToListAsync();

            var notamIds = notams.Select(q => q.Id).ToList();
            var notamItems = await _context.NOTAMItem.Where(q => notamIds.Contains(q.NOTAMId)).ToListAsync();
            foreach (var notam in notams)
                notam.NOTAMItem = notamItems.Where(q => q.NOTAMId == notam.Id).ToList();
            return notams;

        }

        public async Task<DataResponse> GetAirportNotamAll()
        {
            var stations = await _context.Airport.Where(q => q.ICAO.StartsWith("OI")
            || q.ICAO.StartsWith("OR")
             || q.ICAO.StartsWith("UT")
             || q.ICAO.StartsWith("UG")
              || q.ICAO.StartsWith("OK")
               || q.ICAO.StartsWith("LT")
               || q.ICAO.StartsWith("UDYZ")
               || q.ICAO.StartsWith("OO")
            ).Select(q => q.ICAO).ToListAsync();
            
            //stations = new List<string>() { "OIII" };
            stations.Add("OIIX");
            DateTime baseDate = DateTime.Now.Date;
            DateTime baseDate2 = baseDate.AddDays(1);
            var data = new List<NOTAM>();
             var exists = await _context.NOTAM.Where(q => stations.Contains(q.StationId) && (q.DateDay == baseDate || q.DateDay == baseDate2)).ToListAsync();
           // _context.NOTAM.RemoveRange(exists);
            foreach (var apt in stations)
            {
                try
                {
                    var result = new List<string>();
                    var html = "https://pilotweb.nas.faa.gov/PilotWeb/notamRetrievalByICAOAction.do?method=displayByICAOs&reportType=REPORT&actionType=notamRetrievalByICAOs&retrieveLocId=" + apt.ToUpper() + "&formatType=ICAO";



                    using (WebClient webClient = new WebClient())
                    {
                        webClient.Headers.Add(HttpRequestHeader.Cookie, "akamai_pilotweb_access=true");
                        var txt = webClient.DownloadString(html);
                        var doc = new HtmlDocument();
                        doc.LoadHtml(txt);


                        var raw = doc.DocumentNode.Descendants("div")
                            .Where(q => q.Id == "notamRight")
                            .Select(q => q.Descendants("span").First().InnerText)

                            .ToList();

                        foreach (var x in raw)
                            result.Add(Regex.Replace(x, @"\r\n?|\n", "<br/>"));

                        //data.Add(new NotamResult() { ICAO = apt, NOTAMS = result });
                        var exist_station = exists.Where(q => q.StationId == apt).ToList();
                        _context.NOTAM.RemoveRange(exist_station);
                        var notam = new NOTAM()
                        {
                            DateDay = baseDate,
                            DateCreate = DateTime.Now,
                            FDPId = null,
                            FlightId = null,
                            StationId = apt,

                        };
                        var notam2 = new NOTAM()
                        {
                            DateDay = baseDate2,
                            DateCreate = DateTime.Now,
                            FDPId = null,
                            FlightId = null,
                            StationId = apt,

                        };
                        notam.NOTAMItem = result.Select(q => new NOTAMItem()
                        {
                            Text = q,
                        }).ToList();
                        notam2.NOTAMItem = result.Select(q => new NOTAMItem()
                        {
                            Text = q,
                        }).ToList();
                        _context.NOTAM.Add(notam);
                        data.Add(notam);

                        _context.NOTAM.Add(notam2);
                        data.Add(notam2);

                    }
                }
                catch (Exception ex)
                {

                }
            }
            var saveresult = await _context.SaveAsync();
           return new DataResponse
            {
                Data = data.Count,
                Errors = null,
                IsSuccess = true
            };
        }

    }
}
