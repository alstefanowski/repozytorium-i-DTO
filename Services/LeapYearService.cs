using Leap_Year.Data;
using Leap_Year.Interface;
using Leap_Year.ViewModels.LeapYear;
using System.Security.Claims;

namespace Leap_Year.Services
{
    public class LeapYearService: ILeapYearInterface
    {
        private readonly ILeapYearRepository _leapYearRepository;
        public LeapYear LeapYear { get; set; } = default!;
        public LeapYearService(ILeapYearRepository leapYearRepository)
        {
            _leapYearRepository = leapYearRepository;
        }
        public ListLeapYearForListVM GetActivePeopleForList()
        {
            var people = _leapYearRepository.GetActivePeople();
            ListLeapYearForListVM listLeapYearForListVM = new ListLeapYearForListVM();
            listLeapYearForListVM.LeapYear = new List<LeapYearForListVM>(); //.LeapYear?
            foreach(var person in people)
            {
                var pVM = new LeapYearForListVM()
                {
                    Id = person.ID,
                    Name = person.Name,
                    FullResult = person.Result,
                    SearchTime = person.SearchTime
                };
                listLeapYearForListVM.LeapYear.Add(pVM);
            }
            listLeapYearForListVM.Count = listLeapYearForListVM.LeapYear.Count;
            return listLeapYearForListVM;
        }
        public string GetLeapYearInfo()
        {
            if ((LeapYear.Year % 400 == 0))
            {
                LeapYear.Result = "Rok przystepny";
                return LeapYear.Result;
            }
            else if (LeapYear.Year % 100 == 0)
            {
                LeapYear.Result = "Rok nie jest przystepny";
                return LeapYear.Result;
            }

            else if (LeapYear.Year % 4 == 0)
            {
                LeapYear.Result = "Rok przystepny";
                return LeapYear.Result;
            }
            else
            {
                LeapYear.Result = "Rok nie jest przystepny";
                return LeapYear.Result;
            }
        }
    }
}
