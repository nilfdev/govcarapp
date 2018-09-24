using System.Collections.Generic;
using System.Linq;
using carbase;
using carbase.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Services;

namespace OdeToFood.Controllers
{
	public class RegistrationController : Controller
	{
		private readonly ICarBaseDataService _carBaseDataService;

		public RegistrationController(ICarBaseDataService carBaseDataService)
		{
			_carBaseDataService = carBaseDataService;
		}

		private const string SpecializedTypeString = "СПЕЦІАЛІЗОВАНИЙ";
		private const string SpecialTypeString = "СПЕЦІАЛЬНИЙ";
		private const string GeneralTypeString = "ЗАГАЛЬНИЙ";

		private IDictionary<string, Purposes> _carPurposes = new Dictionary<string, Purposes>()
		{
			{ GeneralTypeString,  Purposes.General },
			{ SpecialTypeString,  Purposes.Special },
			{ SpecializedTypeString,  Purposes.Specialized }
		};

		[HttpGet]
		public string Test()
		{
			return "Hello world";
		}

		[HttpGet]
		[EnableCors("AllowAllOrigins")]
		public CarInformation Get(string id)
		{
			IEnumerable<RegistrationLine> lines = _carBaseDataService.Search(id);

			if (!lines.Any()) return new CarInformation();

			var car = lines.FirstOrDefault();
			return new CarInformation
			{
				Description =
					new CarDescription(car.brand, car.model, car.make_year, car.color, car.kind, car.brand, car.purpose, car.fuel, car.capacity, car.own_weight, car.total_weight, car.n_reg_new),
				Registrations = lines.Select(x => new Registration { d_reg = x.d_reg, oper_name = x.oper_name, dep_code = x.dep_code }),
				Type = (int)(_carPurposes.ContainsKey(car.purpose) ? _carPurposes[car.purpose] : Purposes.Undefined)
			};
		}
	}
}