using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IEtkinlikService
    {
        void EtkinlikAdd(Etkinlik etkinlik);
        void EtkinlikDelete(Etkinlik etkinlik);
        void EtkinlikUpdate(Etkinlik etkinlik);
        IList<Etkinlik> GetList();
        Etkinlik GetById(int id);
    }
}
