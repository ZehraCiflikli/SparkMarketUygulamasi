using Infrastructure.Entity;
using Infrastructure.Enumarations;
using SparkMarket.Business.Abstract;
using SparkMarket.Data.Abstract;
using SparkMarket.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SparkMarket.Business.Concrete.Base
{
    public class FaturaDetayBS:IFaturaDetayBS
    {
        private readonly IFaturaDetayRepository _repo;

        public FaturaDetayBS(IFaturaDetayRepository repo)
        {
            _repo = repo;
        }

        public FaturaDetay Delete(FaturaDetay entity)
        {
            return _repo.Delete(entity);
        }

        public FaturaDetay DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public FaturaDetay Get(Expression<Func<FaturaDetay, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<FaturaDetay> GetAll(Expression<Func<FaturaDetay, bool>> filter = null, Expression<Func<FaturaDetay, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<FaturaDetay> GetAllByAktif(Expression<Func<FaturaDetay, bool>> filter = null, Expression<Func<FaturaDetay, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<FaturaDetay> GetAllPaging(int Page, int PageSize, Expression<Func<FaturaDetay, bool>> filter = null, Expression<Func<FaturaDetay, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public FaturaDetay GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<FaturaDetay, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public FaturaDetay Insert(FaturaDetay entity)
        {
            return _repo.Insert(entity);
        }

        public FaturaDetay Update(FaturaDetay entity)
        {
            return _repo.Update(entity);
        }
    }
}
