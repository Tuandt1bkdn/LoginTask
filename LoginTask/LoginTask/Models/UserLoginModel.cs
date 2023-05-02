namespace LoginTask.Models
{   
    public class UserModel
    {
        public List<UserInfoModel> UserList { get; set; }
    }
    public class UserLoginModel
    {   
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class UserInfoModel
    {
        public int? UserId { get; set; }

        public string Name { get; set; }

        public string Birthday { get; set; }

        public string Location { get; set; }

        public string Email { get; set; }
    }

}
