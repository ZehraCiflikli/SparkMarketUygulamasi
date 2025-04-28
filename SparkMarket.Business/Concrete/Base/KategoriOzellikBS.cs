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
    public class KategoriOzellikBS:IKategoriOzellikBS

    {
        private readonly IKategoriOzellikRepository _repo;

        public KategoriOzellikBS(IKategoriOzellikRepository repo)
        {
            _repo = repo;
        }

        public KategoriOzellik Delete(KategoriOzellik entity)
        {
            return _repo.Delete(entity);
        }

        public KategoriOzellik DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public KategoriOzellik Get(Expression<Func<KategoriOzellik, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<KategoriOzellik> GetAll(Expression<Func<KategoriOzellik, bool>> filter = null, Expression<Func<KategoriOzellik, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<KategoriOzellik> GetAllByAktif(Expression<Func<KategoriOzellik, bool>> filter = null, Expression<Func<KategoriOzellik, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<KategoriOzellik> GetAllPaging(int Page, int PageSize, Expression<Func<KategoriOzellik, bool>> filter = null, Expression<Func<KategoriOzellik, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public KategoriOzellik GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<KategoriOzellik, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public KategoriOzellik Insert(KategoriOzellik entity)
        {
            return _repo.Insert(entity);
        }

        public KategoriOzellik Update(KategoriOzellik entity)
        {
            return _repo.Update(entity);
        }
    }
}
