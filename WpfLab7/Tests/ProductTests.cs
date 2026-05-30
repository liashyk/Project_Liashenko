using System.Linq;
using Core;

namespace WpfLab7.Tests
{
    public class MovieViewModelTests
    {
        public void FilterByTitle_Finds_Items()
        {
            var vm = new MainViewModel();
            vm.Movies.Clear();
            vm.Movies.Add(new Movie { Title = "Початок" });
            vm.Movies.Add(new Movie { Title = "Темний лицар" });

            var res = vm.FilterByTitle("поч").ToList();
            if (res.Count != 1) throw new System.Exception("FilterByTitle failed");
        }

        public void TotalBudget_Calculates()
        {
            var vm = new MainViewModel();
            vm.Movies.Clear();
            vm.Movies.Add(new Movie { Budget = 100 });
            vm.Movies.Add(new Movie { Budget = 200 });
            if (vm.TotalBudget() != 300) throw new System.Exception("TotalBudget incorrect");
        }
    }
}
