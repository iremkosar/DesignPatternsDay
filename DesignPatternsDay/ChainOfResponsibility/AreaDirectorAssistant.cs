using DesignPatternsDay.Context;
using DesignPatternsDay.Entities;
using DesignPatternsDay.Models;

namespace DesignPatternsDay.ChainOfResponsibility
{
    public class AreaDirectorAssistant : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            BankContext context = new BankContext();
            if (req.Amount <= 420000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.EmployeeName = "Bölge Müdür Yardımcısı : Kübra Tunçay";
                customerProcess.Description = "Para Çekme İşlemi Onaylandı , Müşteriye Talep Ettiği Tutar Ödendi";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
            }
            else
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.EmployeeName = "Bölge Müdür Yardımcısı : Kübra Tunçay";
                customerProcess.Description = "Para Çekme İşlemi Reddedildi, İşlem Bölge Müdürüne Yönlendirildi";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
            }
        }
    }
}
