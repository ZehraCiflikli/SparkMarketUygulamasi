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
    public class RolBS:IRolBS
    {
        private readonly IRolRepository _repo;

        public RolBS(IRolRepository repo)
        {
            _repo = repo;
        }

        public Rol Delete(Rol entity)
        {
            return _repo.Delete(entity);
        }

        public Rol DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public Rol Get(Expression<Func<Rol, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<Rol> GetAll(Expression<Func<Rol, bool>> filter = null, Expression<Func<Rol, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<Rol> GetAllByAktif(Expression<Func<Rol, bool>> filter = null, Expression<Func<Rol, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<Rol> GetAllPaging(int Page, int PageSize, Expression<Func<Rol, bool>> filter = null, Expression<Func<Rol, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public Rol GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<Rol, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public Rol Insert(Rol entity)
        {
            return _repo.Insert(entity);
        }

        public Rol Update(Rol entity)
        {
            return _repo.Update(entity);
        }
    }
}
