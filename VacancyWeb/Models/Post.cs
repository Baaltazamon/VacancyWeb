using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Required(AllowEmptyStrings = false,ErrorMessage = "Обязательное поле")]
        public string Name { get; set; }

        public virtual ICollection<staff> staff { get; set; }
    }
}
