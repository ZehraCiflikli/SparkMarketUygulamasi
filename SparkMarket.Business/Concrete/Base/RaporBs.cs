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
    public class RaporBs : IRaporBs
    {
        private readonly IRaporRepository _repo;

        public RaporBs(IRaporRepository repo)
        {
            _repo = repo;
        }

        public Rapor Delete(Rapor entity)
        {
            return _repo.Delete(entity);
        }

        public Rapor DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public Rapor Get(Expression<Func<Rapor, bool>> fRaporter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(fRaporter, Tracking, includelist);
        }

        public List<Rapor> GetAll(Expression<Func<Rapor, bool>> fRaporter = null, Expression<Func<Rapor, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(fRaporter, orderby, sorted, Tracking, includelist);
        }

        public List<Rapor> GetAllByAktif(Expression<Func<Rapor, bool>> fRaporter = null, Expression<Func<Rapor, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(fRaporter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<Rapor> GetAllPaging(int Page, int PageSize, Expression<Func<Rapor, bool>> fRaporter = null, Expression<Func<Rapor, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, fRaporter, orderby, sorted, includelist);
        }

        public Rapor GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<Rapor, bool>> fRaporter = null, params string[] includelist)
        {
            return _repo.GetCount(fRaporter, includelist);
        }

        public Rapor Insert(Rapor entity)
        {
            return _repo.Insert(entity);
        }

        public Rapor Update(Rapor entity)
        {
            return _repo.Update(entity);
        }



    }
}
