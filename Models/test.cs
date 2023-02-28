namespace issue_api.Models
{
    public class test
    {
        public string position_id { get; set; }
        public string position { get; set; }

    }
    public class modules
    {
        public string module_id { get; set; }
        public string module { get; set; }

    }
    public class Userid
    {
        public string userid { get; set; }

    }
    public class req_issuelog_all_by_search
    {
        public string text { get; set; }
        public string userid { get; set; }
        public string datestart { get; set; }
        public string dateend { get; set; }
        public string status { get; set; }
        public string team { get; set; }

    }
    public class res_issueall
    {
        public string case_name { get; set; }
        public string question { get; set; }
        public string send { get; set; }
        public string type { get; set; }
        public string team { get; set; }
        public string createdate { get; set; }
        public string closedate { get; set; }
        public string status { get; set; }
        public string username { get; set; }

    }



}
