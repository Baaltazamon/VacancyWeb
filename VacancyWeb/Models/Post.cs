using System;
using System.Collections.Generic;

#nullable disable

namespace VacancyWeb.Models
{
    public partial class Post
    {
        public Post()
        {
            staff = new HashSet<staff>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<staff> staff { get; set; }
    }
}
