using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetingRoomApp.Domain
{
    public class MeetingRoom
    {
        [Key]
        public int RoomNo { get; set; }
        [Required]
        [StringLength(200)]
        public string RoomName { get; set; }
        [Required]
        public int RoomTypeId { get; set; }
        [Column(TypeName ="Varchar")]
        [StringLength(50)]
        public string Location { get; set; }
    }
}
