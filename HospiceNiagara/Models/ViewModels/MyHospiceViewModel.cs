using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospiceNiagara.Models.ViewModels
{
    public class MyHospiceViewModel
    {
        //Announcement
        public List<AnnounceFile> AnnounceFileViewModel { get; set; }
        public List<Announcement> AnnouncementViewModel { get; set; }
        public List<AnnouncePrivacy> AnnouncePrivaryViewModel { get; set; }

        //Death Notices
        public List<Death> DeathViewModel { get; set; }
        public List<DeathPrivacy> DeathPrivacyViewModel { get; set; }

        //Events
        public List<Event> EventViewModel { get; set; }
        public List<EventPrivacy> EventPrivacyViewModel { get; set; }
        public List<EventResource> EventResourcesViewModel { get; set; }

        //Meeting
        public List<Meeting> MeetingViewModel { get; set; }
        public List<MeetingPrivacy> MeetingPrivaryViewModel { get; set; }
        public List<MeetingResource> MeetingResourceViewModel { get; set; }


    }
}