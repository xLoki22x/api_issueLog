

namespace issue_api.Models{

    public class res_type
    {
          public string type { get; set; }
          public string type_name { get; set; }
    }

    public class res_status
    {
          public string status_id { get; set; }
          public string name { get; set; }
    }

    public class res_PGname
    {
          public string name { get; set; }
          public string user_id { get; set; }
          public string team { get; set; }
    }
    public class res_priority
    {
          public string pri_id { get; set; }
          public string pri_name { get; set; }
    }

    public class req_ticket
    {
          public string ticketid { get; set; }
    }

    public class res_typedetail
    {
          public string type_no { get; set; }
          public string type { get; set; }
          public string type_detail { get; set; }
          public string Importance { get; set; }
          public string min_day { get; set; }
          public string mid_day { get; set; }
          public string max_day { get; set; }
    }

    public class res_editissuel
    {
        public string project { get; set; }
        public string case_name { get; set; }
        public string module { get; set; }
        public string Issue { get; set; }
        public string name { get; set; }
        public string pri_id { get; set; }
        public string createdate { get; set; }
        public string closedate { get; set; }
        public string closedate_2 { get; set; }
        public string requester { get; set; }
        public string program { get; set; }
        public string remark { get; set; }
        public string type_name { get; set; }
        public string type_detail { get; set; }
        public string pic { get; set; }
        public string pic1 { get; set; }
        public string pic2 { get; set; }
    }
    
    public class req_newissuel
    {
        public string userid { get; set; }
        public string ticketid { get; set; }
        public string question { get; set; }
        public string status { get; set; }
        public string type { get; set; }
        public string type_no { get; set; }
        public string module { get; set; }
        public string remark { get; set; }
        public string requester { get; set; }
        public string pic1 { get; set; }
        public string pic2 { get; set; }
        public string pic3 { get; set; }

    }
    public class req_updateissue
    {
  
        public string ticketid { get; set; }
        public string marker { get; set; }
        public string status { get; set; }
        public string remark { get; set; }
        public string pri_id{ get; set; }
        public string close { get; set; }
        public string programmer { get; set; }

    }
    
    public class LineNotifyPayload
{
    public string message { get; set; }
    public int stickerPackageId { get; set; }
    public int stickerId { get; set; }
    public string imageThumbnail { get; set; }
    public string imageFullsize { get; set; }
}
    
 }