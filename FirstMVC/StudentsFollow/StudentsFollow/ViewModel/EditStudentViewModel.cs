using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsFollow.ViewModel
{
    public class EditStudentViewModel
    {
        public string ImagePatch { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool Gender { get; set; }
        public byte ClassRoomId { get; set; }
    }
}