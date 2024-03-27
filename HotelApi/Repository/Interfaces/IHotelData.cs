using HotelApi.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Repository.Interfaces
{
    public interface IHotelData
    {
        List<HotelDetailsModel> GetAllHotels();
        HotelDetailsModel GetHotelsDetailsById(int id);
        List<HotelRoomModel> GetRoomsByHotelId(int Id);
        HotelRoomModel GetRoomDetailsByRoomId(int id);
        bool DeleteRoomById(int id);
        bool AddHoteldetails(HotelDetailsModel hotelDetails);
        bool RemoveHotel(int id);
        bool AddRoomDetails(HotelRoomModel room);
        bool EditRoomDetails(int id, HotelRoomModel model);
        List<RoomDateRangeModel> GetRoomDateRange(int id);
        RoomDateRangeModel GetRoomDateRangeByDateRangeId(int id);
        bool AddRoomDateRange(RoomDateRangeModel model);
        bool DeleteRoomPriceByDateRangeId(int id);
        bool UpdateRoomDateRange(RoomDateRangeModel model);
        bool UpdateHotelDetails(int id,HotelDetailsModel hotelDetails);

        Task<bool> AddBlackoutDates(int roomId, [FromBody] List<DateTime> dates);
        List<BlackoutDateModel> getblackoutdates(int roomid);
        IQueryable<HotelDetailsModel> GetHotelSearchResult(string searchValue);
        //IQueryable<HotelRoomModel> GetHotelAndRoomByDate(HotelRoomModel model);
        IQueryable<HotelRoomModel> GetHotelAndRoomByDate(HotelFilterModel filter);
    }
}
