﻿using BookYourShow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourShow.Repository
{
   public interface ISeatRepository
    {
        //get all seats
        Task<List<Seats>> GetSeats(int tId);

        //get seat by Id
        Task<Seats> GetSeatById(int Id,int tId);

        //add a new seat
        Task<int> AddSeat(Seats seat, int tId);

        //update seat
        Task UpdateSeat(Seats seat, int tId);

       
    }
}
