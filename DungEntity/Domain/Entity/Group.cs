using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entity
{
    public class Group
    {
        public int Id { get; set; }

        [MaxLength(200)]
        public string Title { get; set; }

        public string Description { get; set; }

        public int NumberOfContact { get; set; }

        public virtual List<Contact> Contacts { get; set; }
    }
}
