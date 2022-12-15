using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IBasketRepository
    {
        Task<CustomerBasket> GetBascketAsync(string backetId);
        Task<CustomerBasket> UpdateBascketAsync(CustomerBasket backet);
        Task<bool> DeleteBascketAsync(string backetId);

    }
}