﻿using System.Collections.Generic;

namespace SchoolBook.DataAccessLayer.Entities
{
    public class Teacher
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }

        public string Pin { get; set; }

        public string Address { get; set; }

        public string Town { get; set; }

        public ICollection<TeacherToSubject> Subjects { get; set; }

        public User User { get; set; }
    }
}
