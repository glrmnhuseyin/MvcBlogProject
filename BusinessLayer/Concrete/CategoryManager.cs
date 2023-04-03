using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager
    {
        GenericRepository<Category> repo=new GenericRepository<Category>();
        public List<Category> GettAll() 
        {
            return repo.List();
        }
        public void CategoryAddBll(Category p)
        {
            if (p.CategoryName=="" || p.CategoryName.Length<=3 || p.CategoryDescription=="" || p.CategoryName.Length>=51)
            {
                //Hata mesajı
            }
            else
            {
                repo.Insert(p);
            }
        }
    }
}
