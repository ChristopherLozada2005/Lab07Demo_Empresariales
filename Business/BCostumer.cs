using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Data;

namespace Business
{
    public class BCostumer
    {
        public void Create(Costumer costumer)
        {
            var data = new DCostumer();
            data.Create(costumer);
        }

        public List<Costumer> Read()
        {
            var data = new DCostumer();
            return data.Read();
        }

        public void Update(Costumer costumer)
        {
            var data = new DCostumer();
            data.Update(costumer);
        }

        public void Delete(Costumer costumer)
        {
            var data = new DCostumer();
            data.Delete(costumer);
        }
    }
}