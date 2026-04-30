using DesignPatternsDay.Models;

namespace DesignPatternsDay.ChainOfResponsibility
{
    public abstract class Employee
    {
        protected Employee NextApprover;
        public void SetNextApprover(Employee employee)
        {
            this.NextApprover = employee;
        }
        public abstract void ProcessRequest(CustomerProcessViewModel req);
    }
}
