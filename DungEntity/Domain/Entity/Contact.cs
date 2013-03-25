using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entity
{
    public class Contact
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime Birthday { get; set; }

        public int GroupId { get; set; }

        public Group Group { get; set; }
    }
}
