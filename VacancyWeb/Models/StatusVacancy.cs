using System;
using System.Collections.Generic;

#nullable disable

namespace VacancyWeb.Models
{
    public partial class StatusVacancy
    {
        public StatusVacancy()
        {
            VacancyRequests = new HashSet<VacancyRequest>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<VacancyRequest> VacancyRequests { get; set; }
    }
}
