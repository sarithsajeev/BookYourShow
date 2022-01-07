using BookYourShow.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourShow.Repository
{
    public interface ITicketsRepo
    {
        /// <summary>
        /// User must be able to view tickets for their reservation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<List<TicketViewModel>> ViewTickets(int id);
    }
}
