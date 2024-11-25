using Microsoft.AspNetCore.SignalR;
using System.ComponentModel.DataAnnotations;

namespace EvidencePojisteni.Models
{
	public class Insurance
	{
		[Key]
		public int InsuranceId { get; set; }

  		[Display(Name = "Pojištěnec")]		
        public int InsuredUserId { get; set; }

		[Required(ErrorMessage = "Vyberte jednu z možností")]
		[Display(Name = "Pojištění")]
		public string InsuranceType { get; set; } = "";

		[Required(ErrorMessage = "Zadejte částku")]
		[Range(1,10000000, ErrorMessage = "Zadejte částku do 10 000 000")]
		[Display(Name = "Částka")]
		public int Amount { get; set; } = 0;

		[Required(ErrorMessage = "Vyplňte předmět k pojištění")]
		[StringLength(50)]
		[Display(Name = "Předmět pojištění")]
		public string SubjectOfInsurance { get; set; } = "";

		[Required(ErrorMessage = "Vyplňte datum od")]
		[DataType(DataType.Date)]
		[Display(Name = "Platnost od")]
		public DateTime DateFrom { get; set; }

		[Required(ErrorMessage = "Vyplňte datum do")]
		[DataType(DataType.Date)]
		[Display(Name = "Platnost do")]
		public DateTime DateTo { get; set; }

        public virtual InsuredUser? InsuredUser { get; set; }

		
    }	
}
