using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Business.Repository.IRepository
{
	public interface IHotelRoomRepository
	{
		public Task<HotelRoomDTO> CreateHotelRoom(HotelRoomDTO hotelRoomDto);
		public Task<HotelRoomDTO> UpdateHotelRoom(int roomId, HotelRoomDTO hotelRoomDto);
		public Task<HotelRoomDTO> GetHotelRoom(int roomId);
		public Task<IEnumerable<HotelRoomDTO>> GetAllHotelRooms();
		public Task<HotelRoomDTO> IsRoomUnique(string name);
		public Task<int> DeleteHotelRoom(int roomId);
	}
}
