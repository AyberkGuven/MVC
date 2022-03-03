using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsFollow.ViewModel
{
    public class CreatStudentViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool Genders { get; set; }
        public byte ClassRoomId { get; set; }
    }
}