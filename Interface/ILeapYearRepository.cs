using Leap_Year.Data;

namespace Leap_Year.Interface
{
    public interface ILeapYearRepository
    {
        public IQueryable<LeapYear> GetActivePeople();
    }
}
