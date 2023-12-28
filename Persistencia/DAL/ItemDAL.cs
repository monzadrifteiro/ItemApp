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
        public IQueryable<Item> ObterItensClassificadosPorNome()
        {
            return context.Itens.OrderBy(b => b.Nome);
        }
        public Item ObterItemPorId(long id)
        {
            return context.Itens.Where(i => i.ItemId == id).First();
        }
        public void GravarItem(Item item)
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
        public Item EliminarItemPorId(long id)
        {
            Item item = ObterItemPorId(id);
            context.Itens.Remove(item);
            context.SaveChanges();
            return item;
        }
    }
}