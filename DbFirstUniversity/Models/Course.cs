﻿using System;
using System.Collections.Generic;

namespace DbFirstUniversity.Models
{
    //Heloo
    public partial class Course
    {
        public Course()
        {
            Enrollment = new HashSet<Enrollment>();
        }

        public int CourseId { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        public ICollection<Enrollment> Enrollment { get; set; }
    }
}
