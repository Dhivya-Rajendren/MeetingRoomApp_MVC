using System;

namespace MeetingRoomApp.Domain
{
    public class Meeting
    {
        public int MeetingId { get; set; }
        public int RoomNo { get; set; }
        public DateTime MeetingDateTime { get; set; }
        public string Remarks { get; set; }
    }
}
