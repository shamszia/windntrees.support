using Abstraction.Repository;
using SharedLibrary.Resources.Global;

namespace Application.Repositories
{
    public class LocaleMessages : MessageRepository
    {
        public LocaleMessages()
        {
        }

        public override string GetValidationCompareMessage()
        {
            return ValidationMessages.Compare;
        }

        public override string GetValidationRequiredMessage()
        {
            return ValidationMessages.Required;
        }

        public override string GetValidationDeletionFailureMessage()
        {
            return ValidationMessages.DeletionFailure;
        }

        public override string GetValidationStringMinMaxLengthMessage()
        {
            return ValidationMessages.StringMinMaxLength;
        }
    }
}
