using ApplicationServices.Models;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.IServices
{
    public interface IStoreService
    {
        IEnumerable<Store> GetAllStores();

        Store GetStoreById(int storeId);

        Store CreateStore(StoreSummary storeSummary);

        Store EditStore(StoreSummary storeSummary, int storeId);

        void RemoveStore(int storeId);

        bool DoesStoreExists(int storeId);
    }
}
