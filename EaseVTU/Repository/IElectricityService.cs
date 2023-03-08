using System;
using EaseVTU.Data;

namespace EaseVTU.Repository
{
    public interface IElectricityService
    {
        Task<string> CreatePayment(DiscoName discoName, decimal amount, int meterNumber, MeterType meterType);
    }
}

