namespace issue_api.Models{
    public class res_manager
    {
        public string user_id { get; set; }
        public string name { get; set; }
        public string company { get; set; }
        public string email { get; set; }
        public string position { get; set; }
        public string username { get; set; }
        public string sname { get; set; }
        public string team { get; set; }

    }
    public class res_manager_by_id
    {
        public string user_id { get; set; }
        public string namecompany { get; set; }
        public string company { get; set; }
        public string position { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string teamname { get; set; }
        public string sname { get; set; }
        public string team { get; set; }
        public string email { get; set; }
        public string email1 { get; set; }
        public string email2 { get; set; }
        public string email3 { get; set; }
        public string email4 { get; set; }
        public string email5 { get; set; }
        public string email6 { get; set; }
        public string email7 { get; set; }
        public string email8 { get; set; }
        public string email9 { get; set; }
        public string life { get; set; }
        public string status { get; set; }
        public string expiration { get; set; }

    }
    public class manager_by_id
    {
        public string userid { get; set; }
        public string name { get; set; }
        public string company { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string email1 { get; set; }
        public string email2 { get; set; }
        public string email3 { get; set; }
        public string email4 { get; set; }
        public string email5 { get; set; }
        public string email6 { get; set; }
        public string email7 { get; set; }
        public string email8 { get; set; }
        public string email9 { get; set; }
        public string position { get; set; }
        public string team { get; set; }
        public string sname { get; set; }
        public string exp { get; set; }
        public string status { get; set; }
    }

  public class res_position{
     public string position_id { get; set; }
     public string position { get; set; }
  }

  public class res_team {
     public string team_id { get; set; }
     public string name { get; set; }
  }
}