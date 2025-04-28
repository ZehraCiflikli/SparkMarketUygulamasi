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
    public class KdvBS:IKdvBS
    {

        private readonly IKdvRepository _repo;

        public KdvBS(IKdvRepository repo)
        {
            _repo = repo;
        }

        public Kdv Delete(Kdv entity)
        {
            return _repo.Delete(entity);
        }

        public Kdv DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public Kdv Get(Expression<Func<Kdv, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<Kdv> GetAll(Expression<Func<Kdv, bool>> filter = null, Expression<Func<Kdv, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<Kdv> GetAllByAktif(Expression<Func<Kdv, bool>> filter = null, Expression<Func<Kdv, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<Kdv> GetAllPaging(int Page, int PageSize, Expression<Func<Kdv, bool>> filter = null, Expression<Func<Kdv, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public Kdv GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<Kdv, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public Kdv Insert(Kdv entity)
        {
            return _repo.Insert(entity);
        }

        public Kdv Update(Kdv entity)
        {
            return _repo.Update(entity);
        }
    }
}
