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
     public class Model : ControllerBase
    {
 private readonly IDbConnection _connection;
        
        public Model(IConfiguration config)
        {
            _connection = new SqlConnection(config.GetConnectionString("DefaultConnection"));
        }


        
        [HttpGet("GetModeul")]
        public async Task<IActionResult> getclientAsync()
        {
            try
            {
                using IDbConnection conn = _connection;
                var sqlText = "SELECT * FROM  dbo.module";
                var result = await conn.QueryAsync<modules>(sqlText);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


               
        [HttpPost("Addmodule_test")]
        public async Task<IActionResult> getorderAsync(string Module)
        {
            try
            {

            using IDbConnection conn = _connection;
             var sqlText = "INSERT INTO dbo.module(module)VALUES(N'"+Module+"');";
            var result = await conn.QueryAsync(sqlText);
            return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


          [HttpPost("Addmodule")]
        public async Task<dynamic> Post18([FromBody] module[] files)
        {
            try
            {
                //string res = JsonConvert.SerializeObject(files[0]);

                List<res> res_db;

                var productParam = new DynamicParameters();
                foreach (module item in files)
                {

                    productParam.Add("@module", files[0].Module);

                }
                using (IDbConnection conn = _connection)
                {
                    IEnumerable<res> key = await conn.QueryAsync<res>("AddModule", productParam, commandType: CommandType.StoredProcedure);
                    res_db = key.ToList();
                }
                return res_db;

            }
            catch (System.Exception ex)
            {
                return "Error" + ex.ToString();
            }
        }


          [HttpPost("editmodule")]
        public async Task<dynamic> editmodule([FromBody] module[] files)
        {
            try
            {
                //string res = JsonConvert.SerializeObject(files[0]);

                List<res> res_db;

                var productParam = new DynamicParameters();
                foreach (module item in files)
                {

                    productParam.Add("@id", files[0].id);
                    productParam.Add("@module", files[0].Module);

                }
                using (IDbConnection conn = _connection)
                {
                    IEnumerable<res> key = await conn.QueryAsync<res>("Editmodule_byid", productParam, commandType: CommandType.StoredProcedure);
                    res_db = key.ToList();
                }
                return res_db;

            }
            catch (System.Exception ex)
            {
                return "Error" + ex.ToString();
            }
        }

          [HttpPost("DeleteModule")]
        public async Task<dynamic> Post20([FromBody] module[] files)
        {
            try
            {
                //string res = JsonConvert.SerializeObject(files[0]);

                List<res> res_db;

                var productParam = new DynamicParameters();
                foreach (module item in files)
                {

                    productParam.Add("@module", files[0].Module);

                }
                using (IDbConnection conn = _connection)
                {
                    IEnumerable<res> key = await conn.QueryAsync<res>("DeleteModule", productParam, commandType: CommandType.StoredProcedure);
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