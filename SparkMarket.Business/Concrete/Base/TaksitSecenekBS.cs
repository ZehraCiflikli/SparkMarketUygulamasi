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
    public class TaksitSecenekBS:ITaksitSecenekBS
    {
        private readonly ITaksitSecenekRepository _repo;
        public TaksitSecenekBS(ITaksitSecenekRepository repo)
        {
            _repo = repo;
        }

        public TaksitSecenek Delete(TaksitSecenek entity)
        {
            return _repo.Delete(entity);
        }

        public TaksitSecenek DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public TaksitSecenek Get(Expression<Func<TaksitSecenek, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<TaksitSecenek> GetAll(Expression<Func<TaksitSecenek, bool>> filter = null, Expression<Func<TaksitSecenek, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<TaksitSecenek> GetAllByAktif(Expression<Func<TaksitSecenek, bool>> filter = null, Expression<Func<TaksitSecenek, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<TaksitSecenek> GetAllPaging(int Page, int PageSize, Expression<Func<TaksitSecenek, bool>> filter = null, Expression<Func<TaksitSecenek, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public TaksitSecenek GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<TaksitSecenek, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public TaksitSecenek Insert(TaksitSecenek entity)
        {
            return _repo.Insert(entity);
        }

        public TaksitSecenek Update(TaksitSecenek entity)
        {
            return _repo.Update(entity);
        }
    }
}
