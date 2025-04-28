using Infrastructure.Data.Concrete.EntityFramework;
using SparkMarket.Data.Abstract;
using SparkMarket.Data.Concrete.EntityFramework.context;
using SparkMarket.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SparkMarket.Data.Concrete.EntityFramework.repository
{
    public class EfSipariRepository:EfRepositoryBase<Sipari,SparkMarketDbContext>,ISipariRepository
    {
    }
}
