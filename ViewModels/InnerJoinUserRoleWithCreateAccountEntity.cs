using System;

namespace ViewModels
{
    public class InnerJoinUserRoleWithCreateAccountEntity
    {
        public int UserRoleID{ get; set; }
        public string Role { get; set; }
        public int UserID { get; set; }
        public DateTime UserRoleCreatedOn{ get; set; }

        public int CreatedAccountID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public DateTime CreateAccountCreatedOn{ get; set; }
    }
}
