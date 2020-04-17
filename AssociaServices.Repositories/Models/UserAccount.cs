﻿using System;
using System.Collections.Generic;

namespace AssociaServices.Repositories.Models
{
    public partial class UserAccount
    {
        public UserAccount()
        {
            AppaAccessLog = new HashSet<AppaAccessLog>();
        }

        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public DateTimeOffset? Dob { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public string Address { get; set; }
        public Guid? CompanyId { get; set; }
        public Guid? RoleId { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public DateTimeOffset? UpdatedDateTime { get; set; }

        public virtual Company Company { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<AppaAccessLog> AppaAccessLog { get; set; }
    }
}
