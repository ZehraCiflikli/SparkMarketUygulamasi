using Infrastructure.Data.Concrete.Dapper;
using Infrastructure.Entity;
using Infrastructure.Enumarations;
using SparkMarket.Data.Abstract;
using SparkMarket.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SparkMarket.Data.Concrete.Dapper
{
    public class EfDapperBankaRepository :DapperRepositoryBase<Banka> ,IBankaRepository
    {
      
    }
}
