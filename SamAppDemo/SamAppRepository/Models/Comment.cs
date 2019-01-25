using System;

namespace SamAppRepository.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public Person Person { get; set; }

        public string Content { get; set; }

        public DateTime DateTimeOfPosting { get; set; }

        public DateTime DateTimeOfModify { get; set; }

        public string DateTimeOfPostingString => ReservationSystemHelper.GetFormattedDateString(DateTimeOfPosting);

        public string DateTimeOfModifyString => ReservationSystemHelper.GetFormattedDateString(DateTimeOfModify);
    }
}
