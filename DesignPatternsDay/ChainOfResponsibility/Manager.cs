using DesignPatternsDay.Context;
using DesignPatternsDay.Entities;
using DesignPatternsDay.Models;

namespace DesignPatternsDay.ChainOfResponsibility
{
    public class Manager : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            BankContext context = new BankContext();
            if (req.Amount <= 350000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.EmployeeName = "Şube Müdürü : Furkan Türker";
                customerProcess.Description = "Para Çekme İşlemi Onaylandı , Müşteriye Talep Ettiği Tutar Ödendi";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
            }
            else if (NextApprover != null)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.EmployeeName = "Şube Müdürü : Furkan Türker";
                customerProcess.Description = "Para Çekme İşlemi Reddedildi, işlem Bölge Müdür Yardımcısına Yönlendirildi";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
                NextApprover.ProcessRequest(req);
            }
        }
    }
}
