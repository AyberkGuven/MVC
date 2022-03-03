using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentsFollow.Models
{
    public class Student
    {
       
        [Key]
        [StringLength(11)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool Gender { get; set; }
        public string ImagePatch { get; set; }
        public byte ClassroomId { get; set; }
        public Classroom Classroom { get; set; }

    }
}