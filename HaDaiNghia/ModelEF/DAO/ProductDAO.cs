using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelEF.Model;
using PagedList;
namespace ModelEF.DAO
{
    public class ProductDAO
    {
        HaDaiNghiaContext db = null;
        public ProductDAO()
        {
            db = new HaDaiNghiaContext();
        }
        public  List<Product> getAllProduct()
        {
            return db.Products.ToList();
        }
        public long Insert(Product entity)
        {
            db.Products.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool Update(Product entity)
        {
            try
            {
                var product = db.Products.Find(entity.ID);
                product.UnitCost = entity.UnitCost;
                product.Name = entity.Name;
                product.CatID = entity.CatID;
                product.Image = entity.Image;
                product.Description = entity.Description;
                product.Quantity = entity.Quantity;
                product.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public IEnumerable<Product> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Product> model = db.Products;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.Quantity).ToPagedList(page, pageSize);
        }
        
        public Product GetById(string name)
        {
            return db.Products.SingleOrDefault(x => x.Name == name);
        }
        public Product ViewDetail(int id)
        {
            return db.Products.Find(id);
        }
    }
}
