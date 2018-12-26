using Abstraction.Attributes;

namespace SharedLibrary.Attributes
{
    public class LocaleMessageStringLength : LocaleStringLength
    {
        public LocaleMessageStringLength(int maximumLength)
            : base(maximumLength)
        {

        }

        public override string GetLocaleMessage(string name)
        {   
            return string.Format(SharedLibrary.Resources.Global.ValidationMessages.StringMinMaxLength, name, MinimumLength, MaximumLength);
        }
    }
}