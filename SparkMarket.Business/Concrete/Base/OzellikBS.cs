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
    public class OzellikBS:IOzellikBS
    {
        private readonly IOzellikRepository _repo;

        public OzellikBS(IOzellikRepository repo)
        {
            _repo = repo;
        }

        public Ozellik Delete(Ozellik entity)
        {
            return _repo.Delete(entity);
        }

        public Ozellik DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public Ozellik Get(Expression<Func<Ozellik, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<Ozellik> GetAll(Expression<Func<Ozellik, bool>> filter = null, Expression<Func<Ozellik, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<Ozellik> GetAllByAktif(Expression<Func<Ozellik, bool>> filter = null, Expression<Func<Ozellik, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<Ozellik> GetAllPaging(int Page, int PageSize, Expression<Func<Ozellik, bool>> filter = null, Expression<Func<Ozellik, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public Ozellik GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<Ozellik, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public Ozellik Insert(Ozellik entity)
        {
            return _repo.Insert(entity);
        }

        public Ozellik Update(Ozellik entity)
        {
            return _repo.Update(entity);
        }
    }
}
