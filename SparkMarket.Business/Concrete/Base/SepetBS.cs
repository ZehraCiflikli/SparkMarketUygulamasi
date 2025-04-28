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
    public class SepetBS:ISepetBS
    {
        private readonly ISepetRepository _repo;

        public SepetBS(ISepetRepository repo)
        {
            _repo = repo;
        }

        public Sepet Delete(Sepet entity)
        {
            return _repo.Delete(entity);
        }

        public Sepet DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public Sepet Get(Expression<Func<Sepet, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<Sepet> GetAll(Expression<Func<Sepet, bool>> filter = null, Expression<Func<Sepet, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<Sepet> GetAllByAktif(Expression<Func<Sepet, bool>> filter = null, Expression<Func<Sepet, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<Sepet> GetAllPaging(int Page, int PageSize, Expression<Func<Sepet, bool>> filter = null, Expression<Func<Sepet, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public Sepet GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<Sepet, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public Sepet Insert(Sepet entity)
        {
            return _repo.Insert(entity);
        }

        public Sepet Update(Sepet entity)
        {
            return _repo.Update(entity);
        }
    }
}
