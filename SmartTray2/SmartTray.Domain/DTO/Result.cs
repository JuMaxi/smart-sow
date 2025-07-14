using SmartTray.Domain.Models;

namespace SmartTray.Domain.DTO
{
    public class Result
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }

        public Result(bool success, string errorMessage)
        {
            Success = success;
            ErrorMessage = errorMessage;
        }

        public static Result OK => new Result(true, string.Empty);
        public static Result False(string msg) => new Result(false, msg);
    }

    public class LoginResult : Result
    {
        public User? User { get; set; }

        public LoginResult(string errorMessage) : base(false, errorMessage)
        {
        }

        public LoginResult(User user) : base(true, string.Empty)
        {
            User = user;
        }
    }
}
