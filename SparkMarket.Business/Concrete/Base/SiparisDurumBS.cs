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
    public class SiparisDurumBS:ISiparisDurumBS
    {
        private readonly ISiparisDurumRepository _repo;

        public SiparisDurumBS(ISiparisDurumRepository repo)
        {
            _repo = repo;
        }

        public SiparisDurum Delete(SiparisDurum entity)
        {
            return _repo.Delete(entity);
        }

        public SiparisDurum DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public SiparisDurum Get(Expression<Func<SiparisDurum, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<SiparisDurum> GetAll(Expression<Func<SiparisDurum, bool>> filter = null, Expression<Func<SiparisDurum, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<SiparisDurum> GetAllByAktif(Expression<Func<SiparisDurum, bool>> filter = null, Expression<Func<SiparisDurum, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<SiparisDurum> GetAllPaging(int Page, int PageSize, Expression<Func<SiparisDurum, bool>> filter = null, Expression<Func<SiparisDurum, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public SiparisDurum GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<SiparisDurum, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public SiparisDurum Insert(SiparisDurum entity)
        {
            return _repo.Insert(entity);
        }

        public SiparisDurum Update(SiparisDurum entity)
        {
            return _repo.Update(entity);
        }
    }
}
