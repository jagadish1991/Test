using System;
using System.Collections.Generic;

#nullable disable

namespace Core.Entity
{
    public partial class Apiuserdetail
    {
        public int UserId { get; set; }
        public string CompanyName { get; set; }
        public string ContactPerson { get; set; }
        public string Telephone { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int? Status { get; set; }
        public int? Ideleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string UserTypeId { get; set; }
    }
}
