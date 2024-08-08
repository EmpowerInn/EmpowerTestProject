using LabCorp;
using System;
using Xunit;

namespace TestLabCorpEmployee
{
    
    public class EmployeeTest
    {
        Employee? employee;

        [Fact]
        public void EmployeeIsNull() => Assert.Null(employee);

        [Fact]
        public void EmployeeIsHourly()
        {
            employee = new();
            employee.SalaryType = SalaryType.Hourly;
            Assert.Equal(SalaryType.Hourly, employee.SalaryType);

        }


        [Fact]
        public void EmployeeHourly10daysQualifyFullVacation()
        {
            employee = new();
            employee.SalaryType = SalaryType.Hourly;
            
            var exceptionType = typeof(ArgumentException);
            string message = "Vacation cannot be greater than 10";
            var ex =
             Assert.Throws(exceptionType, () => {
                 employee.Work(240);
             });
            Assert.NotNull(ex);
            Assert.IsType(exceptionType, ex);
            Assert.Equal(message, ex.Message);


        }


        [Fact]
        public void EmployeeSalarydaysQualifyFullVacation()
        {
            employee = new();
            employee.SalaryType = SalaryType.Employee;

            string managerMessage = "Vacation cannot be greater than 15";
            var exceptionType = typeof(ArgumentException);

            var ex =
             Assert.Throws(exceptionType, () => {
                 employee.Work(240);
             });
            Assert.NotNull(ex);
            Assert.IsType(exceptionType, ex);
            Assert.Equal(managerMessage, ex.Message);

        }


        [Fact]
        public void EmployeeManagerSalarydaysQualifyFullVacation()
        {
            string managerMessage = "Vacation cannot be greater than 30";

            employee = new();
            employee.SalaryType = SalaryType.Manager;
            
            var exceptionType = typeof(ArgumentException);
            
            var ex =
             Assert.Throws(exceptionType, () => {
                 employee.Work(240);
             });
            Assert.NotNull(ex);
            Assert.IsType(exceptionType, ex);
            Assert.Equal(managerMessage, ex.Message);
        }



        [Fact]
        public void EmployeeArgumentException()
        {
            employee = new();
            employee.SalaryType = SalaryType.Employee;
            string employeeMessage = "Vacation cannot be greater than 15";

            // Arrange
            var exceptionType = typeof(ArgumentException);
         
            var ex =
             Assert.Throws(exceptionType, () => {
                 employee.Work(240);
             });
            Assert.NotNull(ex);
            Assert.IsType(exceptionType, ex);
            Assert.Equal(employeeMessage, ex.Message);

        }


        [Fact]
        public void EmployeeArgumentExceptionWithExpectedMessageForManager()
        {
            employee = new();
            employee.SalaryType = SalaryType.Manager;
            var expectedMessage = "Vacation cannot be greater than 30";

            // Arrange
            var exceptionType = typeof(ArgumentException);
            // Act and Assert
            var ex = Assert.Throws(exceptionType, () => {
                employee.Work(889);
            });

            Assert.NotNull(ex);
            Assert.IsType(exceptionType, ex);
            Assert.Equal(expectedMessage, ex.Message);

        }



        [Fact]
        public void EmployeeArgumentExceptionWithExpectedMessageForEmployeeSalary()
        {
            employee = new();
            employee.SalaryType = SalaryType.Employee;
            var expectedMessage = "Vacation cannot be greater than 15";

            // Arrange
            var exceptionType = typeof(ArgumentException);
            // Act and Assert
            var ex = Assert.Throws(exceptionType, () => {
                employee.Work(889);
            });

            Assert.NotNull(ex);
            Assert.IsType(exceptionType, ex);
            Assert.Equal(expectedMessage, ex.Message);

        }


        [Fact]
        public void EmployeeVacationArgumentExceptionWithExpectedMessageForEmployeeSalary()
        {
            employee = new();
            employee.SalaryType = SalaryType.Employee;
            var expectedMessage = "Cannot exceed the number of vacation days available";

            // Arrange
            var exceptionType = typeof(ArgumentException);
            // Act and Assert
            var ex = Assert.Throws(exceptionType, () => {
                employee.TakeVacation(889);
            });

            Assert.NotNull(ex);
            Assert.IsType(exceptionType, ex);
            Assert.Equal(expectedMessage, ex.Message);

        }

        

        [Fact]
        public void EmployeeArgumentExceptionWithExpectedMessageForEmployeeHourly()
        {
            employee = new();
            employee.SalaryType = SalaryType.Hourly;
            var expectedMessage = "Vacation cannot be greater than 10";

            // Arrange
            var exceptionType = typeof(ArgumentException);
            // Act and Assert
            var ex = Assert.Throws(exceptionType, () => {
                employee.Work(889);
            });

            Assert.NotNull(ex);
            Assert.IsType(exceptionType, ex);
            Assert.Equal(expectedMessage, ex.Message);
        }
    }

}
