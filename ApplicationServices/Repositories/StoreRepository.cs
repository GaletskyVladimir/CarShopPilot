using ApplicationServices.Containers;
using ApplicationServices.Interfaces;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        public Store AddStore(Store store)
        {
            return StoreContainer.AddStore(store);
        }

        public bool DoesStoreExists(int storeId)
        {
            return StoreContainer.DoesStoreExists(storeId);
        }

        public IEnumerable<Store> GetAll()
        {
            return StoreContainer.GetAll();
        }

        public Store GetById(int storeId)
        {
            return StoreContainer.GetById(storeId);
        }

        public Store ModifyStore(Store store)
        {
            return StoreContainer.UpdateStore(store);
        }

        public void RemoveStore(int storeId)
        {
            StoreContainer.RemoveStore(storeId);
        }
    }
}
