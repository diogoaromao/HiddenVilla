using Business.Repository.IRepository;
using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace Business.Repository
{
	public class HotelRoomRepository : IHotelRoomRepository
	{
		private readonly ApplicationDBContext _db;
		private readonly IMapper _mapper;

		public HotelRoomRepository(ApplicationDBContext db, IMapper mapper)
		{
			_db = db;
			_mapper = mapper;
		}

		public async Task<HotelRoomDTO> CreateHotelRoom(HotelRoomDTO hotelRoomDto)
		{
			var hotelRoom = _mapper.Map<HotelRoom>(hotelRoomDto); 
			hotelRoom.CreatedDate = DateTime.UtcNow;
			hotelRoom.CreatedBy = string.Empty;
			var addedHotelRoom = await _db.HotelRooms.AddAsync(hotelRoom);
			await _db.SaveChangesAsync();

			return _mapper.Map<HotelRoomDTO>(addedHotelRoom.Entity);
		}

		public async Task<HotelRoomDTO> UpdateHotelRoom(int roomId, HotelRoomDTO hotelRoomDto)
		{
			try
			{
				if (roomId == hotelRoomDto.Id)
				{
					var roomDetails = await _db.HotelRooms.FindAsync(roomId);
					var room =_mapper.Map<HotelRoomDTO, HotelRoom>(hotelRoomDto, roomDetails);

					room.UpdatedBy = string.Empty;
					room.UpdatedDate = DateTime.UtcNow;

					var updatedRoom = _db.HotelRooms.Update(room);
					await _db.SaveChangesAsync();

					return _mapper.Map<HotelRoomDTO>(updatedRoom.Entity);
				}
				else
				{
					// invalid
					return null;
				}
			}
			catch (Exception e)
			{
				return null;
			}
		}

		public async Task<HotelRoomDTO> GetHotelRoom(int roomId)
		{
			try
			{
				return _mapper.Map<HotelRoom, HotelRoomDTO>(await _db.HotelRooms.FirstOrDefaultAsync(x => x.Id == roomId));
			}
			catch (Exception e)
			{
				return null;
			}
		}

		public async Task<IEnumerable<HotelRoomDTO>> GetAllHotelRooms()
		{
			try
			{
				return _mapper.Map<IEnumerable<HotelRoom>, IEnumerable<HotelRoomDTO>>(_db.HotelRooms);
			}
			catch (Exception e)
			{
				return null;
			}
		}

		public async Task<HotelRoomDTO> IsRoomUnique(string name)
		{
			try
			{
				return _mapper.Map<HotelRoom, HotelRoomDTO>(
					await _db.HotelRooms.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower()));
			}
			catch (Exception e)
			{
				return null;
			}
		}

		public async Task<int> DeleteHotelRoom(int roomId)
		{
			var roomDetails = await _db.HotelRooms.FindAsync(roomId);
			if (roomDetails != null)
			{
				_db.HotelRooms.Remove(roomDetails);
				return await _db.SaveChangesAsync();
			}

			return 0;
		}
	}
}
