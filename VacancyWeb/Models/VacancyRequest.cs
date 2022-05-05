using System;
using System.Collections.Generic;

#nullable disable

namespace VacancyWeb.Models
{
    public partial class VacancyRequest
    {
        public VacancyRequest()
        {
            Conditions = new HashSet<Condition>();
            Duties = new HashSet<Duty>();
            Requests = new HashSet<Request>();
            Requirements = new HashSet<Requirement>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public double? SalaryMin { get; set; }
        public double? SalaryMax { get; set; }
        public int Experience { get; set; }
        public int TypeOfEmployment { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int Staff { get; set; }
        public int Type { get; set; }
        public int TimeTable { get; set; }
        public int Status { get; set; }

        public virtual staff StaffNavigation { get; set; }
        public virtual StatusVacancy StatusNavigation { get; set; }
        public virtual TimeTable TimeTableNavigation { get; set; }
        public virtual TypeVacancy TypeNavigation { get; set; }
        public virtual TypeOfEmployment TypeOfEmploymentNavigation { get; set; }
        public virtual ICollection<Condition> Conditions { get; set; }
        public virtual ICollection<Duty> Duties { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
        public virtual ICollection<Requirement> Requirements { get; set; }
    }
}
