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
    public class KullaniciBS:IKullaniciBS
    {
        private readonly IKullaniciRepository _repo;

        public KullaniciBS(IKullaniciRepository repo)
        {
            _repo = repo; 
        }

        public Kullanici Delete(Kullanici entity)
        {
            return _repo.Delete(entity);
        }

        public Kullanici DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public Kullanici Get(Expression<Func<Kullanici, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<Kullanici> GetAll(Expression<Func<Kullanici, bool>> filter = null, Expression<Func<Kullanici, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<Kullanici> GetAllByAktif(Expression<Func<Kullanici, bool>> filter = null, Expression<Func<Kullanici, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<Kullanici> GetAllPaging(int Page, int PageSize, Expression<Func<Kullanici, bool>> filter = null, Expression<Func<Kullanici, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public Kullanici GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<Kullanici, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public Kullanici Insert(Kullanici entity)
        {
            return _repo.Insert(entity);
        }

        public Kullanici Update(Kullanici entity)
        {
            return _repo.Update(entity);
        }

    }
}
