using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospiceNiagara.Models.ViewModels
{
    public class ScheduleViewModel
    {
        public List<AnnouncementViewModel> Announcements { get; set; }
        public List<MeetingsViewModel> Meetings { get; set; }

    }
}