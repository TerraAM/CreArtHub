using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreArtHub.Shared.Dto
{
	public class FeedBackDto
	{
		public int Id { get; set; }
		[DisplayName("Ваше Имя")]
		public string UserName { get; set; } = string.Empty;
		[DisplayName("Ваша почта")]
		public string UserEmail { get; set; } = string.Empty;
		[DisplayName("Тема")]
		public string Title { get; set; } = string.Empty;
		[DisplayName("Сообщение")]
		public string Context { get; set; } = string.Empty;
		[DisplayName("Прочитан?")]
		public bool isReaded { get; set; } = false;
	}
}
