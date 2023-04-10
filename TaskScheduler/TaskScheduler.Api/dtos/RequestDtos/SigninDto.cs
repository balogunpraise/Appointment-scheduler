namespace TaskScheduler.Api.dtos.RequestDtos
{
    public class SigninDto
    {
        public string EmailOrUsername { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
