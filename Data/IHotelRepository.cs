﻿namespace MinimalAPI.Data;

public interface IHotelRepository : IDisposable
{
    Task<List<Hotel?>> GetHotelsAsync();
    Task<Hotel?> GetHotelAsync(long id);
    Task AddHotelAsync(Hotel hotel);
    Task UpdateHotelAsync(Hotel hotel);
    Task DeleteHotelAsync(long id);
    Task SaveAsync();
}