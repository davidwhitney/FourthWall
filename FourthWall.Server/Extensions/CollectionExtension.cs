using System;
using System.Collections.Generic;
using System.Linq;

namespace FourthWall.Server.Controllers
{
    public static class CollectionExtension
    {
        public static T Random<T>(this IEnumerable<T> items)
        {
            return items.OrderBy(x => Guid.NewGuid()).First();
        }
    }
}