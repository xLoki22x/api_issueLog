using Microsoft.AspNetCore.Mvc;
using System.Data;
using Dapper;
using System.Data.SqlClient;
using issue_api.Models;
using static issue_api.Models.LoginClass;


namespace issue_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Home : ControllerBase
    {
        private readonly IDbConnection _connection;

        public Home(IConfiguration config)
        {
            _connection = new SqlConnection(config.GetConnectionString("DefaultConnection"));
        }



        [HttpPost("Getissue_byid")]
        public async Task<dynamic> Post18([FromBody] req_issue_id[] files)
        {
            try
            {
                //string res = JsonConvert.SerializeObject(files[0]);

                List<res_issuelog> res_db;

                var productParam = new DynamicParameters();
                foreach (req_issue_id item in files)
                {

                    productParam.Add("@id", files[0].id);

                }
                using (IDbConnection conn = _connection)
                {
                    IEnumerable<res_issuelog> key = await conn.QueryAsync<res_issuelog>("issuelog_by_id", productParam, commandType: CommandType.StoredProcedure);
                    res_db = key.ToList();
                }
                return res_db;

            }
            catch (System.Exception ex)
            {
                return "Error" + ex.ToString();
            }
        }


        [HttpGet("get_client")]
        public async Task<IActionResult> getclientAsync()
        {
            try
            {

                using IDbConnection conn = _connection;
                var sqlText = "SELECT position_id,position FROM dbo.position";
                var result = await conn.QueryAsync<test>(sqlText);
                return Ok(result);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }



        [HttpGet("Report_all")]
        public async Task<dynamic> get55Async()
        {
            try
            {
                List<report_all_issuelog> res_db;
                using (IDbConnection conn = _connection)
                {

                    IEnumerable<report_all_issuelog> key = await conn.QueryAsync<report_all_issuelog>("issuelog_all", commandType: CommandType.StoredProcedure);
                    res_db = key.ToList();
                }
                return res_db;
                ;
            }
            catch (System.Exception ex)
            {
                return "Error" + ex.ToString();
            }
        }


        [HttpPost("GetReport_by_user")]
        public async Task<dynamic> Post10([FromBody] Userid[] files)
        {
            try
            {
                //string res = JsonConvert.SerializeObject(files[0]);

                List<report_all_issuelog> res_db;

                var productParam = new DynamicParameters();
                foreach (Userid item in files)
                {

                    productParam.Add("@userid", files[0].userid);
                }
                using (IDbConnection conn = _connection)
                {
                    IEnumerable<report_all_issuelog> key = await conn.QueryAsync<report_all_issuelog>("issuelog_by_userid", productParam, commandType: CommandType.StoredProcedure);
                    res_db = key.ToList();
                }
                return res_db;

            }
            catch (System.Exception ex)
            {
                return "Error" + ex.ToString();
            }
        }


        [HttpGet("issueall")]
        public async Task<dynamic> issueAsync()
        {
            try
            {
                List<res_issueall> res_db;
                using (IDbConnection conn = _connection)
                {

                    IEnumerable<res_issueall> key = await conn.QueryAsync<res_issueall>("allissue", commandType: CommandType.StoredProcedure);
                    res_db = key.ToList();
                }
                return res_db;
                ;
            }
            catch (System.Exception ex)
            {
                return "Error" + ex.ToString();
            }
        }

        [HttpPost("issue_by_userid")]
        public async Task<dynamic> issue_by_useridAsync([FromBody] Userid[] files)
        {
            try
            {
                List<res_issueall> res_db;
                var productParam = new DynamicParameters();
                foreach (Userid item in files)
                {

                    productParam.Add("@userid", files[0].userid);

                }
                using (IDbConnection conn = _connection)
                {

                    IEnumerable<res_issueall> key = await conn.QueryAsync<res_issueall>("allissue_by_userid", productParam, commandType: CommandType.StoredProcedure);
                    res_db = key.ToList();
                }
                return res_db;
                ;
            }
            catch (System.Exception ex)
            {
                return "Error" + ex.ToString();
            }
        }


        [HttpPost("issue_by_search")]
        public async Task<dynamic> issue_by_searchAsync([FromBody] req_text[] files)
        {
            try
            {
                List<res_issueall> res_db;
                var productParam = new DynamicParameters();
                foreach (req_text item in files)
                {

                    productParam.Add("@text", files[0].text);
                    productParam.Add("@type", files[0].type);
                    productParam.Add("@userid", files[0].userid);

                }
                using (IDbConnection conn = _connection)
                {

                    IEnumerable<res_issueall> key = await conn.QueryAsync<res_issueall>("allissue_by_search", productParam, commandType: CommandType.StoredProcedure);
                    res_db = key.ToList();
                }
                return res_db;
                ;
            }
            catch (System.Exception ex)
            {
                return "Error" + ex.ToString();
            }









        }
        [HttpPost("Login")]
        public async Task<dynamic> Post18([FromBody] Loginmodel[] files)
        {
            try
            {
                //string res = JsonConvert.SerializeObject(files[0]);

                List<res_login> res_db;

                var productParam = new DynamicParameters();
                foreach (Loginmodel item in files)
                {

                    productParam.Add("@username", files[0].@username);
                    productParam.Add("@password", files[0].password);

                }
                using (IDbConnection conn = _connection)
                {
                    IEnumerable<res_login> key = await conn.QueryAsync<res_login>("check_login", productParam, commandType: CommandType.StoredProcedure);
                    res_db = key.ToList();
                }
                return res_db;

            }
            catch (System.Exception ex)
            {
                return "Error" + ex.ToString();
            }
        }


        [HttpPost("issuelog_all_by_search")]
        public async Task<dynamic> issuelog_all_by_searchAsync([FromBody] req_issuelog_all_by_search[] files)
        {
            try
            {
                List<report_all_issuelog> res_db;
                var productParam = new DynamicParameters();
                foreach (req_issuelog_all_by_search item in files)
                {

                    productParam.Add("@text", files[0].text);
                    productParam.Add("@datastart", files[0].datestart);
                    productParam.Add("@dataend", files[0].dateend);
                    productParam.Add("@status", files[0].status);
                    productParam.Add("@programer", files[0].team);

                }
                using (IDbConnection conn = _connection)
                {

                    IEnumerable<report_all_issuelog> key = await conn.QueryAsync<report_all_issuelog>("issuelog_all_by_search", productParam, commandType: CommandType.StoredProcedure);
                    res_db = key.ToList();
                }
                return res_db;
                ;
            }
            catch (System.Exception ex)
            {
                return "Error" + ex.ToString();
            }
        }


        [HttpPost("Getissue_report_by_user_search")]
        public async Task<dynamic> Getissue_report_by_user_search([FromBody] req_issuelog_all_by_search[] files)
        {
            try
            {
                List<report_all_issuelog> res_db;
                var productParam = new DynamicParameters();
                foreach (req_issuelog_all_by_search item in files)
                {

                    productParam.Add("@text", files[0].text);
                    productParam.Add("@userid", files[0].userid);
                    productParam.Add("@datastart", files[0].datestart);
                    productParam.Add("@dataend", files[0].dateend);
                    productParam.Add("@status", files[0].status);

                }
                using (IDbConnection conn = _connection)
                {

                    IEnumerable<report_all_issuelog> key = await conn.QueryAsync<report_all_issuelog>("Getissue_report_by_user_search", productParam, commandType: CommandType.StoredProcedure);
                    res_db = key.ToList();
                }
                return res_db;
                ;
            }
            catch (System.Exception ex)
            {
                return "Error" + ex.ToString();
            }
        }
    }


}
