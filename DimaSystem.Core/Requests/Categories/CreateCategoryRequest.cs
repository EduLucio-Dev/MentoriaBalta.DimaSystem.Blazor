using System.ComponentModel.DataAnnotations;

namespace DimaSystem.Core.Requests.Categories
{
    public class CreateCategoryRequest : Request
    {
        [Required(ErrorMessage = "Titulo Inválido")]
        [MaxLength(80, ErrorMessage = "Titulo deve conter até 80 caracteres")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Descrição Inválido")]
        public string Description { get; set; } = string.Empty;
    }
}
