using HotelApi.Models.DTO;
using HotelApi.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelApiController : ControllerBase
    {
        private readonly IHotelData _hotelData;
        public HotelApiController(IHotelData hotelData)
        {
            _hotelData = hotelData;
        }
        //getting hotels details
        [HttpGet("GetAllHotelsDetails")]
        public List<HotelDetailsModel> GetAllHotels()
        {
            var data = _hotelData.GetAllHotels();
            return data;
        }

        //getting searchResult
        [HttpGet("GetHotelSearchResult")]

        public async Task<List<HotelDetailsModel>> GetHotelSearchResult(string searchValue)
        {
            var query = _hotelData.GetHotelSearchResult(searchValue);
            var results = await query.ToListAsync();
            return results;
        }

 
        //getting hotel and room details by dates
        [HttpPost("GetHotelAndRoomByDate")]
        public async Task<List<HotelRoomModel>> GetHotelAndRoomByDate([FromBody] HotelFilterModel model)
        {
            var query = _hotelData.GetHotelAndRoomByDate(model);
            var results = await query.ToListAsync();
            return results;
        }




        //getting hotel details by id
        [HttpGet("GetHotelsDetailsById")]
        public HotelDetailsModel GetHotelsDetailsById(int id)
        {
            var data = _hotelData.GetHotelsDetailsById(id);
            return data;
        }


        //adding hotels details
        [HttpPost("AddHotelDetails")]
        public bool AddHotelDetails([FromBody] HotelDetailsModel hotel)
        {
            var data = _hotelData.AddHoteldetails(hotel);
            return data;
        }
        //Edit method for Hotel
        [HttpPut("EditHotelDetail")]
        public bool EditHotelDetail(int id, HotelDetailsModel hotelDetails)
        {
            var data = _hotelData.UpdateHotelDetails(id, hotelDetails);
            return data;
        }

        //Detete Hotel
        [HttpDelete("RemoveHotel")]
        public bool RemoveHotel(int id)
        {
            var data = _hotelData.RemoveHotel(id);
            return data;
        }


        //getting room date range data using roomid
        [HttpGet("GetRoomDateRange")]
        public List<RoomDateRangeModel> GetRoomDateRange(int id)
        {
            var data =  _hotelData.GetRoomDateRange(id);
            return data;
        }

        //getting room date range price details using daterangeId
        [HttpGet("GetRoomDateRangeByDateRangeId")]
        public RoomDateRangeModel GetRoomDateRangeByDateRangeId(int id)
        {
            var data = _hotelData.GetRoomDateRangeByDateRangeId(id);
            return data;
        }

        //adding room date range details
        [HttpPost("AddRoomDateRange")]
        public bool AddRoomDateRange(RoomDateRangeModel model)
        {
            var data = _hotelData.AddRoomDateRange(model);
            return data;
        }


        //updating room date range details
        [HttpPut("UpdateRoomDateRangeByDateRangeId")]
        public bool UpdateRoomDateRange(RoomDateRangeModel model)
        {
            var data = _hotelData.UpdateRoomDateRange(model);
            return data;
        }

        //adding rooms details
        [HttpPost("AddRoomDetails")]
        public bool AddRoomDetails([FromBody] HotelRoomModel room)
        {
            var data = _hotelData.AddRoomDetails(room);
            return data;
        }

        //delete room price details by daterangeId
        [HttpDelete("DeleteRoomPriceByDateRangeId")]
        public bool DeleteRoomPriceByDateRangeId(int id)
        {
            var data = _hotelData.DeleteRoomPriceByDateRangeId(id);
            return data;
        }

        //Edit Room Details
        [HttpPut("EditRoomByRoomId")]
        public bool EditRoomDetails(int id, HotelRoomModel model)
        {
            var data = _hotelData.EditRoomDetails(id, model);
            return data;
        }


        //getting room details with hotel id
        [HttpGet("GetRoomDetailsByHotelId")]
        public List<HotelRoomModel> GetRoomsByHotelId(int Id)
        {
            var data = _hotelData.GetRoomsByHotelId(Id);
            return data;
        }

        //getting room detail by roomid
        [HttpGet("GetRoomDetailsByRoomId")]
        public HotelRoomModel GetRoomDetailsByRoomId(int id)
        {
            var data = _hotelData.GetRoomDetailsByRoomId(id);
            return data;
        }

        //deleting room
        [HttpDelete("DeleteRoomById")]
        public bool DeleteRoomById(int id) {
            var data = _hotelData.DeleteRoomById(id);
            return data;
        }

        //blackoutdate api
        [HttpPost("Addblackout-dates")]
        public async Task<IActionResult> AddBlackoutDates(int roomId, [FromBody] List<DateTime> dates)
        {
           var data =  await _hotelData.AddBlackoutDates(roomId,dates);
           return Ok(data);
        }

        [HttpGet("getblackoutdatesbyroomid")]
        public List<BlackoutDateModel> getblackoutdates(int roomid)
        {
            var data = _hotelData.getblackoutdates(roomid);
            return data;
        }



    }
}
