using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Containers
{
    public static class StoreContainer
    {
        private static int currentPrimaryId = 1;

        private static List<Store> stores { get; set; }

        static StoreContainer()
        {
            initStores();
        }

        //todo: optional pagination
        public static IEnumerable<Store> GetAll() => stores;

        public static Store GetById(int storeId)
        {
            return stores.First(x => x.ID == storeId);
        }

        public static Store AddStore(Store store)
        {
            var savingStore = new Store(currentPrimaryId)
            {
                State = store.State,
                Address = store.Address,
                City = store.City,
                Email = store.Email,
                Name = store.Name,
                Phone = store.Phone
            };

            stores.Add(savingStore);
            currentPrimaryId++;
            return savingStore;
        }

        public static Store UpdateStore(Store store)
        {
            var updatingStore = stores.First(x => x.ID == store.ID);

            updatingStore.State = store.State;
            updatingStore.Address = store.Address;
            updatingStore.City = store.City;
            updatingStore.Email = store.Email;
            updatingStore.Name = store.Name;
            updatingStore.Phone = store.Phone;
            return updatingStore;
        }

        public static void RemoveStore(int storeId)
        {
            var removingStore = stores.First(x => x.ID == storeId);
            stores.Remove(removingStore);
        }

        public static bool DoesStoreExists(int storeId)
        {
            return stores.Any(x => x.ID == storeId);
        }

        private static void initStores()
        {
            stores = new List<Store>();

            stores.AddRange(
                new List<Store>() {
                    new Store(currentPrimaryId++)
                    {
                        Name = "Boston Ferrari Store",
                        City = "Boston",
                        State = "BT",
                        Address = "str Nice/1 12",
                        Email = "BostonStore@gmail.com",
                        Phone = "+1 323 434 343"
                    },
                    new Store(currentPrimaryId++)
                    {
                        Name = "NY Audi",
                        City = "New York",
                        State = "NY",
                        Address = "Brooklin, down str.12",
                        Email = "NYStore@gmail.com",
                        Phone = "+1 323 434 343"
                    },
                    new Store(currentPrimaryId++)
                    {
                        Name = "Florida Suntrup",
                        City = "Florida",
                        State = "FL",
                        Address = "Florisa str, 1 12",
                        Email = "FloridaSun@gmail.com",
                        Phone = "+1 323 222 222"
                    }
                }
            );
        }
    }
}
