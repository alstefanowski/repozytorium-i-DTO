using Leap_Year.Data;
using Leap_Year.ViewModels.LeapYear;

namespace Leap_Year.Interface
{
    public interface ILeapYearInterface
    {
        public ListLeapYearForListVM GetActivePeopleForList();
        public string GetLeapYearInfo();
    }
}
