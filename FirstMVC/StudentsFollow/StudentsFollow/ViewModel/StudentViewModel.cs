using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsFollow.ViewModel
{
    public class StudentViewModel
    {
        public string ImagePatch { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Genders { get; set; }
        public string ClassRoomId { get; set; }
    }
}