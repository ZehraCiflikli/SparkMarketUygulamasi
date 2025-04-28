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
    public class KullanicAdreBS:IKullaniciAdreBS
    {
        private readonly IKullaniciAdreRepository _repo;

        public KullanicAdreBS(IKullaniciAdreRepository repo)
        {
            _repo = repo;
        }

        public KullaniciAdre Delete(KullaniciAdre entity)
        {
            return _repo.Delete(entity);
        }

        public KullaniciAdre DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public KullaniciAdre Get(Expression<Func<KullaniciAdre, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<KullaniciAdre> GetAll(Expression<Func<KullaniciAdre, bool>> filter = null, Expression<Func<KullaniciAdre, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<KullaniciAdre> GetAllByAktif(Expression<Func<KullaniciAdre, bool>> filter = null, Expression<Func<KullaniciAdre, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<KullaniciAdre> GetAllPaging(int Page, int PageSize, Expression<Func<KullaniciAdre, bool>> filter = null, Expression<Func<KullaniciAdre, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public KullaniciAdre GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<KullaniciAdre, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public KullaniciAdre Insert(KullaniciAdre entity)
        {
            return _repo.Insert(entity);
        }

        public KullaniciAdre Update(KullaniciAdre entity)
        {
            return _repo.Update(entity);
        }
    }
}
