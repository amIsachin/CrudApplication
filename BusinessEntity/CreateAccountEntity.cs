namespace BusinessEntity
{
    public class CreateAccountEntity : BaseEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
