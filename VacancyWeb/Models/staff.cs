using System;
using System.Collections.Generic;

#nullable disable

namespace VacancyWeb.Models
{
    public partial class staff
    {
        public staff()
        {
            Requests = new HashSet<Request>();
            VacancyRequests = new HashSet<VacancyRequest>();
        }

        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Post { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public virtual Post PostNavigation { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
        public virtual ICollection<VacancyRequest> VacancyRequests { get; set; }
    }
}
