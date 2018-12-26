using Abstraction.Core.Attributes;

namespace SharedLibrary.Core.Attributes
{
    public class LocaleMessageCompare : LocaleCompare
    {
        public LocaleMessageCompare(string otherProperty) :
            base(otherProperty)
        {

        }

        public override string GetLocaleMessage(string name)
        {
            return string.Format(SharedLibrary.Core.Resources.Global.ValidationMessages.Compare, name, OtherPropertyDisplayName);
        }
    }
}