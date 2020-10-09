using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Interfaces
{
    public interface IStoreRepository
    {
        IEnumerable<Store> GetAll();

        Store GetById(int storeId);

        Store AddStore(Store store);

        Store ModifyStore(Store store);

        void RemoveStore(int storeId);

        bool DoesStoreExists(int storeId);
    };
}
