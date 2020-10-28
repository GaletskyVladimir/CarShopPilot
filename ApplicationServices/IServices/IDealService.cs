using ApplicationServices.Models;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.IServices
{
    public interface IDealService
    {
        Deal AddDeal(DealSummary dealSummary);

        Deal DeliveryDeal(int dealId);

        IEnumerable<Deal> GetAllActiveDeals();

        IEnumerable<Deal> GetAllDeals();

        Deal GetDealById(int dealId);

        void RemoveDeal(int dealId);

        DealStatus UpdateDealStatus(int dealId, DealStatus status);

        Deal ChangeUser(int dealId, int newCustomerId);
    }
}
