using Infrastructure.Data.Abstract;
using Infrastructure.Data.Concrete.Dapper;
using Infrastructure.Entity;
using Infrastructure.Enumarations;
using SparkMarket.Business.Abstract;
using SparkMarket.Data.Abstract;
using SparkMarket.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SparkMarket.Business.Concrete.Base
{
    public class BirimBS:IBirimBs
    {
        private readonly IBirimRepository _repo;
    
        public BirimBS(IBirimRepository repo)
        {
            _repo = repo;
        }

        public Birim Delete(Birim entity)
        {
         

       




            return _repo.Delete(entity);
        }

        public Birim DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public Birim Get(Expression<Func<Birim, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<Birim> GetAll(Expression<Func<Birim, bool>> filter = null, Expression<Func<Birim, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<Birim> GetAllByAktif(Expression<Func<Birim, bool>> filter = null, Expression<Func<Birim, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<Birim> GetAllPaging(int Page, int PageSize, Expression<Func<Birim, bool>> filter = null, Expression<Func<Birim, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public Birim GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<Birim, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public Birim Insert(Birim entity)
        {
            return _repo.Insert(entity);
        }

        public Birim Update(Birim entity)
        {
            return _repo.Update(entity);
        }

    }
}
