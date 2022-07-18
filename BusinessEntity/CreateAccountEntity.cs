namespace BusinessEntity
{
    internal class CreateAccountEntity : BaseEntity
    {
        public string UserName { get; set; }
        public string Emial { get; set; }
        public string Number { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
