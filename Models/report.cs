namespace issue_api.Models{

    public class req_report
    {
          public string date { get; set; }          
    }

    public class res_report
    {
          public string count { get; set; }
          public string name { get; set; }
          public string persen { get; set; }
          
    }
    public class res_getreport_issue
    {
          public string question { get; set; }
          public string status { get; set; }
          public string count_s { get; set; }
          public string createdate { get; set; }
          public string closedate { get; set; }
          public string closedate_2 { get; set; }
          public string case_name { get; set; }
          public string sname { get; set; }
          public string team { get; set; }      
    }

    public class res_getdatediff
    {
          public string question { get; set; }
          public string status_name { get; set; }
          public string days { get; set; }
          public string createdate { get; set; }
          public string case_name { get; set; }
 
    }

    
    
 }