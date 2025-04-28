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
    public class UrunYorumBS:IUrunYorumBS
    {
        private readonly IUrunYorumRepository _repo;

        public UrunYorumBS(IUrunYorumRepository repo)
        {
            _repo = repo;
        }

        public UrunYorum Delete(UrunYorum entity)
        {
            return _repo.Delete(entity);
        }

        public UrunYorum DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public UrunYorum Get(Expression<Func<UrunYorum, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<UrunYorum> GetAll(Expression<Func<UrunYorum, bool>> filter = null, Expression<Func<UrunYorum, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<UrunYorum> GetAllByAktif(Expression<Func<UrunYorum, bool>> filter = null, Expression<Func<UrunYorum, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<UrunYorum> GetAllPaging(int Page, int PageSize, Expression<Func<UrunYorum, bool>> filter = null, Expression<Func<UrunYorum, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public UrunYorum GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<UrunYorum, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public UrunYorum Insert(UrunYorum entity)
        {
            return _repo.Insert(entity);
        }

        public UrunYorum Update(UrunYorum entity)
        {
            return _repo.Update(entity);
        }
    }
}
