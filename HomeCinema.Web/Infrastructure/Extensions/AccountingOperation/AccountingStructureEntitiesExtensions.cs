using HomeCinema.Entities;
using HomeCinema.Web.Models;

namespace HomeCinema.Web.Infrastructure.Extensions.AccountingOperation
{
    public static class AccountingStructureEntitiesExtensions
    {
        public static void UpdateAccount(this Account account, AccountViewModel accountVM)
        {
            account.Code = accountVM.Code;
            account.Name = accountVM.Name;
        }
        public static void UpdateFinancialPeriod(this FinancialPeriod financialPeriod, FinancialPeriodViewModel financailPeridVM)
        {
            financialPeriod.Number = financailPeridVM.Number;
            financialPeriod.Name = financailPeridVM.Name;
            financialPeriod.StartDate = financailPeridVM.StartDate;
            financialPeriod.EndDate = financailPeridVM.EndDate;
            financialPeriod.FinanciaPeriodTransfered = financailPeridVM.FinanciaPeriodTransfered;
            financialPeriod.TemporaryClose = financailPeridVM.TemporaryClose;
            financialPeriod.PermanentClose = financailPeridVM.PermanentClose;
        }
    }
}