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
    public class UrunBS:IUrunBS
    {
        private readonly IUrunRepository _repo;
        public UrunBS(IUrunRepository repo)
        {
            _repo = repo;
        }
        public Urun Delete(Urun entity)
        {
            return _repo.Delete(entity);
        }

        public Urun DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public Urun Get(Expression<Func<Urun, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<Urun> GetAll(Expression<Func<Urun, bool>> filter = null, Expression<Func<Urun, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<Urun> GetAllByAktif(Expression<Func<Urun, bool>> filter = null, Expression<Func<Urun, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<Urun> GetAllPaging(int Page, int PageSize, Expression<Func<Urun, bool>> filter = null, Expression<Func<Urun, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public Urun GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<Urun, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public Urun Insert(Urun entity)
        {
            return _repo.Insert(entity);
        }

        public Urun Update(Urun entity)
        {
            return _repo.Update(entity);
        }
    }
}
