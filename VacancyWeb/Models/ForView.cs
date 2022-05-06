using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VacancyWeb.Models
{
    public class ForView
    {
        public List<VacancyRequest> ListVacancyRequests { get; set; }
        public List<Condition> ListConditions { get; set; }
        public List<Duty> ListDuties { get; set; }
        public List<TimeTable> ListTimeTables { get; set; }
        public List<Requirement> ListRequirements { get; set; }
        public List<TypeOfEmployment> ListTypeOfEmployments { get; set; }
        public List<TypeVacancy> ListTypeVacancies { get; set; }
        public List<staff> ListsStaves { get; set; }
        public List<Request> ListRequests { get; set; }
    }
    public class ForViewSingle
    {
        public VacancyRequest VacancyRequests { get; set; }
        public List<Condition> ListConditions { get; set; }
        public List<Duty> ListDuties { get; set; }
        public TimeTable TimeTables { get; set; }
        public List<Requirement> ListRequirements { get; set; }
        public TypeOfEmployment TypeOfEmployments { get; set; }
        public TypeVacancy TypeVacancies { get; set; }
        public staff Staves { get; set; }
    }
}
