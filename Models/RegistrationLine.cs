﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace carbase.Models
{
	[Table("ReestrTZ")]
	public class RegistrationLine
	{
		public string oper_name { get; set; }
		public string d_reg { get; set; }
		public string dep_code { get; set; }
		public string brand { get; set; }
		public string model { get; set; }
		public string make_year { get; set; }
		public string color { get; set; }
		public string kind { get; set; }
		public string body { get; set; }
		public string purpose { get; set; }
		public string fuel { get; set; }
		public string capacity { get; set; }
		public string own_weight { get; set; }
		public string total_weight { get; set; }
		
		[Key]
		public string n_reg_new { get; set; }
	}
}