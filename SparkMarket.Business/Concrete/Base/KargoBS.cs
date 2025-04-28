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
    public class KargoBS:IKargoBS
    {
        private readonly IKargoRepository _repo;

        public KargoBS(IKargoRepository repo)
        {
            _repo = repo;
        }

        public Kargo Delete(Kargo entity)
        {
            return _repo.Delete(entity);
        }

        public Kargo DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public Kargo Get(Expression<Func<Kargo, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<Kargo> GetAll(Expression<Func<Kargo, bool>> filter = null, Expression<Func<Kargo, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<Kargo> GetAllByAktif(Expression<Func<Kargo, bool>> filter = null, Expression<Func<Kargo, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<Kargo> GetAllPaging(int Page, int PageSize, Expression<Func<Kargo, bool>> filter = null, Expression<Func<Kargo, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public Kargo GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<Kargo, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public Kargo Insert(Kargo entity)
        {
            return _repo.Insert(entity);
        }

        public Kargo Update(Kargo entity)
        {
            return _repo.Update(entity);
        }
    }
}
