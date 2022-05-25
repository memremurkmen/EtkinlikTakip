using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class EtkinlikManager : IEtkinlikService
    {
        IEtkinlikDal _etkinlikDal;
        public EtkinlikManager(IEtkinlikDal etkinlikDal)
        {
            _etkinlikDal = etkinlikDal;
        }
        public Etkinlik GetById(long id)
        {
            return _etkinlikDal.GetByID(id);
        }

        public IList<Etkinlik> GetList()
        {
            return _etkinlikDal.GetListAll();
        }

        public void EtkinlikAdd(Etkinlik etkinlik)
        {
            _etkinlikDal.Insert(etkinlik);
        }

        public void EtkinlikDelete(Etkinlik etkinlik)
        {
            if (etkinlik.ID != 0)
            {
                _etkinlikDal.Delete(etkinlik);
            }
        }

        public void EtkinlikUpdate(Etkinlik etkinlik)
        {
            _etkinlikDal.Update(etkinlik);
        }
    }
}
