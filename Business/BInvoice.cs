using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Data;

namespace Business
{
    public class BInvoice
    {
        public void Create(Invoice invoice)
        {
            var data = new DInvoice();
            data.Create(invoice);
        }

        public List<Invoice> Read()
        {
            var data = new DInvoice();
            return data.Read();
        }

        public void Update(Invoice invoice)
        {
            var data = new DInvoice();
            data.Update(invoice);
        }

        public void Delete(Invoice invoice)
        {
            var data = new DInvoice();
            data.Delete(invoice);
        }
    }
}
