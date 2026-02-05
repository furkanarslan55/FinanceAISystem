namespace UI.Models.ViewModel.Income
{
    public class IncomeCategoryCreateDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; } // kullanıcıdan ıd almıyoruz sistem atayacak
    }
}
