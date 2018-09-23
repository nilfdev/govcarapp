using carbase.Models;
using System.Collections.Generic;

namespace OdeToFood.Services
{
	public interface ICarBaseDataService
	{
		IEnumerable<RegistrationLine> Search(string carNumber);
	}
}