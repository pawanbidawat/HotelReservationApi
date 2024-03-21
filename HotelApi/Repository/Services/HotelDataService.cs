using HotelApi.Models.DTO;
using HotelApi.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Repository.Services
{
    public class HotelDataService : IHotelData
    {
        private readonly DatabaseContext _context;
        public HotelDataService(DatabaseContext context)
        {
            _context = context;
        }


        public List<HotelDetailsModel> GetAllHotels()
        {
            var data = _context.HotelDetails.Include(x=>x.RoomDetails).ToList();
            return data;
        }

        //Get hotel details by Hotel name 
        public IQueryable<HotelDetailsModel> GetHotelSearchResult(string searchValue)
        {
            var query = _context.HotelDetails.AsQueryable();
            if (!string.IsNullOrEmpty(searchValue))
            {                                                      
                query = query.Where(s => s.HotelName.Contains(searchValue)                
                                   || s.HotelAddress.Contains(searchValue));
            }
            return query;
        }
      
        public IQueryable<HotelRoomModel> GetHotelAndRoomByDate(HotelFilterModel filter)
        {
            var query = _context.HotelRooms
                                .Include(hotelRoom => hotelRoom.Hotel)
                                .AsQueryable();
           
            query = query.Where(x => (x.DateFrom <= filter.DateTo && x.DateTo >= filter.DateFrom));
            

            return query;
        }

        //service for GetHotelsDetailsById
        public HotelDetailsModel GetHotelsDetailsById(int id)
        {
            var data = _context.HotelDetails.FirstOrDefault(x => x.HotelId == id);

            return data;
        }


        //service for adding hotel details
        public bool AddHoteldetails(HotelDetailsModel hotelDetails)
        {
            _context.HotelDetails.Add(hotelDetails);

            int data = _context.SaveChanges();

            return data > 0;
        }
        //removing hotel
        public bool RemoveHotel(int id)
        {
            var data = _context.HotelDetails.Include(h => h.RoomDetails).FirstOrDefault(x => x.HotelId == id);
            if (data != null)
            {
                _context.HotelDetails.Remove(data);
                _context.SaveChanges();
                return true;

            }
            return false;
        }

        //adding service for adding room details
        public bool AddRoomDetails(HotelRoomModel room)
        {
            _context.HotelRooms.Add(room);
            int data = _context.SaveChanges();
            return data > 0;
        }

        //service for updating room details
        public bool EditRoomDetails(int id, HotelRoomModel model)
        {

            if (id > 0)
            {
                var data = _context.HotelRooms.FirstOrDefault(x => x.RoomId == id);
                if (data != null)
                {

                    data.RoomImage = model.RoomImage;
                    data.TripleRate = model.TripleRate;
                    data.ExceptionCase = model.ExceptionCase;                   
                    data.DateFrom = model.DateFrom;
                    data.DateTo = model.DateTo;
                    data.ChildRate = model.ChildRate;
                    data.AdultRate = model.AdultRate;
                    data.SingleRate = model.SingleRate;
                    data.DoubleRate = model.DoubleRate;
                    data.NoChild = model.NoChild;
                    data.SingleEqualDouble = model.SingleEqualDouble;
                    data.NoExtraAdult = model.NoExtraAdult;

                    int response = _context.SaveChanges();
                    return response > 0;
                }
            }

            return false;
        }

        //service for showing rooms with hotel id
        public List<HotelRoomModel> GetRoomsByHotelId(int Id)
        {
            var data = _context.HotelRooms.Include(x=>x.Hotel).Where(x => x.Hotel.HotelId == Id).ToList();
            return data;
        }

        //getting room detail by id 
        public HotelRoomModel GetRoomDetailsByRoomId(int id)
        {
            var data = _context.HotelRooms.FirstOrDefault(x => x.RoomId == id);
            return data;
        }

        //deleting room 
        public bool DeleteRoomById(int id)
        {
            var data = GetRoomDetailsByRoomId(id);
            if (data != null)
            {
                _context.HotelRooms.Remove(data);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        //service for updating hotel details
        public bool UpdateHotelDetails(int id, HotelDetailsModel hotelDetails)
        {

            if (id > 0)
            {
                var data = _context.HotelDetails.FirstOrDefault(x => x.HotelId == id);
                if (data != null)
                {
                    data.HotelName = hotelDetails.HotelName;
                    data.HotelAddress = hotelDetails.HotelAddress;
                    data.HotelImage = hotelDetails.HotelImage;
                    data.Rating = hotelDetails.Rating;
                    data.HotelDescription = hotelDetails.HotelDescription;
                    data.BlockedChildRange = hotelDetails.BlockedChildRange;

                    int response = _context.SaveChanges();
                    return response > 0;
                }
            }

            return false;
        }

        public async Task<bool> AddBlackoutDates(int roomId, [FromBody] List<DateTime> dates)
        {
           
            try
            {
                foreach (var date in dates)
                {
                    var blackoutDate = new BlackoutDateModel { RoomId = roomId, Date = date };
                    _context.BlackoutDate.Add(blackoutDate);
                
                }
                int data = await _context.SaveChangesAsync();
                return data > 0;
            }
            catch (Exception ex)
            {          
                Console.WriteLine(ex.ToString());
                return false;
            }
        }


        //service for getting blackout dates
        public List<BlackoutDateModel> getblackoutdates(int roomid) 
        {
            var data = _context.BlackoutDate.Where(x=>x.RoomId==roomid).ToList();
            return data;
        }

        
    }
}
