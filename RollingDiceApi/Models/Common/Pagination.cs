namespace RollingDiceApi.Models.Common
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class Pagination : IValidatableObject
    {
        [DefaultValue(1)]
        public int Page { get; set; }
        [DefaultValue(10)]
        public int PageSize { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Page < 1)
            {
                yield return new ValidationResult("Page must be greater than 0", [nameof(Page)]);
            }

            if (PageSize < 1)
            {
                yield return new ValidationResult("PageSize must be greater than 0", [nameof(PageSize)]);
            }
        }
    }
}
