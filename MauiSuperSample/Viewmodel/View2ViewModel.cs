using System.ComponentModel.DataAnnotations;
using MauiSuperSample.Validations;


namespace MauiSuperSample.Viewmodel
{
    public partial class View2ViewModel : ObservableValidator
    {

        public event EventHandler? FormSubmissionCompleted;
        public event EventHandler? FormSubmissionFailed;


        public View2ViewModel()
        {
            FormSubmissionFailed += ShowValidation;
            FormSubmissionCompleted += ShowValidation;
        }

        private void ShowValidation(object sender, EventArgs e) => Erros = string.Join(Environment.NewLine, GetErrors().Select(e => e.ErrorMessage));
        

        [ObservableProperty]
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        [CustomValidation(typeof(View2ViewModel), nameof(ValidateName))]
        [GreaterThan(nameof(LastName))]
        private string? firstName;

        [ObservableProperty]
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        private string? lastName = "garcia";

        [ObservableProperty]
        [Required]
        [EmailAddress]
        private string? email;

        [ObservableProperty]
        [Required]
        [Range(1, 10)]
        [Phone]
        private string? phoneNumber;

        [ObservableProperty]
        private string? erros;


        [RelayCommand]
        private void Submit()
        {
            ValidateAllProperties();

            if (HasErrors)
                FormSubmissionFailed?.Invoke(this, EventArgs.Empty);
            else
                FormSubmissionCompleted?.Invoke(this, EventArgs.Empty);
        }

        public static ValidationResult ValidateName(string name, ValidationContext context)
        {
            if (name.Equals("THALLISON"))
                return new ValidationResult("Nome em Maiúsculo");

            if (name.Equals("thallison"))
                return new ValidationResult("Nome em Minúsculas");

            if (name != "Thallison")
                return new ValidationResult("Nome errado");


            return ValidationResult.Success;
        }
    }
}
