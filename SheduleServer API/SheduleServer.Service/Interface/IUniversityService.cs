﻿using SheduleServer.Domain.Entity.Shedule;
using SheduleServer.Domain.Response;
using SheduleServer.Service.Dto.University;

namespace SheduleServer.Service.Interface
{
	public interface IUniversityService
	{
		public Task<IBaseResponse<University>> CreateUniversityAsync(UniversityCreateModelDto model);

		public Task<IBaseResponse<University>> DeleteUniversityAsync(string id);

		public Task<IBaseResponse<University>> UpdateUniversityAsync(UniversityUpdateModelDto model);

		public Task<IBaseResponse<University>> GetUniversityById(string id);

		public Task<IBaseResponse<IEnumerable<University>>> GetAllUniversitiesAsync();
	}
}
