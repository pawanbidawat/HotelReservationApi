using System.ComponentModel.DataAnnotations;

namespace HotelApi.Models.DTO
{
    public class HotelDetailsModel
    {
        [Key]
        public int HotelId { get; set; }
        public string? HotelName { get; set; }
        public string? HotelAddress { get; set; }
        public string? HotelDescription { get; set; }
        public string? BlockedChildRange { get; set; }

        public string? HotelImage { get; set; }
        public decimal Rating { get; set; }
        public List<HotelRoomModel>? RoomDetails { get; set; }

    }
}
