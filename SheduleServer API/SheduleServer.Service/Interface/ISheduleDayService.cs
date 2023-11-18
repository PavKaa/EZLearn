using SheduleServer.Domain.Entity.Shedule;
using SheduleServer.Domain.Response;
using SheduleServer.Service.Dto.SheduleDay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheduleServer.Service.Interface
{
	public interface ISheduleDayService
	{
		public Task<IBaseResponse<SheduleDay>> CreateSheduleDayAsync(SheduleDayCreateModelDto model);

		public Task<IBaseResponse<SheduleDay>> DeleteSheduleDayAsync(SheduleDayDeleteModelDto model);

		public Task<IBaseResponse<SheduleDay>> UpdateSheduleDayAsync(SheduleDayUpdateModelDto model);

		public Task<IBaseResponse<SheduleDay>> GetSheduleDayById(int id);

		public Task<IBaseResponse<IEnumerable<SheduleDay>>> GetAllSheduleDaysAsync();
	}
}
