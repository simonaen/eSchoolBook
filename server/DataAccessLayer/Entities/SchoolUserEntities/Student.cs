﻿using System.Collections.Generic;

namespace SchoolBook.DataAccessLayer.Entities.SchoolUserEntities
{
    public class Student : SchoolUser
    {
        public int StartYear { get; set; }

        public School School { get; set; }

        public Class Class { get; set; }

        public ICollection<StudentToGrade> Grades { get; set; }

        public ICollection<Absence> Absences { get; set; }
    }
}