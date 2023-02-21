namespace issue_api.Models
{
    public class LoginClass
    {
        public class Loginmodel
        {
            public string username { get; set; }
            public string password { get; set; }
        }
    }

    public class res
    {
        public string sqlstatus { get; set; }
        public string sqlmessage { get; set; }
        public string caes_name  { get; set; }
        public string status_end  { get; set; }
        public string email  { get; set; }

    }

    public class res_login
    {
        public string sqlstatus { get; set; }
        public string sqlmessage { get; set; }
        public string user_id { get; set; }
        public string position { get; set; }
    }
    public class req_text
    {
        public string text { get; set; }
        public string type { get; set; }
        public string userid { get; set; }
    }
    public class req_img
    {
        public string userid { get; set; }
        public string img { get; set; }
    }

    public class req_issue_id
    {
        public string id { get; set; }
    }
    public class res_issuelog
    {
        public string project { get; set; }
        public string case_name { get; set; }
        public string module { get; set; }
        public string Issue { get; set; }
        public string name { get; set; }
        public string createdate { get; set; }
        public string closedate { get; set; }
        public string requester { get; set; }
        public string program { get; set; }
        public string remark { get; set; }
    }
    public class report_all_issuelog
    {
        public string project { get; set; }
        public string case_name { get; set; }
        public string Issue { get; set; }
        public string name { get; set; }
        public string createdate { get; set; }
        public string status { get; set; }
        public string sname { get; set; }
    }
}
