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
    public class OdemeTuruBS:IOdemeTuruBS
    {
        private readonly IOdemeTuruRepository _repo;

        public OdemeTuruBS(IOdemeTuruRepository repo)
        {
            _repo = repo;
        }

        public OdemeTuru Delete(OdemeTuru entity)
        {
            return _repo.Delete(entity);
        }

        public OdemeTuru DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public OdemeTuru Get(Expression<Func<OdemeTuru, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<OdemeTuru> GetAll(Expression<Func<OdemeTuru, bool>> filter = null, Expression<Func<OdemeTuru, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<OdemeTuru> GetAllByAktif(Expression<Func<OdemeTuru, bool>> filter = null, Expression<Func<OdemeTuru, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<OdemeTuru> GetAllPaging(int Page, int PageSize, Expression<Func<OdemeTuru, bool>> filter = null, Expression<Func<OdemeTuru, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public OdemeTuru GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<OdemeTuru, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public OdemeTuru Insert(OdemeTuru entity)
        {
            return _repo.Insert(entity);
        }

        public OdemeTuru Update(OdemeTuru entity)
        {
            return _repo.Update(entity);
        }
    }
}
