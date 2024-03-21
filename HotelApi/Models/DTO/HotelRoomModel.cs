﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HotelApi.Models.DTO
{
    public class HotelRoomModel
    {
        [Key]
        public int RoomId { get; set; }
        public int HotelId { get; set; }
        public string? RoomType { get; set; }
        public string? Description {  get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }       
        public string? RoomImage { get; set; }
        public decimal SingleRate { get; set; }
        public decimal DoubleRate { get; set; }
        public decimal TripleRate { get; set; }
        public decimal AdultRate { get; set; }
        public decimal ChildRate { get; set; }

        public bool SingleEqualDouble { get; set; }
        public bool ExceptionCase { get; set; }
        public bool NoExtraAdult { get; set; }
        public bool NoChild { get; set; }

        // Foreign key for Hotel    

        //[JsonIgnore]
        public HotelDetailsModel? Hotel { get; set; }

       
        public  List<BlackoutDateModel>? BlackoutDates { get; set; }
    }
}