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
    public class UrunFiyatBS:IUrunFiyatBS
    {
        private readonly IUrunFiyatRepository _repo;

        public UrunFiyatBS(IUrunFiyatRepository repo)
        {
            _repo = repo;
        }
        public UrunFiyat Delete(UrunFiyat entity)
        {
            return _repo.Delete(entity);
        }

        public UrunFiyat DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public UrunFiyat Get(Expression<Func<UrunFiyat, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<UrunFiyat> GetAll(Expression<Func<UrunFiyat, bool>> filter = null, Expression<Func<UrunFiyat, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<UrunFiyat> GetAllByAktif(Expression<Func<UrunFiyat, bool>> filter = null, Expression<Func<UrunFiyat, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<UrunFiyat> GetAllPaging(int Page, int PageSize, Expression<Func<UrunFiyat, bool>> filter = null, Expression<Func<UrunFiyat, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public UrunFiyat GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<UrunFiyat, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public UrunFiyat Insert(UrunFiyat entity)
        {
            return _repo.Insert(entity);
        }

        public UrunFiyat Update(UrunFiyat entity)
        {
            return _repo.Update(entity);
        }
    }
}
