using ApplicationServices.Interfaces;
using ApplicationServices.Models;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Services
{
    public class StoreService
    {
        private readonly IStoreRepository storeRepository;

        public StoreService(IStoreRepository storeRepository)
        {
            this.storeRepository = storeRepository;
        }

        public IEnumerable<Store> GetAllStores()
        {
            return storeRepository.GetAll();
        }

        public Store GetStoreById(int storeId)
        {
            return storeRepository.GetById(storeId);
        }

        public Store CreateStore(StoreSummary storeSummary)
        {
            //todo mapper
            var store = new Store()
            {
                State = storeSummary.State,
                Address = storeSummary.Address,
                City = storeSummary.City,
                Email = storeSummary.Email,
                Name = storeSummary.Name,
                Phone = storeSummary.Phone
            };
            return storeRepository.AddStore(store);
        }

        public Store EditStore(StoreSummary storeSummary, int storeId)
        {
            var store = storeRepository.GetById(storeId);
            store.State = storeSummary.State;
            store.Address = storeSummary.Address;
            store.City = storeSummary.City;
            store.Email = storeSummary.Email;
            store.Name = storeSummary.Name;
            store.Phone = storeSummary.Phone;
            return storeRepository.ModifyStore(store);
        }

        public void RemoveStore(int storeId)
        {
            storeRepository.RemoveStore(storeId);
        }

        public bool DoesStoreExists(int storeId)
        {
            return storeRepository.DoesStoreExists(storeId);
        }
    }
}
