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
        public static void UpdatePeriod(this Period Period, PeriodViewModel financailPeridVM)
        {
            Period.Number = financailPeridVM.Number;
            Period.Name = financailPeridVM.Name;
            Period.StartDate = financailPeridVM.StartDate;
            Period.EndDate = financailPeridVM.EndDate;
            Period.PeriodTransfered = financailPeridVM.PeriodTransfered;
            Period.TemporaryClose = financailPeridVM.TemporaryClose;
            Period.PermanentClose = financailPeridVM.PermanentClose;
        }
    }
}