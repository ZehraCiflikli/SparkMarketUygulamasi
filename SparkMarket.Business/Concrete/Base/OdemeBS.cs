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
    public class OdemeBS:IOdemeBS
    {
        private readonly IOdemeRepository _repo;

        public OdemeBS(IOdemeRepository repo)
        {
            _repo = repo;
        }

        public Odeme Delete(Odeme entity)
        {
            return _repo.Delete(entity);
        }

        public Odeme DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public Odeme Get(Expression<Func<Odeme, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<Odeme> GetAll(Expression<Func<Odeme, bool>> filter = null, Expression<Func<Odeme, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<Odeme> GetAllByAktif(Expression<Func<Odeme, bool>> filter = null, Expression<Func<Odeme, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<Odeme> GetAllPaging(int Page, int PageSize, Expression<Func<Odeme, bool>> filter = null, Expression<Func<Odeme, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public Odeme GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<Odeme, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public Odeme Insert(Odeme entity)
        {
            return _repo.Insert(entity);
        }

        public Odeme Update(Odeme entity)
        {
            return _repo.Update(entity);
        }
    }
}
