using Modelo;
using Persistencia.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico
{
    public class ItemServico
    {
        private ItemDAL itemDAL = new ItemDAL();
        public void GravarFabricante(Item item)
        {
            itemDAL.GravarFabricante(item);
        }
    }
}
