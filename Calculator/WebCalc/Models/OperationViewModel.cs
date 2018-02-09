using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebCalc.Models
{
    public class OperationViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public long Id { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Разработчик")]
        public long OwnerId { get; set; }
    }
}