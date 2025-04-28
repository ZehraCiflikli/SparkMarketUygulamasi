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
    public class FiyatTipiBS:IFiyatTipiBS
    {
        private readonly IFiyatTipiRepository _repo;

        public FiyatTipiBS(IFiyatTipiRepository repo)
        {
            _repo = repo;
        }

        public FiyatTipi Delete(FiyatTipi entity)
        {
            return _repo.Delete(entity);
        }

        public FiyatTipi DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public FiyatTipi Get(Expression<Func<FiyatTipi, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<FiyatTipi> GetAll(Expression<Func<FiyatTipi, bool>> filter = null, Expression<Func<FiyatTipi, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<FiyatTipi> GetAllByAktif(Expression<Func<FiyatTipi, bool>> filter = null, Expression<Func<FiyatTipi, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<FiyatTipi> GetAllPaging(int Page, int PageSize, Expression<Func<FiyatTipi, bool>> filter = null, Expression<Func<FiyatTipi, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public FiyatTipi GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<FiyatTipi, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public FiyatTipi Insert(FiyatTipi entity)
        {
            return _repo.Insert(entity);
        }

        public FiyatTipi Update(FiyatTipi entity)
        {
            return _repo.Update(entity);
        }
    }
}
