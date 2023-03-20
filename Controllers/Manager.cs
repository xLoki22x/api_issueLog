using Microsoft.AspNetCore.Mvc;
using System.Data;
using Dapper;
using System.Data.SqlClient;
using issue_api.Models;
using Newtonsoft.Json;
using static issue_api.Models.LoginClass;

  
namespace issue_api.Controllers  
{  
     [Route("api/[controller]")]
    [ApiController]

    public class Manager:Controller    
    {  
        private readonly IDbConnection _connection;

         public Manager(IConfiguration config)
        {
            _connection = new SqlConnection(config.GetConnectionString("DefaultConnection"));
        }


        
        [HttpGet("Manager_all")]
        public async Task<dynamic> get50Async()
        {
            try
            {
                List<res_manager> res_db;
                using (IDbConnection conn = _connection)
                {

                    IEnumerable<res_manager> key = await conn.QueryAsync<res_manager>("AllManager", commandType: CommandType.StoredProcedure);
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


         [HttpPost("Getmanager_byid")]
        public async Task<dynamic> Post18([FromBody] req_issue_id[] files)
        {
            try
            {
                //string res = JsonConvert.SerializeObject(files[0]);

                List<res_manager_by_id> res_db;

                var productParam = new DynamicParameters();
                foreach (req_issue_id item in files)
                {

                    productParam.Add("@id", files[0].id);

                }
                using (IDbConnection conn = _connection)
                {
                    IEnumerable<res_manager_by_id> key = await conn.QueryAsync<res_manager_by_id>("Getmanager_byid", productParam, commandType: CommandType.StoredProcedure);
                    res_db = key.ToList();
                }
                return res_db;

            }
            catch (System.Exception ex)
            {
                return "Error" + ex.ToString();
            }
        }


         [HttpPost("Delete_manager")]
        public async Task<dynamic> Delete_manager([FromBody] req_issue_id[] files)
        {
            try
            {
                //string res = JsonConvert.SerializeObject(files[0]);

                List<res> res_db;

                var productParam = new DynamicParameters();
                foreach (req_issue_id item in files)
                {

                    productParam.Add("@id", files[0].id);

                }
                using (IDbConnection conn = _connection)
                {
                    IEnumerable<res> key = await conn.QueryAsync<res>("delete_manager", productParam, commandType: CommandType.StoredProcedure);
                    res_db = key.ToList();
                }
                return res_db;

            }
            catch (System.Exception ex)
            {
                return "Error" + ex.ToString();
            }
        }


         [HttpPost("Manager_by_search")]
        public async Task<dynamic> Manager_by_search([FromBody] req_text[] files)
        {
            try
            {
                //string res = JsonConvert.SerializeObject(files[0]);

                List<res_manager> res_db;

                var productParam = new DynamicParameters();
                foreach (req_text item in files)
                {

                    productParam.Add("@text", files[0].text);

                }
                using (IDbConnection conn = _connection)
                {
                    IEnumerable<res_manager> key = await conn.QueryAsync<res_manager>("Manager_by_search", productParam, commandType: CommandType.StoredProcedure);
                    res_db = key.ToList();
                }
                return res_db;

            }
            catch (System.Exception ex)
            {
                return "Error" + ex.ToString();
            }
        }




        [HttpPost("Getmanager_byid_test")]
        public async Task<IActionResult> getorderAsync(string id)
        {
            try
            {

            using IDbConnection conn = _connection;
             var sqlText = "SELECT * FROM [dbo].[user] LEFT JOIN dbo.position ON position.position_id = [user].position_id WHERE user_id='"+id+"'";
            var result = await conn.QueryAsync<res_manager_by_id>(sqlText);
            return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

                [HttpGet("GetPosition")]
        public async Task<IActionResult> GetPositionAsync()
        {
            try
            {

                using IDbConnection conn = _connection;
                var sqlText = "SELECT * FROM  dbo.position";
                var result = await conn.QueryAsync<res_position>(sqlText);
                return Ok(result);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

                [HttpGet("GetTeamWMS")]
        public async Task<IActionResult> GetTeamWMSAsync()
        {
            try
            {

                using IDbConnection conn = _connection;
                var sqlText = "SELECT * FROM dbo.team";
                var result = await conn.QueryAsync<res_team>(sqlText);
                return Ok(result);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

   [HttpPost("Editmanager_byid")]
        public async Task<dynamic> Editmanager_byid([FromBody] manager_by_id[] files)
        {
            try
            {
              
              string comm = JsonConvert.SerializeObject(files[0]);

                List<res> res_db;

                var productParam = new DynamicParameters();
                foreach (manager_by_id item in files)
                {

                    productParam.Add("@id", files[0].userid);
                    productParam.Add("@name", files[0].name);
                    productParam.Add("@company", files[0].company);
                    productParam.Add("@username", files[0].username);
                    productParam.Add("@password", files[0].password);
                    productParam.Add("@email1", files[0].email);
                    productParam.Add("@email2", files[0].email1);
                    productParam.Add("@email3", files[0].email2);
                    productParam.Add("@email4", files[0].email3);
                    productParam.Add("@email5", files[0].email4);
                    productParam.Add("@email6", files[0].email5);
                    productParam.Add("@email7", files[0].email6);
                    productParam.Add("@email8", files[0].email7);
                    productParam.Add("@email9", files[0].email8);
                    productParam.Add("@email10", files[0].email9);
                    productParam.Add("@position", files[0].position);
                    productParam.Add("@team", files[0].team);
                    productParam.Add("@codename", files[0].sname);
                    productParam.Add("@exp", files[0].exp);
                    productParam.Add("@statusactive", files[0].status);

     
                    Console.WriteLine("Standard Numeric Format Specifiers",files[0].userid);

                }
                using (IDbConnection conn = _connection)
                {
                    IEnumerable<res> key = await conn.QueryAsync<res>("Editmanager_byid", productParam, commandType: CommandType.StoredProcedure);
                    res_db = key.ToList();
                }
                return res_db ;

            }
            catch (System.Exception ex)
            {
                return "Error" + ex.ToString();
            }
        }        


   [HttpPost("addmanager")]
        public async Task<dynamic> addmanager([FromBody] manager_by_id[] files)
        {
            try
            {
              
              string comm = JsonConvert.SerializeObject(files[0]);

                List<res> res_db;

                var productParam = new DynamicParameters();
                foreach (manager_by_id item in files)
                {

                    productParam.Add("@id", files[0].userid);
                    productParam.Add("@name", files[0].name);
                    productParam.Add("@company", files[0].company);
                    productParam.Add("@username", files[0].username);
                    productParam.Add("@password", files[0].password);
                    productParam.Add("@email1", files[0].email);
                    productParam.Add("@email2", files[0].email1);
                    productParam.Add("@email3", files[0].email2);
                    productParam.Add("@email4", files[0].email3);
                    productParam.Add("@email5", files[0].email4);
                    productParam.Add("@email6", files[0].email5);
                    productParam.Add("@email7", files[0].email6);
                    productParam.Add("@email8", files[0].email7);
                    productParam.Add("@email9", files[0].email8);
                    productParam.Add("@email10", files[0].email9);
                    productParam.Add("@position", files[0].position);
                    productParam.Add("@team", files[0].team);
                    productParam.Add("@codename", files[0].sname);
                    productParam.Add("@exp", files[0].exp);
                    productParam.Add("@statusactive", files[0].status);

                }
                using (IDbConnection conn = _connection)
                {
                    IEnumerable<res> key = await conn.QueryAsync<res>("addmanager", productParam, commandType: CommandType.StoredProcedure);
                    res_db = key.ToList();
                }
                return res_db ;

            }
            catch (System.Exception ex)
            {
                return "Error" + ex.ToString();
            }
        }        




        
    }  
}  