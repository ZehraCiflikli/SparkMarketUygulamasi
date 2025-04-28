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
    public class SiparisKargoBS:ISiparisKargoBS
    {
        private readonly ISiparisKargoRepository _repo;

        public SiparisKargoBS(ISiparisKargoRepository repo)
        {
            _repo = repo;
        }
        public SiparisKargo Delete(SiparisKargo entity)
        {
            return _repo.Delete(entity);
        }

        public SiparisKargo DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public SiparisKargo Get(Expression<Func<SiparisKargo, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<SiparisKargo> GetAll(Expression<Func<SiparisKargo, bool>> filter = null, Expression<Func<SiparisKargo, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<SiparisKargo> GetAllByAktif(Expression<Func<SiparisKargo, bool>> filter = null, Expression<Func<SiparisKargo, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<SiparisKargo> GetAllPaging(int Page, int PageSize, Expression<Func<SiparisKargo, bool>> filter = null, Expression<Func<SiparisKargo, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public SiparisKargo GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<SiparisKargo, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public SiparisKargo Insert(SiparisKargo entity)
        {
            return _repo.Insert(entity);
        }

        public SiparisKargo Update(SiparisKargo entity)
        {
            return _repo.Update(entity);
        }
    }
}
