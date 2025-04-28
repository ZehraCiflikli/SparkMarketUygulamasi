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
    public class IndirimTipiBs:IIndirimTipiBS
    {
        private readonly IIndirimTipiRepository _repo;

        public IndirimTipiBs(IIndirimTipiRepository repo)
        {
            _repo = repo;
        }

        public IndirimTipi Delete(IndirimTipi entity)
        {
            return _repo.Delete(entity);
        }

        public IndirimTipi DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public IndirimTipi Get(Expression<Func<IndirimTipi, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<IndirimTipi> GetAll(Expression<Func<IndirimTipi, bool>> filter = null, Expression<Func<IndirimTipi, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<IndirimTipi> GetAllByAktif(Expression<Func<IndirimTipi, bool>> filter = null, Expression<Func<IndirimTipi, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<IndirimTipi> GetAllPaging(int Page, int PageSize, Expression<Func<IndirimTipi, bool>> filter = null, Expression<Func<IndirimTipi, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public IndirimTipi GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<IndirimTipi, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public IndirimTipi Insert(IndirimTipi entity)
        {
            return _repo.Insert(entity);
        }

        public IndirimTipi Update(IndirimTipi entity)
        {
            return _repo.Update(entity);
        }
    }
}
