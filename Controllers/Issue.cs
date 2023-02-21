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
using System.Net.Mail;

using static issue_api.Models.LoginClass;


namespace issue_api.Controllers
{
  [Route("api/[controller]")]
    [ApiController]
     public class Issue : ControllerBase
    {

        
 private readonly IDbConnection _connection;
        
        public Issue(IConfiguration config)
        {
            _connection = new SqlConnection(config.GetConnectionString("DefaultConnection"));
        }


        [HttpGet("Gettype")]
        public async Task<IActionResult> getclientAsync()
        {
            try
            {
                using IDbConnection conn = _connection;
                var sqlText = "SELECT * FROM dbo.type";
                var result = await conn.QueryAsync<res_type>(sqlText);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("Gettype_detail")]
        public async Task<IActionResult> getorderAsync(string type)
        {
            try
            {

            using IDbConnection conn = _connection;
             var sqlText = "SELECT * FROM dbo.type_detail WHERE type='"+type+"'";
            var result = await conn.QueryAsync<res_typedetail>(sqlText);
            return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("GetPGname")]
        public async Task<IActionResult> GetPGnameAsync()
        {
            try
            {

            using IDbConnection conn = _connection;
             var sqlText = "SELECT US.name,team.name AS team,US.user_id FROM  dbo.[user] US LEFT JOIN dbo.team ON team.team_id = US.team WHERE position_id ='3'";
            var result = await conn.QueryAsync<res_PGname>(sqlText);
            return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet("GetPriority")]
        public async Task<IActionResult> GetPriorityAsync()
        {
            try
            {

            using IDbConnection conn = _connection;
             var sqlText = "  SELECT * FROM dbo.priority";
            var result = await conn.QueryAsync<res_priority>(sqlText);
            return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("GetStatus")]
        public async Task<IActionResult> GetStatus()
        {
            try
            {

            using IDbConnection conn = _connection;
             var sqlText = "SELECT * FROM dbo.status";
            var result = await conn.QueryAsync<res_status>(sqlText);
            return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

          [HttpPost("Editissue_by_id")]
        public async Task<dynamic> Post18([FromBody] req_issue_id[] files)
        {
            try
            {
                //string res = JsonConvert.SerializeObject(files[0]);

                List<res_editissuel> res_db;

                var productParam = new DynamicParameters();
                foreach (req_issue_id item in files)
                {

                    productParam.Add("@id", files[0].id);

                }
                using (IDbConnection conn = _connection)
                {
                    IEnumerable<res_editissuel> key = await conn.QueryAsync<res_editissuel>("editissue_by_id", productParam, commandType: CommandType.StoredProcedure);
                    res_db = key.ToList();
                  
                }
                return res_db;

            }
            catch (System.Exception ex)
            {
                return "Error" + ex.ToString();
            }
        }


          [HttpPost("Addnewissue")]
        public async Task<dynamic> Addnewissue20([FromBody] req_newissuel[] files)
        {
            try
            {
                List<res> res_db;

                var productParam = new DynamicParameters();
                foreach (req_newissuel item in files)
                {

                    productParam.Add("@userid", files[0].userid);
                    productParam.Add("@question", files[0].question);
                    productParam.Add("@status_case", files[0].status);
                    productParam.Add("@type", files[0].type);
                    productParam.Add("@type_no", files[0].type_no);
                    productParam.Add("@module", files[0].module);
                    productParam.Add("@remark", files[0].remark);
                    productParam.Add("@requester", files[0].requester);
                    productParam.Add("@pic1", files[0].pic1);
                    productParam.Add("@pic2", files[0].pic2);
                    productParam.Add("@pic3", files[0].pic3);
 
                }
                using (IDbConnection conn = _connection)
                {
                    IEnumerable<res> key = await conn.QueryAsync<res>("addnewcase", productParam, commandType: CommandType.StoredProcedure);
                    res_db = key.ToList();
                    LineNotify(
                    "\n 🚩 New"+
                    "\n Issue: "+res_db[0].caes_name
                    ,0,0);

                    // SendEmail("",res_db[0].caes_name,files[0].question,files[0].requester);
                }
                return res_db;

            }
            catch (System.Exception ex)
            {
                return "Error" + ex.ToString();
            }
        }


          [HttpPost("Update_issuebyid_admin")]
        public async Task<dynamic> Update_issuebyid_admin([FromBody] req_updateissue[] files)
        {
            try
            {
                List<res_to_line_and_web> res_db;

                var productParam = new DynamicParameters();
                foreach (req_updateissue item in files)
                {

                    productParam.Add("@ticketid", files[0].ticketid);
                    productParam.Add("@status_new", files[0].status);
                    productParam.Add("@remark", files[0].remark);
                    productParam.Add("@pri_id", files[0].pri_id);
                    productParam.Add("@close", files[0].close);
                    productParam.Add("@programmer", files[0].programmer);

                }
                using (IDbConnection conn = _connection)
                {
                    IEnumerable<res_to_line_and_web> key = await conn.QueryAsync<res_to_line_and_web>("Updateissue_byid_admin", productParam, commandType: CommandType.StoredProcedure);
                    res_db = key.ToList();


                            LineNotify(
                            "\n Ticket No. "+files[0].ticketid+
                            "\n "+res_db[0].res_status+
                            "\n Date:"+DateTime.Now.ToString()+
                            "\n By:Team "+res_db[0].team+
                            "\n Programer: "+res_db[0].programer
                            ,0,0);

                    // string statusMessage;

                    // switch (res_db[0].status_end.ToLower())
                    // {
                    //     case "pending":
                    //         LineNotify(
                    //         "\n Ticket No. "+files[0].ticketid+
                    //         "\n "+res_db[0].res_status+
                    //         "\n Date:"+DateTime.Now.ToString()+
                    //         "\n By:Team "+res_db[0].team+
                    //         "\n Programer: "+res_db[0].programer
                    //         ,0,0);
                    //         break;
                    //     case "waiting from sa":
                    //         statusMessage = "⏳ Waiting from SA";
                    //         break;
                    //     case "work in process":
                    //         statusMessage = "⚙️ Work in Process";
                    //         break;
                    //     case "completed":
                    //         statusMessage = "✅ Completed";
                    //         break;
                    //     default:
                    //         statusMessage = res_db[0].status_end;
                    //         break;
                    // }


                }
                return res_db;

            }
            catch (System.Exception ex)
            {
                return "Error" + ex.ToString();
            }
        }



          [HttpPost("Updateissue_by_id")]
        public async Task<dynamic> Updateissue_by_id([FromBody] req_newissuel[] files)
        {
            try
            {
                List<res> res_db;

                var productParam = new DynamicParameters();
                foreach (req_newissuel item in files)
                {

                    productParam.Add("@userid", files[0].userid);
                    productParam.Add("@ticketid", files[0].ticketid);
                    productParam.Add("@question", files[0].question);
                    productParam.Add("@type", files[0].type);
                    productParam.Add("@type_no", files[0].type_no);
                    productParam.Add("@module", files[0].module);
                    productParam.Add("@remark", files[0].remark);
                    productParam.Add("@requester", files[0].requester);


                }
                using (IDbConnection conn = _connection)
                {
                    IEnumerable<res> key = await conn.QueryAsync<res>("Updateissue_byid", productParam, commandType: CommandType.StoredProcedure);
                    res_db = key.ToList();
                }
                return res_db;

            }
            catch (System.Exception ex)
            {
                return "Error" + ex.ToString();
            }
        }


          [HttpPost("Deleteissue")]
        public async Task<dynamic> Deleteissue([FromBody] req_ticket[] files)
        {
            try
            {
                List<res> res_db;

                var productParam = new DynamicParameters();
                foreach (req_ticket item in files)
                {

                    productParam.Add("@ticketid", files[0].ticketid);

                }
                using (IDbConnection conn = _connection)
                {
                    IEnumerable<res> key = await conn.QueryAsync<res>("Delete_Ticket_byid", productParam, commandType: CommandType.StoredProcedure);
                    res_db = key.ToList();
                }
                return res_db;

            }
            catch (System.Exception ex)
            {
                return "Error" + ex.ToString();
            }
        }



private void LineNotify(string message, int stickerPackageID, int stickerID)
        {
              try
    {
        string encodedMessage = System.Web.HttpUtility.UrlEncode(message , Encoding.UTF8);
        var request = (HttpWebRequest)WebRequest.Create("https://notify-api.line.me/api/notify");
        var postData = "message=" + encodedMessage;
        if (stickerPackageID > 0 && stickerID > 0)
        {
            postData += "&stickerPackageId=" + stickerPackageID + "&stickerId=" + stickerID;
        }
        // if (pictureUrl != "")
        // {
        //     postData += "&imageThumbnail=" + pictureUrl + "&imageFullsize=" + pictureUrl;
        // }

        var data = Encoding.UTF8.GetBytes(postData);            
        request.Method = "POST";
        request.ContentType = "application/x-www-form-urlencoded";
        request.ContentLength = data.Length;
        request.Headers.Add("Authorization", "Bearer " + "UV346nKqvHNomyEjrC33zxRKn1PtlFOgKR23iA71hMy");
        var stream = request.GetRequestStream();
        stream.Write(data, 0, data.Length);
        var response = (HttpWebResponse)request.GetResponse();
        var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
    }
    catch (WebException ex)
    {
        var response = (HttpWebResponse)ex.Response;
        using (var reader = new StreamReader(response.GetResponseStream()))
        {
            string errorMessage = reader.ReadToEnd();
            Console.WriteLine("Line Notify API call failed: " + errorMessage);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Line Notify API call failed: " + ex.ToString());
    }
        }





       [HttpPost("Updatefeedback_pass_byid")]
        public async Task<dynamic> Updatefeedback_pass_byid([FromBody] req_ticket[] files)
        {
            try
            {
                List<res> res_db;

                var productParam = new DynamicParameters();
                foreach (req_ticket item in files)
                {

                    productParam.Add("@ticketid", files[0].ticketid);

                }
                using (IDbConnection conn = _connection)
                {
                    IEnumerable<res> key = await conn.QueryAsync<res>("Updatefeedback_pass_byid", productParam, commandType: CommandType.StoredProcedure);
                    res_db = key.ToList();

                     LineNotify(
                            "\n✅ CLOSED "+
                            "\n Ticket No. "+files[0].ticketid+
                            "\n ⭕️ลูกค้ายืนยันการทดสอบ Issue นี้ผ่านแล้ว⭕️"
                            ,0,0);
                    // SendEmail("",res_db[0].caes_name,files[0].question,files[0].requester);
                }
                return res_db;

            }
            catch (System.Exception ex)
            {
                return "Error" + ex.ToString();
            }
        }


       [HttpPost("Updatefeedback_fail_byid")]
        public async Task<dynamic> Updatefeedback_fail_byid([FromBody] req_ticket[] files)
        {
            try
            {
                List<res> res_db;

                var productParam = new DynamicParameters();
                foreach (req_ticket item in files)
                {

                    productParam.Add("@ticketid", files[0].ticketid);

                }
                using (IDbConnection conn = _connection)
                {
                    IEnumerable<res> key = await conn.QueryAsync<res>("Updatefeedback_fail_byid", productParam, commandType: CommandType.StoredProcedure);
                    res_db = key.ToList();

                    LineNotify(
                            "\n⏳ Pending "+
                            "\n Ticket No. "+files[0].ticketid+
                            "\n ❌ลูกค้ายืนยันการทดสอบ Issue ยังไม่ผ่าน❌"
                            ,0,0);
                            string[] recipients = { "iop.iop254@gmail.com", "tanpisit@similantechnology.com" };
                     SendEmail_fail(recipients,files[0].ticketid,"","");
                }
                return res_db;

            }
            catch (System.Exception ex)
            {
                return "Error" + ex.ToString();
            }
        }



        private void SendEmail(string recipients,string caes_name,string issue,string requester)
        {
            string senderEmail = "spriteolo69@gmail.com";
            string senderPassword = "ypcuzjstzuveabxz";
            // recipient = "iop.iop254@gmail.com";
            MailMessage message = new MailMessage();
            message.From = new MailAddress(senderEmail);
            message.Body = 
            @"
         <html>
            <body>
                <style>
                .main {
                    line-height: normal;
                    color: red;
                }
                </style>

                <div>

                <div>
                <h1>บริษัทวันรัต (หน่ำเซียน) จำกัด</h1><br>
                <dd> <p>TicketNO TESTC210223145 </p>
                </div>

                <div class='main'>
                <p>
                    <span style='color: blue;''> Similan Technology Co., Ltd.</span><br />
                    <a href='http://www.similantechnology.com'>http://www.similantechnology.com </a> <br />
                    <span style='color: blue;'>Tel:</span> 0-2136-4888 (Auto) <br />
                    <span style='color: blue;'>Fax:</span>0-2397-5589 <br />
                    <span style='color: blue;'>Email:</span> center@similantechnology.com
                    <br>
                    <br>
                    
                    Disclaimer: <br>
                    <span style='color: blue;'>Similan Technology co.,ltd </span> not be liable for any loss
                    or damage arising directly or indirectly from the possession, or any
                    damages caused by any virus attached with this email. In addition, this
                    email may contain confidential whether or intended solely for the
                    recipient(s) named above. If you are not the authorized from <span style='color: blue;'> Similan
                    Technology co.,ltd.</span> Disclaimer: <span style='color: blue;'>To receive this email, you must not
                    publication or use of or reliance on information obtained.</span>
                </p>
                </div>
                </div>
            </body>
            </html> ";

            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(senderEmail, senderPassword);
            client.EnableSsl = true;
            client.Send(message);
        }




        private void SendEmail_pass(string recipient,string caes_name,string issue,string requester)
        {
            string senderEmail = "spriteolo69@gmail.com";
            string senderPassword = "ypcuzjstzuveabxz";
            recipient = "iop.iop254@gmail.com";
            MailMessage message = new MailMessage();
            message.From = new MailAddress(senderEmail);
            message.To.Add(recipient);
            message.Subject = "New Issue by "+requester;
            message.Body = 
             @"
        <html >
    <meta charset='UTF-8' />
    <link rel='icon' type='image/svg+xml' href='/vite.svg' />
    <meta name='viewport' content='width=device-width, initial-scale=1.0' />
            <body>
                <style>
                .main {
                    line-height: normal;
                    color: red;
                }
                </style>

                <div>

                <div>
                <h1  style='font-weight:bold' >บริษัท วันรัต (หน่ำเซียน) จำกัด</h1>
                <dd> <p > <span style='font-weight:bold'>TicketNO</span> TESTC210223145 </p>
                <dd> <p > * <u> เกิด error ฝั่งsap ในส่วน interface ตามรูป</u>*</p>
                <dd> <p >ทางลูกค้า ยืนยันว่าได้ทดสอบ issue ข้อนี้ผ่านแล้ว Status > Closed</p>

                </div>

                <div class='main'>
                <p>
                    <span style='color: blue;''> Similan Technology Co., Ltd.</span><br />
                    <a href='http://www.similantechnology.com'>http://www.similantechnology.com </a> <br />
                    <span style='color: blue;'>Tel:</span> 0-2136-4888 (Auto) <br />
                    <span style='color: blue;'>Fax:</span>0-2397-5589 <br />
                    <span style='color: blue;'>Email:</span> center@similantechnology.com
                    <br>
                    <br>
                    
                    Disclaimer: <br>
                    <span style='color: blue;'>Similan Technology co.,ltd </span> not be liable for any loss
                    or damage arising directly or indirectly from the possession, or any
                    damages caused by any virus attached with this email. In addition, this
                    email may contain confidential whether or intended solely for the
                    recipient(s) named above. If you are not the authorized from <span style='color: blue;'> Similan
                    Technology co.,ltd.</span> Disclaimer: <span style='color: blue;'>To receive this email, you must not
                    publication or use of or reliance on information obtained.</span>
                </p>
                </div>
                </div>
            </body>
            </html> ";

            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(senderEmail, senderPassword);
            client.EnableSsl = true;
            client.Send(message);
        }

        private void SendEmail_fail(string[] recipients,string caes_name,string issue,string requester)
        {
            string senderEmail = "spriteolo69@gmail.com";
            string senderPassword = "ypcuzjstzuveabxz";
            string result; 
            // recipient = "iop.iop254@gmail.com";
            MailMessage message = new MailMessage();
            message.From = new MailAddress(senderEmail);
           
            foreach (string recipient in recipients)
            {
                message.To.Add(recipient);
            }
 
            // var issue_res = issueAsync( caes_name);
            
        
            message.Subject = "New Issue by "+requester;
            message.Body = 
            @"
       <html>
            <body>
                <style>
                .main {
                    line-height: normal;
                    color: red;
                }
                </style>

    <div>

                <div>
                <h1>บริษัทวันรัต (หน่ำเซียน) จำกัด</h1><br>
                <dd> <p>TicketNO TESTC210223145 </p>
                </div>

                <div class='main'>
                <p>
                    <span style='color: blue;''> Similan Technology Co., Ltd.</span><br />
                    <a href='http://www.similantechnology.com'>http://www.similantechnology.com </a> <br />
                    <span style='color: blue;'>Tel:</span> 0-2136-4888 (Auto) <br />
                    <span style='color: blue;'>Fax:</span>0-2397-5589 <br />
                    <span style='color: blue;'>Email:</span> center@similantechnology.com
                    <br>
                    <br>
                    
                    Disclaimer: <br>
                    <span style='color: blue;'>Similan Technology co.,ltd </span> not be liable for any loss
                    or damage arising directly or indirectly from the possession, or any
                    damages caused by any virus attached with this email. In addition, this
                    email may contain confidential whether or intended solely for the
                    recipient(s) named above. If you are not the authorized from <span style='color: blue;'> Similan
                    Technology co.,ltd.</span> Disclaimer: <span style='color: blue;'>To receive this email, you must not
                    publication or use of or reliance on information obtained.</span>
                </p>
                </div>
                </div>
            </body>
            </html> ";

            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(senderEmail, senderPassword);
            client.EnableSsl = true;
            client.Send(message);
        }




        private async Task<IActionResult> issueAsync(string case_name)
        {
            try
            {
                using IDbConnection conn = _connection;
                var sqlText = @"
                                SELECT 
                                CA.case_name,
                                US.company,
                                CA.question
                                FROM  dbo.[case] CA LEFT JOIN
                                dbo.[user] US ON US.user_id = CA.user_id
                                WHERE case_name='"+case_name+"'";
                var result = await conn.QueryAsync<res_to_email>(sqlText);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


    }

}




