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
    public class MenuYetkiBS:IMenuYetkiBS
    {
        private readonly IMenuYetkiRepository _repo;

        public MenuYetkiBS(IMenuYetkiRepository repo)
        {
            _repo = repo;  
        }

        public MenuYetki Delete(MenuYetki entity)
        {
            return _repo.Delete(entity);
        }

        public MenuYetki DeleteById(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public MenuYetki Get(Expression<Func<MenuYetki, bool>> filter, bool Tracking = false, params string[] includelist)
        {
            return _repo.Get(filter, Tracking, includelist);
        }

        public List<MenuYetki> GetAll(Expression<Func<MenuYetki, bool>> filter = null, Expression<Func<MenuYetki, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAll(filter, orderby, sorted, Tracking, includelist);
        }

        public List<MenuYetki> GetAllByAktif(Expression<Func<MenuYetki, bool>> filter = null, Expression<Func<MenuYetki, object>> orderby = null, Sorted sorted = Sorted.ASC, bool Aktif = true, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetAllByAktif(filter, orderby, sorted, Aktif, Tracking, includelist);
        }

        public PagingResult<MenuYetki> GetAllPaging(int Page, int PageSize, Expression<Func<MenuYetki, bool>> filter = null, Expression<Func<MenuYetki, object>> orderby = null, Sorted sorted = Sorted.ASC, params string[] includelist)
        {
            return _repo.GetAllPaging(Page, PageSize, filter, orderby, sorted, includelist);
        }

        public MenuYetki GetById(int Id, bool Tracking = false, params string[] includelist)
        {
            return _repo.GetById(Id, Tracking, includelist);
        }

        public int GetCount(Expression<Func<MenuYetki, bool>> filter = null, params string[] includelist)
        {
            return _repo.GetCount(filter, includelist);
        }

        public MenuYetki Insert(MenuYetki entity)
        {
            return _repo.Insert(entity);
        }

        public MenuYetki Update(MenuYetki entity)
        {
            return _repo.Update(entity);
        }
    }
}
