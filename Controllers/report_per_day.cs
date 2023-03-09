using Microsoft.AspNetCore.Mvc;
using System.Data;
using System;
using System.IO;
using System.IO.Enumeration;
using Dapper;
using System.Net.Http.Headers;
using System.Text;
using System.Net;
using Newtonsoft.Json; 
using System.Web;
using System.Data.SqlClient;
using issue_api.Models;



namespace issue_api.Controllers
{
  [Route("api/[controller]")]
    [ApiController]
     public class Reportperday : ControllerBase
    {

private readonly IDbConnection _connection;
        
        public Reportperday(IConfiguration config)
        {
            _connection = new SqlConnection(config.GetConnectionString("DefaultConnection"));
        }

        [HttpPost("getreport_status")]
        public async Task<dynamic> Post18([FromBody] req_report[] files)
        {
            try
            {
                List<res_report> res_db;

                var productParam = new DynamicParameters();
                foreach (req_report item in files)
                {

                    productParam.Add("@date", files[0].date);

                }
                using (IDbConnection conn = _connection)
                {
                    IEnumerable<res_report> key = await conn.QueryAsync<res_report>("report_per_day_status", productParam, commandType: CommandType.StoredProcedure);
                    res_db = key.ToList();
                }
                return res_db;

            }
            catch (System.Exception ex)
            {
                return "Error" + ex.ToString();
            }
        }


        [HttpPost("getreport_programer")]
        public async Task<dynamic> getreport_programer([FromBody] req_report[] files)
        {
            try
            {
                List<res_report> res_db;

                var productParam = new DynamicParameters();
                foreach (req_report item in files)
                {

                    productParam.Add("@date", files[0].date);

                }
                using (IDbConnection conn = _connection)
                {
                    IEnumerable<res_report> key = await conn.QueryAsync<res_report>("report_per_day_programmer", productParam, commandType: CommandType.StoredProcedure);
                    res_db = key.ToList();
                }
                return res_db;

            }
            catch (System.Exception ex)
            {
                return "Error" + ex.ToString();
            }
        }

        [HttpPost("getreport_issue")]
        public async Task<dynamic> getreport_issue([FromBody] req_report[] files)
        {
            try
            {
                List<res_getreport_issue> res_db;

                var productParam = new DynamicParameters();
                foreach (req_report item in files)
                {

                    productParam.Add("@date", files[0].date);

                }
                using (IDbConnection conn = _connection)
                {
                    IEnumerable<res_getreport_issue> key = await conn.QueryAsync<res_getreport_issue>("getreport_issue", productParam, commandType: CommandType.StoredProcedure);
                    res_db = key.ToList();
                }
                return res_db;

            }
            catch (System.Exception ex)
            {
                return "Error" + ex.ToString();
            }
        }

        ////////////////////////////////////////////////// date //////////////////////////////////



        [HttpPost("getreport_status_date")]
        public async Task<dynamic> getreport_status_date([FromBody] req_report_date[] files)
        {
            try
            {
                List<res_report> res_db;

                var productParam = new DynamicParameters();
                foreach (req_report_date item in files)
                {

                    productParam.Add("@datestart", files[0].datestart);
                    productParam.Add("@dateend", files[0].dateend);

                }
                using (IDbConnection conn = _connection)
                {
                    IEnumerable<res_report> key = await conn.QueryAsync<res_report>("report_per_date_status", productParam, commandType: CommandType.StoredProcedure);
                    res_db = key.ToList();
                }
                return res_db;

            }
            catch (System.Exception ex)
            {
                return "Error" + ex.ToString();
            }
        }


        [HttpPost("getreport_programer_date")]
        public async Task<dynamic> getreport_programer_date([FromBody] req_report_date[] files)
        {
            try
            {
                List<res_report> res_db;

                var productParam = new DynamicParameters();
                foreach (req_report_date item in files)
                {

                     productParam.Add("@datestart", files[0].datestart);
                    productParam.Add("@dateend", files[0].dateend);

                }
                using (IDbConnection conn = _connection)
                {
                    IEnumerable<res_report> key = await conn.QueryAsync<res_report>("report_per_date_programmer", productParam, commandType: CommandType.StoredProcedure);
                    res_db = key.ToList();
                }
                return res_db;

            }
            catch (System.Exception ex)
            {
                return "Error" + ex.ToString();
            }
        }


        [HttpPost("getreport_issue_date")]
        public async Task<dynamic> getreport_issue_date([FromBody] req_report_date[] files)
        {
            try
            {
                List<res_getreport_issue> res_db;

                var productParam = new DynamicParameters();
                foreach (req_report_date item in files)
                {
                    productParam.Add("@datestart", files[0].datestart);
                    productParam.Add("@dateend", files[0].dateend);

                }
                using (IDbConnection conn = _connection)
                {
                    IEnumerable<res_getreport_issue> key = await conn.QueryAsync<res_getreport_issue>("getreport_issue_date", productParam, commandType: CommandType.StoredProcedure);
                    res_db = key.ToList();
                }
                return res_db;

            }
            catch (System.Exception ex)
            {
                return "Error" + ex.ToString();
            }
        }

      

    }
}