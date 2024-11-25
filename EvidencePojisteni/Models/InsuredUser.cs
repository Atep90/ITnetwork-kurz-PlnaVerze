using System.ComponentModel.DataAnnotations;

namespace EvidencePojisteni.Models
{
	public class InsuredUser
	{
		[Key]
		public int UserId { get; set; }

		[Required(ErrorMessage = "Vyplňte jméno")]
		[StringLength(10, MinimumLength = 2, ErrorMessage = "Jméno nesmí přesáhnout 10 písmen")]
		[Display(Name = "Jméno")]
		public string FirstName { get; set; } = "";

		[Required(ErrorMessage = "Vyplňte příjmení")]
		[StringLength(20, MinimumLength = 2, ErrorMessage = "příjmení nesmí přesáhnout 20 písmen")]
		[Display(Name = "Příjmení")]
		public string LastName { get; set; } = "";

		[Required(ErrorMessage = "Vyplňte email")]
		[EmailAddress(ErrorMessage = "Neplatná emailová adresa")]
		[Display(Name = "Email")]
		public string Email { get; set; } = "";

		[Required(ErrorMessage = "Vyplňte telefonní číslo")]
		[RegularExpression(@"^(\+?\d{1,4}[\s\-]?)?(\d{3}[-\s]?)\d{3}[-\s]?\d{3}$", ErrorMessage = "špatný formát")]
		[DataType(DataType.PhoneNumber)]
		[Display(Name = "Telefon")]
		public string PhoneNumber { get; set; } = "";

		[Required(ErrorMessage = "Vyplňte ulici a číslo popisné")]
		[StringLength(50)]
		[Display(Name = "Ulice a číslo popisné")]
		public string Adress { get; set; } = "";

		[Required(ErrorMessage = "Vyplňte město")]
		[Display(Name = "Město")]
		public string City { get; set; } = "";

		[Required(ErrorMessage = "Vyplňte PSČ")]
		[DataType(DataType.PostalCode)]
		[Display(Name = "PSČ")]
		public int ZipCode { get; set; } = 0;

		public ICollection<Insurance> Insurances { get; set; } = new List<Insurance>();

		
	}
	
}
