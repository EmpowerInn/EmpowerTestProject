namespace LabCorp
{
    public class Employee
    {

        public void TakeVacation(float vacationRequest)
        {
           
            var maxAllow = GetMaxVacationAllow();

            if (vacationRequest > maxAllow)
            {
                throw new System.ArgumentException($"Cannot exceed the number of vacation days available");
            }

            var result = VacationDays - vacationRequest;

            if (result < 0)
            {
                throw new System.ArgumentException($"Cannot exceed the number of vacation days available");

            }

            VacationDays = result;

        }

 
        public const int MaxEmployeeLaborDays = 260;
        public float VacationDays { get; set; } = 0;
        internal int EmployeeLaborDays { get; set; } = 0;
        public SalaryType SalaryType { get; set; } = SalaryType.Hourly;
        
        internal int GetMaxVacationAllow()
        {
            int maxAllow = 0;

            switch (SalaryType)
            {
                case SalaryType.Hourly:
                    maxAllow = 10;
                    break;
                case SalaryType.Employee:
                    maxAllow = 15;
                    break;
                case SalaryType.Manager:
                    maxAllow = 30;
                    break;

            }

            return maxAllow;
        }
        public void Work(int numberOfDays)
        {
            var maxAllow = GetMaxVacationAllow();

            if (numberOfDays > maxAllow)
            {

                throw new ArgumentException($"Vacation cannot be greater than {maxAllow}");

            }


            if ((EmployeeLaborDays + numberOfDays) > Employee.MaxEmployeeLaborDays)
            {
                throw new ArgumentException($"Employee cannot exceed the maximum days accepted by the company that is 260 ");
            }

            EmployeeLaborDays += numberOfDays;

            float _vacationDays = 0;
         


            //qualify for full vacation since already have a year
            if (Employee.MaxEmployeeLaborDays - EmployeeLaborDays == 0)
            {

                _vacationDays = maxAllow - VacationDays;
                

            }
            else if (Employee.MaxEmployeeLaborDays / EmployeeLaborDays >= 2)
            {
                var qualify = (maxAllow / 2);
                _vacationDays = qualify - VacationDays;
            }

            if (_vacationDays > maxAllow)
            {
                throw new ArgumentException($"Accumulate vacation days cannot be greather than {maxAllow}");
            }

            

            VacationDays += _vacationDays;
        }

    }
}
