using System;
using System.Collections.Generic;

#nullable disable

namespace ETreeks.CORE.Data
{
    public partial class User
    {
        public User()
        {
            Logins = new HashSet<Login>();
            Reservations = new HashSet<Reservation>();
            Testimonials = new HashSet<Testimonial>();
            Trainers = new HashSet<Trainer>();
        }

        public decimal Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Image { get; set; }

        public virtual ICollection<Login> Logins { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<Testimonial> Testimonials { get; set; }
        public virtual ICollection<Trainer> Trainers { get; set; }
    }
}
