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
    public class UrunIndirimBS:IUrunIndirimBS
    {
        private readonly IUrunIndirimRepository _repo;

        public UrunIndirimBS(IUrunIndirimRepository repo)
        {
            _repo = repo;
        }
        public UrunIndirim Delete(UrunIndirim entity)
        {
            return _repo.Delete(entity);
        }

        public UrunIndirim DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public UrunIndirim Get(Expression<Func<UrunIndirim, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<UrunIndirim> GetAll(Expression<Func<UrunIndirim, bool>> filter = null, Expression<Func<UrunIndirim, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<UrunIndirim> GetAllByAktif(Expression<Func<UrunIndirim, bool>> filter = null, Expression<Func<UrunIndirim, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<UrunIndirim> GetAllPaging(int Page, int PageSize, Expression<Func<UrunIndirim, bool>> filter = null, Expression<Func<UrunIndirim, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public UrunIndirim GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<UrunIndirim, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public UrunIndirim Insert(UrunIndirim entity)
        {
            return _repo.Insert(entity);
        }

        public UrunIndirim Update(UrunIndirim entity)
        {
            return _repo.Update(entity);
        }
    }
}
