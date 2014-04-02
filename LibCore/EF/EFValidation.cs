using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using LibCore.Helper.Logging;

namespace SysPro.Core.EF
{
    public class EFValidation
    {
        public static void LogValidationErrors(DbEntityValidationException ex)
        {
            foreach (var eve in ex.EntityValidationErrors)
            {
                var s = string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                    eve.Entry.Entity.GetType().Name, eve.Entry.State);
                //Logging.PushString(s);
                s = eve.ValidationErrors.Aggregate(s, (current, ve) => current + string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                Logging.PutError("DbEntityValidationException EFValidation: " + s, ex);
            }
        }
    }
}
