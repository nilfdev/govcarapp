using carbase.Models;
using OdeToFood.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Services
{
	public class CarBaseDataService : ICarBaseDataService
	{
		private GovCarDbContext _context;

		public CarBaseDataService(GovCarDbContext context)
		{
			_context = context;
		}

		public IEnumerable<RegistrationLine> Search(string carNumber)
		{
			return _context.RegistrationLines.Where(l => l.n_reg_new == carNumber);
		}
	}
}
