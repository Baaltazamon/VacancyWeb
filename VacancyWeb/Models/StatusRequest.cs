using System;
using System.Collections.Generic;

#nullable disable

namespace VacancyWeb.Models
{
    public partial class StatusRequest
    {
        public StatusRequest()
        {
            Requests = new HashSet<Request>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Request> Requests { get; set; }
    }
}
