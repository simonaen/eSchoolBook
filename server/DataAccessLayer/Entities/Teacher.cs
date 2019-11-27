﻿using System.Collections.Generic;

namespace SchoolBook.DataAccessLayer.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public ICollection<Subject> Subjects { get; set; }
        public User User { get; set; }
    }
}