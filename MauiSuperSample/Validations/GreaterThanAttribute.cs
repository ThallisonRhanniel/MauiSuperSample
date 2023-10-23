using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;


namespace MauiSuperSample.Validations
{
    public sealed class GreaterThanAttribute : ValidationAttribute
    {
        public GreaterThanAttribute(string propertyName)
        {
            PropertyName = propertyName;
        }

        public string PropertyName { get; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            object
                instance = validationContext.ObjectInstance,
                otherValue = instance.GetType().GetProperty(PropertyName)?.GetValue(instance);
            
            if (((IComparable)value).CompareTo(otherValue) > 0)
            {
                return ValidationResult.Success;
            }

            return new("The current value is smaller than the other one");
        }
    }
}
