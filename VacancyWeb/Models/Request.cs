using System;
using System.Collections.Generic;

#nullable disable

namespace VacancyWeb.Models
{
    public partial class Request
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Vacancy { get; set; }
        public int Status { get; set; }
        public int? Staff { get; set; }

        public virtual staff StaffNavigation { get; set; }
        public virtual StatusRequest StatusNavigation { get; set; }
        public virtual VacancyRequest VacancyNavigation { get; set; }
    }
}
