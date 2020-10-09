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
    public class DealService
    {
        private readonly IDealRepository dealRepository;

        public DealService(IDealRepository dealRepository)
        {
            this.dealRepository = dealRepository;
        }

        public Deal AddDeal(DealSummary dealSummary)
        {
            var savingDeal = new Deal()
            {
                CustomerID = dealSummary.CustomerID,
                VehicleId = dealSummary.VehicleId,
                UserId = dealSummary.UserId
            };

            return dealRepository.AddDeal(savingDeal);
        }

        public Deal DeliveryDeal(int dealId)
        {
            return dealRepository.DeliveryDeal(dealId);
        }

        public IEnumerable<Deal> GetAllActiveDeals()
        {
            return dealRepository.GetAllActiveDeals();
        }

        public IEnumerable<Deal> GetAllDeals()
        {
            return dealRepository.GetAllDeals();
        }

        public Deal GetDealById(int dealId)
        {
            return dealRepository.GetDealById(dealId);
        }

        public void RemoveDeal(int dealId)
        {
            dealRepository.RemoveDeal(dealId);
        }

        public DealStatus UpdateDealStatus(int dealId, DealStatus status)
        {
            if (status == DealStatus.Delivered)
            {
                dealRepository.DeliveryDeal(dealId);
            }
            dealRepository.UpdateDealStatus(dealId, status);
            return status;
        }

        public Deal ChangeUser(int dealId, int newCustomerId)
        {
            var deal = dealRepository.GetDealById(dealId);
            deal.UserId = newCustomerId;
            return dealRepository.UpdateDeal(deal, dealId);
        }
    }
}
