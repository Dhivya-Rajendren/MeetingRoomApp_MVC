using System.ComponentModel.DataAnnotations;

namespace MeetingRoomApp.Domain
{
    public class MeetingRoomType
    {
        [Key]
        public int RoomTypeId { get; set; }
        [Required(ErrorMessage ="Room Type cannot be Empty")]
        [StringLength(100)]
        public string RoomType { get; set; }
    }
}
