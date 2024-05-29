using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreArtHub.Shared.Model
{
	public class LoginModel
	{
		[DisplayName("Почта")]
		public string Email { get; set; }

		[DisplayName("Пароль")]
		public string Password { get; set; }
	}
}
