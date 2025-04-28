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
    public class FaturaBS : IFaturaBS
    {
        private readonly IFaturaRepository _repo;

        public FaturaBS(IFaturaRepository repo)
        {
            _repo = repo;
        }
        public Fatura Delete(Fatura entity)
        {
            return _repo.Delete(entity);
        }

        public Fatura DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public Fatura Get(Expression<Func<Fatura, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<Fatura> GetAll(Expression<Func<Fatura, bool>> filter = null, Expression<Func<Fatura, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<Fatura> GetAllByAktif(Expression<Func<Fatura, bool>> filter = null, Expression<Func<Fatura, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<Fatura> GetAllPaging(int Page, int PageSize, Expression<Func<Fatura, bool>> filter = null, Expression<Func<Fatura, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public Fatura GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<Fatura, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public Fatura Insert(Fatura entity)
        {
            return _repo.Insert(entity);
        }

        public Fatura Update(Fatura entity)
        {
            return _repo.Update(entity);
        }


    }
}
