namespace MinimalAPI.Data;

public class HotelRepository : IHotelRepository
{
    private readonly HotelDb _context;
    private bool _disposed;
    
    public HotelRepository(HotelDb context)
    {
        _context = context;
    }

    public async Task AddHotelAsync(Hotel hotel) =>
        await _context.Hotels.AddAsync(hotel);

    public async Task UpdateHotelAsync(Hotel hotel)
    {
        var hotelFromDb = await _context.Hotels.FindAsync(hotel.Id);
        if (hotelFromDb is null) return;
        hotelFromDb.Longitude = hotel.Longitude;
        hotelFromDb.Latitude = hotel.Latitude;
        hotelFromDb.Name = hotel.Name;
    }

    public async Task DeleteHotelAsync(long id)
    {
        var hotelFromDb = await _context.Hotels.FindAsync(id);
        if (hotelFromDb is null) return;
        _context.Hotels.Remove(hotelFromDb);
    }

    public Task<List<Hotel?>> GetHotelsAsync() => _context.Hotels.ToListAsync();

    public async Task<Hotel?> GetHotelAsync(long id) =>
        await _context.Hotels.FindAsync(id);

    public Task SaveAsync() => _context.SaveChangesAsync();

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        _disposed = true;
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}