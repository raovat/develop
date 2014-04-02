using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Linq;
using System.Transactions;
using SysPro.Core.Repository;

namespace LibCore.Helper.Extensions
{
    public static class UnitOfWorkExtension
    {
        /// <summary>
        /// Saves the specified unit.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="unit">The unit.</param>
        /// <param name="entity">The entity.</param>
        /// <param name="schema">The schema.</param>
        /// <returns></returns>
        public static int SaveAndRollBack<T>(this UnitOfWork unit, T entity, string schema = "dbo") where T : class
        {
            var status = 0;
            using (var scope = new TransactionScope())
            {
                var type = typeof(T).Name;
                type = unit.Schema + "_" + type;
                IRepository<T> dbSetCurrent = unit.GetRepository<T>(type);
                try
                {
                    status = unit.Context.SaveChanges();
                }
                catch (Exception ex)
                {
                    if (dbSetCurrent != null)
                    {
                        ////Link ref: http://michaelsync.net/2012/06/26/tip-ef-codefirst-deleting-child-records
                        //dbSetCurrent.RemoveEntity(entity);
                        //var e = unit.Context.ChangeTracker.Entries();
                        ////unit.Context.ChangeTracker.DetectChanges();
                        //unit.Context.ChangeTracker.
                        //foreach (var dbEntityEntry in e)
                        //{
                        //    //dbEntityEntry.State = EntityState.Detached;
                        //    dbEntityEntry.State = EntityState.Unchanged;
                        //}

                        ////http://blog.oneunicorn.com/2011/04/03/rejecting-changes-to-entities-in-ef-4-1/
                        //var e = unit.Context.ChangeTracker.Entries();
                        //foreach (var dbEntityEntry in e)
                        //{
                        //    if (dbEntityEntry.State == EntityState.Modified)
                        //    {
                        //        dbEntityEntry.State = EntityState.Unchanged;
                        //    }
                        //    else if (dbEntityEntry.State == EntityState.Added)
                        //    {
                        //        dbEntityEntry.State = EntityState.Detached;
                        //    }
                        //}

                        var changedEntries = unit.Context.ChangeTracker.Entries().Where(x => x.State != EntityState.Unchanged).ToList();
                        foreach (var entry in changedEntries.Where(x => x.State == EntityState.Modified))
                        {
                            entry.CurrentValues.SetValues(entry.OriginalValues);
                            entry.State = EntityState.Unchanged;
                        }

                        foreach (var entry in changedEntries.Where(x => x.State == EntityState.Added))
                        {
                            entry.State = EntityState.Detached;
                        }

                        foreach (var entry in changedEntries.Where(x => x.State == EntityState.Deleted))
                        {
                            entry.State = EntityState.Unchanged;
                        }
                    }

                    Logging.Logging.PutError("DbEntityException Save Data: ", ex);
                }

                scope.Complete();
            }
            
            return status;
        }

        //public static void RejectChanges()
        //{
        //    var context = ((IObjectContextAdapter)this).ObjectContext;
        //    foreach (var change in this.ChangeTracker.Entries())
        //    {
        //        if (change.State == EntityState.Modified)
        //        {
        //            context.Refresh(RefreshMode.StoreWins, change.Entity);
        //        }
        //        if (change.State == EntityState.Added)
        //        {
        //            context.Detach(change.Entity);
        //        }
        //    }
        //}

        //public void RollBack()
        //{
        //    var context = DataContextFactory.GetDataContext();
        //    var changedEntries = context.ChangeTracker.Entries().Where(x => x.State != EntityState.Unchanged).ToList();

        //    foreach (var entry in changedEntries.Where(x => x.State == EntityState.Modified))
        //    {
        //        entry.CurrentValues.SetValues(entry.OriginalValues);
        //        entry.State = EntityState.Unchanged;
        //    }

        //    foreach (var entry in changedEntries.Where(x => x.State == EntityState.Added))
        //    {
        //        entry.State = EntityState.Detached;
        //    }

        //    foreach (var entry in changedEntries.Where(x => x.State == EntityState.Deleted))
        //    {
        //        entry.State = EntityState.Unchanged;
        //    }

        //}
    }
}
