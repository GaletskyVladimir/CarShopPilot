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
    public class DealRepository : IDealRepository
    {
        public Deal AddDeal(Deal deal)
        {
            return DealContainer.AddDeal(deal);
        }

        public Deal DeliveryDeal(int dealId)
        {
            return DealContainer.DeliveryDeal(dealId);
        }

        public IEnumerable<Deal> GetAllActiveDeals()
        {
            return DealContainer.GetAllActiveDeals();
        }

        public IEnumerable<Deal> GetAllDeals()
        {
            return DealContainer.GetAllDeals();
        }

        public Deal GetDealById(int dealId)
        {
            return DealContainer.GetDealById(dealId);
        }

        public void RemoveDeal(int dealId)
        {
            DealContainer.RescueDeal(dealId);
        }

        public Deal UpdateDeal(Deal deal, int dealId)
        {
            return DealContainer.UpdateDeal(deal, dealId);
        }

        public DealStatus UpdateDealStatus(int dealId, DealStatus status)
        {
            DealContainer.UpdateStatus(dealId, status);
            return status;
        }
    }
}
