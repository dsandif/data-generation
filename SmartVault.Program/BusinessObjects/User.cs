using System;

namespace SmartVault.Program.BusinessObjects
{
    public partial class User
    {
        public string FullName => $"{FirstName} {LastName}";
        public DateTime CreatedOn { get; set; }
    }
}
