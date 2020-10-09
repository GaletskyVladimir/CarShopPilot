using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
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

        }
    }
}
