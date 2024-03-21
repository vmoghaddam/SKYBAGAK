using NEERJACore.Models;
using NEERJACore.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace NEERJACore.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MainController : ApiController
    {
        [Route("neerja/pfc/items/{flt_id}/{crew_id}")]
        public async Task<IHttpActionResult> get_pfc_items_flt_crew(int flt_id, int crew_id)
        {
            ppa_entities context = new ppa_entities();
            var result = await context.view_neerja_pfc_item.Where(q => q.flight_id == flt_id && q.crew_id == crew_id).OrderBy(q => q.category_order_id).ThenBy(q => q.item_id).ToListAsync();
            return Ok(result);
        }

        [Route("neerja/scc/{flt_id}/{crew_id}")]
        public async Task<IHttpActionResult> get_scc_flt_crew(int flt_id, int crew_id)
        {
            ppa_entities context = new ppa_entities();
            var result = await context.view_neerja_scc_report.Where(q => q.flight_id == flt_id && q.crew_id == crew_id).FirstOrDefaultAsync();
            return Ok(result);
        }

        [Route("neerja/pfc/items/grouped/{flt_id}/{crew_id}")]
        public async Task<IHttpActionResult> get_pfc_items_flt_crew_grouped(int flt_id, int crew_id)
        {
            ppa_entities context = new ppa_entities();
            var result = await context.view_neerja_pfc_item.Where(q => q.flight_id == flt_id && q.crew_id == crew_id).OrderBy(q => q.category_order_id).ThenBy(q => q.item_id).ToListAsync();
            var grouped = (from x in result
                           group x by new { x.category, x.category_id, x.category_order_id } into grp
                           select new
                           {
                               grp.Key.category_id,
                               grp.Key.category,
                               grp.Key.category_order_id,
                               items = grp.ToList()
                           }).OrderBy(q => q.category_order_id).ToList(); ;

            return Ok(grouped);
        }


        //    items.push({
        //                                item_id: item.item_id,
        //                                remark: item.remark,
        //                                is_servicable: item.is_servicable,
        //                                crew_id: item.crew_id,
        //                                flight_id:item.flight_id
        //});

        [HttpPost]
        [Route("neerja/scc/save")]
        public async Task<IHttpActionResult> post_scc(scc_dto dto)
        {
            ppa_entities context = new ppa_entities();
            var scc_report = await context.neerja_scc_report_form.Where(q => q.flight_id == dto.flight_id && q.crew_id == dto.crew_id).FirstOrDefaultAsync();
            if (scc_report == null)
            {
                scc_report = new neerja_scc_report_form()
                {
                     crew_id=dto.crew_id,
                      flight_id=dto.flight_id,
                       date_create=DateTime.Now,
                };


                context.neerja_scc_report_form.Add(scc_report);
            }

            scc_report.date_create = DateTime.Now;
            scc_report.technical = dto.technical;
            scc_report.general_issue = dto.general_issue;
            scc_report.catering_issue = dto.catering_issue;
            scc_report.safety_issue = dto.safety_issue;
            scc_report.airport_service = dto.airport_service;
            scc_report.remark = dto.remark;

            await context.SaveChangesAsync();

            return Ok(new DataResponse()
            {
                IsSuccess = true,
                Data = dto,

            });



        }
        [HttpPost]
        [Route("neerja/pfc/items/save")]
        public async Task<IHttpActionResult> post_pfc_items(preflight_dto2 dto)
        {
            try
            {
                ppa_entities context = new ppa_entities();
                var flight_id = dto.items.First().flight_id;
                var crew_id = dto.items.First().crew_id;
                var current_items = await context.neerja_preflight_ckeck_form_item.Where(q => q.crew_id == crew_id && q.flight_id == flight_id).ToListAsync();
                //context.neerja_preflight_ckeck_form_item.RemoveRange(exist);

                foreach (var row in dto.items)
                {
                    var current = current_items.FirstOrDefault(q => q.item_id == row.item_id);
                    if (current == null)
                    {
                        current = new neerja_preflight_ckeck_form_item();
                        current.item_id = row.item_id;
                        current.crew_id = crew_id;
                        current.flight_id = flight_id;
                        context.neerja_preflight_ckeck_form_item.Add(current);
                    }
                    current.is_servicable = row.is_servicable;

                    current.remark = row.remark;

                }



                await context.SaveChangesAsync();

                return Ok(new DataResponse()
                {
                    IsSuccess = true,
                    Data = dto,

                });



            }
            catch (Exception ex)
            {
                return Ok(new DataResponse()
                {
                    Data = dto,
                    IsSuccess = false,
                    Errors = new List<string>() { helper.get_exception_message(ex) }
                });
            }
        }


        //[EnableCors(origins: "*", headers: "*", methods: "*")]
        //public class FuelController : ApiController
        //{
        //    [Route("api/fuel/report")]
        //    public async Task<IHttpActionResult> GetFuelReport(DateTime dfrom, DateTime dto)
        //    {
        //        dfrom = dfrom.Date;
        //        dto = dto.Date.AddDays(1);
        //        ppa_entities context = new ppa_entities();



        //        return Ok(true);
        //    }

        //}

        //[HttpPost]
        //[Route("api/preflight/items/save")]
        //public async Task<IHttpActionResult> PostPreflightItems(preflight_dto dto)
        //{
        //    try
        //    {
        //        ppa_entities context = new ppa_entities();
        //        var current_items = await context.neerja_preflight_ckeck_form_item.Where(q => q.crew_id == dto.crew_id && q.flight_id == dto.flight_id).ToListAsync();
        //        //context.neerja_preflight_ckeck_form_item.RemoveRange(exist);

        //        foreach (var row in dto.items)
        //        {
        //            var current = current_items.FirstOrDefault(q => q.item_id == row.item_id);
        //            if (current == null)
        //            {
        //                current = new neerja_preflight_ckeck_form_item();
        //                current.item_id = row.item_id;
        //                current.crew_id = dto.crew_id;
        //                current.flight_id = dto.flight_id;
        //                context.neerja_preflight_ckeck_form_item.Add(current);
        //            }
        //            current.is_servicable = row.is_servicable;

        //            current.remark = row.remark;

        //        }

        //        var c_remarks = await context.neerja_preflight_from_remark.Where(q => q.flight_id == dto.flight_id && q.crew_id == dto.crew_id).FirstOrDefaultAsync();
        //        if (c_remarks != null)
        //            context.neerja_preflight_from_remark.Remove(c_remarks);
        //        context.neerja_preflight_from_remark.Add(new neerja_preflight_from_remark()
        //        {
        //            crew_id = dto.crew_id,
        //            flight_id = dto.flight_id,
        //            remark = dto.remark
        //        });


        //        await context.SaveChangesAsync();

        //        return Ok(new DataResponse()
        //        {
        //            IsSuccess = true,
        //            Data = dto,

        //        });
        //    }
        //    catch(Exception ex)
        //    {
        //        return Ok(new DataResponse()
        //        {
        //            Data = dto,
        //            IsSuccess = false,
        //            Errors = new List<string>() { helper.get_exception_message(ex) }
        //        });
        //    }

        //}

        //[HttpPost]
        //[Route("api/preflight/sign/{flight_id}/{crew_id}")]
        //public async Task<IHttpActionResult> PostPreflightSign(int flight_id,int crew_id)
        //{
        //    try
        //    {
        //        ppa_entities context = new ppa_entities();
        //        var current_items = await context.neerja_preflight_ckeck_form_item.Where(q => q.crew_id == crew_id && q.flight_id == flight_id).ToListAsync();

        //        //var not_completed = current_items.Where(q => q.is_servicable == null).Count();
        //        //if (current_items.Count==0 || not_completed > 0)
        //        //{
        //        //    return Ok(new DataResponse()
        //        //    {
        //        //        Data = null,
        //        //        IsSuccess = false,
        //        //        Errors = new List<string>() { "Please Complete" }
        //        //    });
        //        //}
        //        var dt = DateTime.UtcNow;
        //        foreach (var row in current_items)
        //        {
        //            row.date_sign = dt;


        //        }

        //        await context.SaveChangesAsync();

        //        return Ok(new DataResponse()
        //        {
        //            IsSuccess = true,
        //            Data = dt,

        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new DataResponse()
        //        {
        //            Data = null,
        //            IsSuccess = false,
        //            Errors = new List<string>() { helper.get_exception_message(ex) }
        //        });
        //    }

        //}

        /////////////



        //////////////


        public class scc_dto
        {

            public int flight_id { get; set; }
            public int crew_id { get; set; }




            public string catering_issue { get; set; }
            public string airport_service { get; set; }
            public string technical { get; set; }
            public string safety_issue { get; set; }
            public string general_issue { get; set; }
            public string remark { get; set; }



        }


        public class preflight_item_dto2
        {
            public int item_id { get; set; }
            public bool? is_servicable { get; set; }
            public string remark { get; set; }
            public int flight_id { get; set; }
            public int crew_id { get; set; }

        }
        public class preflight_dto2
        {
            public List<preflight_item_dto2> items { get; set; }
        }
        public class preflight_item_dto
        {
            public int item_id { get; set; }
            public bool is_servicable { get; set; }
            public string remark { get; set; }

        }
        public class preflight_dto
        {
            public int crew_id { get; set; }
            public int flight_id { get; set; }
            public List<preflight_item_dto> items { get; set; }
            public string remark { get; set; }

        }


        /////////////
    }

    public class DataResponse
    {
        public bool IsSuccess { get; set; }
        public object Data { get; set; }
        public List<string> Errors { get; set; }
        public List<string> Messages { get; set; }
    }
    public class helper
    {
        public static string get_exception_message(Exception ex)
        {
            var msg = ex.Message;
            if (ex.InnerException != null)
                msg += "   INNER:" + ex.InnerException.Message;
            return msg;
        }
    }
}
