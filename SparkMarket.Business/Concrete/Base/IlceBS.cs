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
    public class IlceBS:IIlceBS
    {
        private readonly IIlceRepository _repo;

        public IlceBS(IIlceRepository repo)
        {
            _repo = repo;
        }

        public Ilce Delete(Ilce entity)
        {
            return _repo.Delete(entity);
        }

        public Ilce DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public Ilce Get(Expression<Func<Ilce, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<Ilce> GetAll(Expression<Func<Ilce, bool>> filter = null, Expression<Func<Ilce, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<Ilce> GetAllByAktif(Expression<Func<Ilce, bool>> filter = null, Expression<Func<Ilce, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<Ilce> GetAllPaging(int Page, int PageSize, Expression<Func<Ilce, bool>> filter = null, Expression<Func<Ilce, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public Ilce GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<Ilce, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public Ilce Insert(Ilce entity)
        {
            return _repo.Insert(entity);
        }

        public Ilce Update(Ilce entity)
        {
            return _repo.Update(entity);
        }
    }
}
