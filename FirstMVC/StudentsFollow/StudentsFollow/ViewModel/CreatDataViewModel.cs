using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsFollow.ViewModel
{
    public class CreatDataViewModel
    {
        public CreatStudentViewModel CreatStudentViewModels { get; set; }
        public List<ClassRoomViewModel> classRoomViewModels { get; set; }
    }
}