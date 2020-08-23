﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachingDb.Entities
{
    public class Subject : BaseEntity
    {
        public string Name { get; set; }
        public List<Student> Students { get; set; }
    }
}
