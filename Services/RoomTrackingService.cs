using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SpacefinderApp.Services;
using SpacefinderApp.Model;

public class RoomTrackingService
{
    private Timer _timer;
    public event Action<List<Room>> RoomsUpdated;

    public void StartTracking()
    {
        _timer = new Timer(UpdateRooms, null, 0, 5000); // Refresh every 5s
    }

    private void UpdateRooms(object state)
    {
        var rooms = FetchRoomsFromDatabase(); // Query DB for availability
        RoomsUpdated?.Invoke(rooms);
    }

    private List<Room> FetchRoomsFromDatabase()
    {
        throw new NotImplementedException();
    }
}
