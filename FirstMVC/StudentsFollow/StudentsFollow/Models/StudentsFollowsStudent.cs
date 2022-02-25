using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentsFollow.Models
{
    public class StudentsFollowsStudent
    {
        public string ImagePatch { get; set; }
        [Key]
        [StringLength(11)]
        public string TC { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool Gender { get; set; }

        public byte Id { get; set; }
        public StudentsFollowsclassRoom StudentsFollowsclassRooms { get; set; }

    }
}