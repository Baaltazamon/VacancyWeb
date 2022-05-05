using System;
using System.Collections.Generic;

#nullable disable

namespace VacancyWeb.Models
{
    public partial class Duty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int VacancyId { get; set; }

        public virtual VacancyRequest Vacancy { get; set; }
    }
}
