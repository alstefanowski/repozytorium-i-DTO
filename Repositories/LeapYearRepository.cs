using Leap_Year.Data;
using Leap_Year.Interface;

namespace Leap_Year.Repositories
{
    public class LeapYearRepository : ILeapYearRepository
    {
        private readonly ApplicationDbContext _context;

        public LeapYearRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<LeapYear> GetActivePeople() 
        {
            return from s in _context.LeapYear select s;
            //return _context.LeapYear.Where(p => p.IsActive); //do zmiany
        }
    }
}
