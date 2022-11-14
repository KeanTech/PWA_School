namespace PWA_Blazor.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> Pictures { get; set; }


        public User()
        {
            Pictures = new List<string>();
        }
    }
}
