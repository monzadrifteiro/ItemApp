using Persistencia.Contexts;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL
{
    public class ItemDAL
    {
        private EFContext context = new EFContext();
        public void GravarFabricante(Item item)
        {
            if (item.ItemId == 0)
            {
                context.Itens.Add(item);
            }
            else
            {
                context.Entry(item).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
    }
}
