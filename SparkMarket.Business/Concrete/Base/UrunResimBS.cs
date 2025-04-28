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
    public class UrunResimBS:IUrunResimBS
    {
        private readonly IUrunResimRepository _repo;

       

        public UrunResimBS(IUrunResimRepository repo)
        {
            _repo = repo;
        }

        public UrunResim Delete(UrunResim entity)
        {
            return _repo.Delete(entity);
        }

        public UrunResim DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public UrunResim Get(Expression<Func<UrunResim, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<UrunResim> GetAll(Expression<Func<UrunResim, bool>> filter = null, Expression<Func<UrunResim, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<UrunResim> GetAllByAktif(Expression<Func<UrunResim, bool>> filter = null, Expression<Func<UrunResim, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<UrunResim> GetAllPaging(int Page, int PageSize, Expression<Func<UrunResim, bool>> filter = null, Expression<Func<UrunResim, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public UrunResim GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<UrunResim, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public UrunResim Insert(UrunResim entity)
        {
            return _repo.Insert(entity);
        }

        public UrunResim Update(UrunResim entity)
        {
            return _repo.Update(entity);
        }
    }
}
