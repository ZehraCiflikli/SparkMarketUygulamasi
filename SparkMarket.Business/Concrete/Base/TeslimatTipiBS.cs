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
    public class TeslimatTipiBS:ITeslimatTipiBS
    {
        private readonly ITeslimatTipiRepository _repo;

        public TeslimatTipiBS(ITeslimatTipiRepository repo)
        {
            _repo = repo;
        }

        public TeslimatTipi Delete(TeslimatTipi entity)
        {
            return _repo.Delete(entity);
        }

        public TeslimatTipi DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public TeslimatTipi Get(Expression<Func<TeslimatTipi, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<TeslimatTipi> GetAll(Expression<Func<TeslimatTipi, bool>> filter = null, Expression<Func<TeslimatTipi, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<TeslimatTipi> GetAllByAktif(Expression<Func<TeslimatTipi, bool>> filter = null, Expression<Func<TeslimatTipi, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<TeslimatTipi> GetAllPaging(int Page, int PageSize, Expression<Func<TeslimatTipi, bool>> filter = null, Expression<Func<TeslimatTipi, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public TeslimatTipi GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<TeslimatTipi, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public TeslimatTipi Insert(TeslimatTipi entity)
        {
            return _repo.Insert(entity);
        }

        public TeslimatTipi Update(TeslimatTipi entity)
        {
            return _repo.Update(entity);
        }
    }
}
