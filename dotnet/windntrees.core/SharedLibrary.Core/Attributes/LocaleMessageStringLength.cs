using Abstraction.Core.Attributes;

namespace SharedLibrary.Core.Attributes
{
    public class LocaleMessageStringLength : LocaleStringLength
    {
        public LocaleMessageStringLength(int maximumLength)
            : base(maximumLength)
        {

        }

        public override string GetLocaleMessage(string name)
        {   
            return string.Format(SharedLibrary.Core.Resources.Global.ValidationMessages.StringMinMaxLength, name, MinimumLength, MaximumLength);
        }
    }
}