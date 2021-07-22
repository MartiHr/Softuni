using System.Collections.Generic;

namespace P03.DetailPrinter
{
    public class DetailsPrinter
    {
        private IList<IEmployee> employees;

        public DetailsPrinter(IList<IEmployee> employees)
        {
            this.employees = employees; 
        }

        public void PrintDetails()
        {
            foreach (Employee employee in employees)
            {
                employee.PrintInformatin();
            }
        }
    }
}
