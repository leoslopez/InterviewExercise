using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewExercise.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public string Title { get; set; }
        public string Technology { get; set; }
        public DateTime StartingDate { get; set; }
        public string RegistrationLink { get; set; }
    }
}