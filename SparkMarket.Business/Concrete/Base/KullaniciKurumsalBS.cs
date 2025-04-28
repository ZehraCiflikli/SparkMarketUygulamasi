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
    public class KullaniciKurumsalBS:IKullaniciKurumsalBS
    {

        private readonly IKullaniciKurumsalRepository _repo;

        public KullaniciKurumsalBS(IKullaniciKurumsalRepository repo)
        {
            _repo = repo;
        }

        public KullaniciKurumsal Delete(KullaniciKurumsal entity)
        {
            return _repo.Delete(entity);
        }

        public KullaniciKurumsal DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public KullaniciKurumsal Get(Expression<Func<KullaniciKurumsal, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<KullaniciKurumsal> GetAll(Expression<Func<KullaniciKurumsal, bool>> filter = null, Expression<Func<KullaniciKurumsal, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<KullaniciKurumsal> GetAllByAktif(Expression<Func<KullaniciKurumsal, bool>> filter = null, Expression<Func<KullaniciKurumsal, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<KullaniciKurumsal> GetAllPaging(int Page, int PageSize, Expression<Func<KullaniciKurumsal, bool>> filter = null, Expression<Func<KullaniciKurumsal, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public KullaniciKurumsal GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<KullaniciKurumsal, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public KullaniciKurumsal Insert(KullaniciKurumsal entity)
        {
            return _repo.Insert(entity);
        }

        public KullaniciKurumsal Update(KullaniciKurumsal entity)
        {
            return _repo.Update(entity);
        }
    }
}
