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
    public class IndirimBS:IIndirimBS
    {
        private readonly IIndirimRepository _repo;

        public IndirimBS(IIndirimRepository repo)
        {
            _repo = repo;
        }

        public Indirim Delete(Indirim entity)
        {
            return _repo.Delete(entity);
        }

        public Indirim DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public Indirim Get(Expression<Func<Indirim, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<Indirim> GetAll(Expression<Func<Indirim, bool>> filter = null, Expression<Func<Indirim, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<Indirim> GetAllByAktif(Expression<Func<Indirim, bool>> filter = null, Expression<Func<Indirim, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<Indirim> GetAllPaging(int Page, int PageSize, Expression<Func<Indirim, bool>> filter = null, Expression<Func<Indirim, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public Indirim GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<Indirim, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public Indirim Insert(Indirim entity)
        {
            return _repo.Insert(entity);
        }

        public Indirim Update(Indirim entity)
        {
            return _repo.Update(entity);
        }
    }
}
