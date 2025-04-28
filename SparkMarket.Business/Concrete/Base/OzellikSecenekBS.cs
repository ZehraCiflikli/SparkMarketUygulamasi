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
    public class OzellikSecenekBS:IOzellikSecenekBS
    {
        private readonly IOzellikSecenekRepository _repo;

        public OzellikSecenekBS(IOzellikSecenekRepository repo)
        {
            _repo = repo;
        }

        public OzellikSecenek Delete(OzellikSecenek entity)
        {
            return _repo.Delete(entity);
        }

        public OzellikSecenek DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public OzellikSecenek Get(Expression<Func<OzellikSecenek, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<OzellikSecenek> GetAll(Expression<Func<OzellikSecenek, bool>> filter = null, Expression<Func<OzellikSecenek, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<OzellikSecenek> GetAllByAktif(Expression<Func<OzellikSecenek, bool>> filter = null, Expression<Func<OzellikSecenek, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<OzellikSecenek> GetAllPaging(int Page, int PageSize, Expression<Func<OzellikSecenek, bool>> filter = null, Expression<Func<OzellikSecenek, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public OzellikSecenek GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<OzellikSecenek, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public OzellikSecenek Insert(OzellikSecenek entity)
        {
            return _repo.Insert(entity);
        }

        public OzellikSecenek Update(OzellikSecenek entity)
        {
            return _repo.Update(entity);
        }
    }

}
