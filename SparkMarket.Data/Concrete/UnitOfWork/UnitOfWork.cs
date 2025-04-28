using SparkMarket.Data.Abstract;
using SparkMarket.Data.Concrete.EntityFramework.context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkMarket.Data.Concrete.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {


        SparkMarketDbContext _ctx;
        public UnitOfWork(SparkMarketDbContext ctx,IBankaRepositoryUOW _Bankas)
        {
            _ctx = ctx; 
            Bankas=_Bankas; 
        }

        public IBankaRepositoryUOW Bankas { get;  }

        //...
        //...

        //...




        public int Complete()
        {
            _ctx.Database.BeginTransaction();
            int sonuc = 0;
            try
            {
                sonuc = _ctx.SaveChanges();
                _ctx.Database.CommitTransaction();

            }
            catch (Exception)
            {
                _ctx.Database.RollbackTransaction();
                sonuc = 0;
            }


            return sonuc;
        }
    }
}
