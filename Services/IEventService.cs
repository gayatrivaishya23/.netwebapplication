using MovieEventBooking.Models;
using System.Collections.Generic;

namespace MovieEventBooking.Services
{
    public interface IEventService
    {
        List<EventModel> GetAll();
        EventModel? GetById(int id);
    }
}
