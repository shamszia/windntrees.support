using Abstraction.Attributes;

namespace SharedLibrary.Attributes
{
    public class LocaleMessageCompare : LocaleCompare
    {
        public LocaleMessageCompare(string otherProperty) :
            base(otherProperty)
        {

        }

        public override string GetLocaleMessage(string name)
        {
            return string.Format(SharedLibrary.Resources.Global.ValidationMessages.Compare, name, OtherPropertyDisplayName);
        }
    }
}