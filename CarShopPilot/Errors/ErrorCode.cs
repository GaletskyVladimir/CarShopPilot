using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarShopPilot.Errors
{
    public enum ErrorCode
    {
        UnHandled,
        BadArgument,
        UserNotFound,
        StoreNotFound
    }
}