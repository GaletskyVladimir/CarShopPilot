using Autofac.Core;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Containers
{
    public static class DealContainer
    {
        private static int currentPrimaryId = 1;

        private static List<Deal> deals { get; set; }

        static DealContainer()
        {
            initDeals();
        }

        public static Deal AddDeal(Deal deal)
        {
            var savingDeal = new Deal(currentPrimaryId)
            {
                DealStatus = DealStatus.Engaged,
                CustomerID = deal.CustomerID,
                IsDelivered = false,
                UserId = deal.UserId,
                VehicleId = deal.VehicleId
            };
            deals.Add(savingDeal);
            currentPrimaryId++;
            return savingDeal;
        }

        public static IEnumerable<Deal> GetAllDeals()
        {
            return deals;
        }

        public static Deal GetDealById(int dealId)
        {
            return deals.First(x => x.ID == dealId);
        }

        public static IEnumerable<Deal> GetAllActiveDeals()
        {
            return deals.Where(x => x.IsDelivered == false);
        }

        public static Deal DeliveryDeal(int dealId)
        {
            var deliveryDeal = deals.First(x => x.ID == dealId);
            deliveryDeal.DealStatus = DealStatus.Delivered;
            deliveryDeal.IsDelivered = true;
            return deliveryDeal;
        }

        public static void UpdateStatus(int dealId, DealStatus status)
        {
            var deliveryDeal = deals.First(x => x.ID == dealId);
            deliveryDeal.DealStatus = status;
        }

        public static void RescueDeal(int dealId)
        {
            var rescuedDeal = deals.First(x => x.ID == dealId);
            deals.Remove(rescuedDeal);
        }

        public static Deal UpdateDeal(Deal deal, int dealId)
        {
            var updatingDeal = deals.First(x => x.ID == dealId);

            updatingDeal.DealStatus = deal.DealStatus;
            updatingDeal.IsDelivered = deal.IsDelivered;
            updatingDeal.VehicleId = deal.VehicleId;
            updatingDeal.UserId = deal.UserId;
            updatingDeal.CustomerID = deal.CustomerID;

            return updatingDeal;
        }

        private static void initDeals()
        {
            deals = new List<Deal>();
            deals.AddRange(new List<Deal>()
            {
                new Deal(currentPrimaryId++)
                {
                    DealStatus = DealStatus.Engaged,
                    CustomerID = 1,
                    UserId = 1,
                    IsDelivered = false,
                    VehicleId = 1
                },
                new Deal(currentPrimaryId++)
                {
                    DealStatus = DealStatus.Engaged,
                    CustomerID = 2,
                    UserId = 1,
                    IsDelivered = false,
                    VehicleId = 1
                },
                new Deal(currentPrimaryId++)
                {
                    DealStatus = DealStatus.Engaged,
                    CustomerID = 4,
                    UserId = 2,
                    IsDelivered = false,
                    VehicleId = 3
                }
            });
        }
    }
}
