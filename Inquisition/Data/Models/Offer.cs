﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Inquisition.Data.Models
{
	public class Offer
	{
		[Key]
		public int Id { get; set; }
		public string Url { get; set; }
		public DateTime ExpireDate { get; set; }

		public virtual User User { get; set; }
    }
}
