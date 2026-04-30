using DesignPatternsDay.Context;
using DesignPatternsDay.Entities;
using DesignPatternsDay.Models;

namespace DesignPatternsDay.ChainOfResponsibility
{
    public class Treasurer : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            BankContext context = new BankContext();
            if(req.Amount<80000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.EmployeeName = "Veznedar - Burak Haşlak";
                customerProcess.Description = "Para Çekme İşlemi Onaylandı , Müşteriye Talep Ettiği Tutar Ödendi";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
            }
            else if (NextApprover != null)
            {
                CustomerProcess customerProcess= new CustomerProcess();
                customerProcess.Amount= req.Amount;
                customerProcess.CustomerName= req.CustomerName;
                customerProcess.EmployeeName = "Veznedar - Burak Haşlak";
                customerProcess.Description = "Para Çekme İşlemi Reddedildi , İşlem Şube Müdür Yardımcısına Yönlendirdi";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
                NextApprover.ProcessRequest(req);
            }
        }
    }
}
