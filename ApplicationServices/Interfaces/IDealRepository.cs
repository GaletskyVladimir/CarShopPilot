using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Interfaces
{
    public interface IDealRepository
    {
        IEnumerable<Deal> GetAllDeals();

        IEnumerable<Deal> GetAllActiveDeals();

        Deal AddDeal(Deal deal);

        DealStatus UpdateDealStatus(int dealId, DealStatus status);

        Deal DeliveryDeal(int dealId);

        void RemoveDeal(int dealId);

        Deal GetDealById(int dealId);

        Deal UpdateDeal(Deal deal, int dealId);
    }
}
