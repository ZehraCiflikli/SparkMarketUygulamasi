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
    public class IlBs : IIlBS
    {
        private readonly IIlRepository _repo;

        public IlBs(IIlRepository repo)
        {
            _repo = repo;
        }

        public Il Delete(Il entity)
        {
            return _repo.Delete(entity);
        }

        public Il DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public Il Get(Expression<Func<Il, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<Il> GetAll(Expression<Func<Il, bool>> filter = null, Expression<Func<Il, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<Il> GetAllByAktif(Expression<Func<Il, bool>> filter = null, Expression<Func<Il, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<Il> GetAllPaging(int Page, int PageSize, Expression<Func<Il, bool>> filter = null, Expression<Func<Il, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public Il GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<Il, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public Il Insert(Il entity)
        {
            return _repo.Insert(entity);
        }

        public Il Update(Il entity)
        {
            return _repo.Update(entity);
        }
    }
}
