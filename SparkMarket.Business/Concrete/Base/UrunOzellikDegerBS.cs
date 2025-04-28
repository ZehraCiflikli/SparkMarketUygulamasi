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
    public class UrunOzellikDegerBS:IUrunOzellikDegerBS
    {
        private readonly IUrunOzellikDegerRepository _repo;

        public UrunOzellikDegerBS(IUrunOzellikDegerRepository repo)
        {
            _repo = repo;
        }

        public UrunOzellikDeger Delete(UrunOzellikDeger entity)
        {
            return _repo.Delete(entity);
        }

        public UrunOzellikDeger DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public UrunOzellikDeger Get(Expression<Func<UrunOzellikDeger, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<UrunOzellikDeger> GetAll(Expression<Func<UrunOzellikDeger, bool>> filter = null, Expression<Func<UrunOzellikDeger, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<UrunOzellikDeger> GetAllByAktif(Expression<Func<UrunOzellikDeger, bool>> filter = null, Expression<Func<UrunOzellikDeger, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<UrunOzellikDeger> GetAllPaging(int Page, int PageSize, Expression<Func<UrunOzellikDeger, bool>> filter = null, Expression<Func<UrunOzellikDeger, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public UrunOzellikDeger GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<UrunOzellikDeger, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public UrunOzellikDeger Insert(UrunOzellikDeger entity)
        {
            return _repo.Insert(entity);
        }

        public UrunOzellikDeger Update(UrunOzellikDeger entity)
        {
            return _repo.Update(entity);
        }
    }
}
