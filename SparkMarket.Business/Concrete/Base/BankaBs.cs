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
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace SparkMarket.Business.Concrete.Base
{
    public class BankaBS : DapperOperation<Banka>, IBankaBS
    {

        private readonly IBankaRepository _repo;
        private readonly IUnitOfWork _unitOfWork;
        public BankaBS(IBankaRepository repo, IUnitOfWork unitOfWork)
        {
            _repo = repo;
            _unitOfWork = unitOfWork;
        }

        public void BankaIslemleri()
        {
            _unitOfWork.Bankas.Insert(new Banka());
            //_unitOfWork.dfgdfg.Update();
            _unitOfWork.Complete();

        }


        public Banka Delete(Banka entity)
        {
            _unitOfWork.Bankas.Delete(entity);
            _unitOfWork.Complete();

            return entity;
        }

        public Banka DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public Banka Get(Expression<Func<Banka, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<Banka> GetAll(Expression<Func<Banka, bool>> filter = null, Expression<Func<Banka, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<Banka> GetAllByAktif(Expression<Func<Banka, bool>> filter = null, Expression<Func<Banka, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<Banka> GetAllPaging(int Page, int PageSize, Expression<Func<Banka, bool>> filter = null, Expression<Func<Banka, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public Banka GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<Banka, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public Banka Insert(Banka entity)
        {

            string hata;
            List<Banka> bankas = SelectList<Banka>("select * from Banka", null, out hata);
            if (!string.IsNullOrEmpty(hata))
            {

            }
            else
            {




            }



            return _repo.Insert(entity);
        }




        public Banka Update(Banka entity)
        {
            return _repo.Update(entity);
        }


      

    }
}
