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
    public class SipariBS:ISipariBS
    {
        private readonly ISipariRepository _repo;

        public SipariBS(ISipariRepository repo)
        {
            _repo = repo;
        }
        public Sipari Delete(Sipari entity)
        {
            return _repo.Delete(entity);
        }

        public Sipari DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public Sipari Get(Expression<Func<Sipari, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<Sipari> GetAll(Expression<Func<Sipari, bool>> filter = null, Expression<Func<Sipari, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<Sipari> GetAllByAktif(Expression<Func<Sipari, bool>> filter = null, Expression<Func<Sipari, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<Sipari> GetAllPaging(int Page, int PageSize, Expression<Func<Sipari, bool>> filter = null, Expression<Func<Sipari, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public Sipari GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<Sipari, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public Sipari Insert(Sipari entity)
        {
            return _repo.Insert(entity);
        }

        public Sipari Update(Sipari entity)
        {
            return _repo.Update(entity);
        }
    }
}
