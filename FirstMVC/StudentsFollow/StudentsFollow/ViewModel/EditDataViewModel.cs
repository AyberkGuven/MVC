using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsFollow.ViewModel
{
    public class EditDataViewModel
    {
        public EditStudentViewModel EditStudentViewModel { get; set; }
        public List<ClassRoomViewModel> ClassRoomViewModel { get; set; }
    }
}