using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HotelApi.Models.DTO
{
    public class BlackoutDateModel
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }       
        public int RoomId { get; set; }

        [ForeignKey(nameof(RoomId))]
        public HotelRoomModel? RoomModel { get; set; } 
       
      
    }
}
