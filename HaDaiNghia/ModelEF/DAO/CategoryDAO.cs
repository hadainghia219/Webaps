using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelEF.Model;
using PagedList;
namespace ModelEF.DAO
{
    public class CategoryDAO
    {
        HaDaiNghiaContext db = null;
        public CategoryDAO()
        {
            db = new HaDaiNghiaContext();
        }

        public List<Category> listAll()
        {
            return db.Categories.ToList();
        }
    }
}
