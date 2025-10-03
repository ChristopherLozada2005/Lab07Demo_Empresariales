using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Data;

namespace Business
{
    public class BProduct
    {

        public void Create(Product product)
        {
            var data = new DProduct();
            data.Create(product);
        }

        public List<Product> Read()
        {
            var data = new DProduct();
            return data.Read();
        }

        public void Update(Product product)
        {
            var data = new DProduct();
            data.Update(product);
        }

        public void Delete(Product product)
        {
            var data = new DProduct();
            data.Delete(product);
        }
    }
}
