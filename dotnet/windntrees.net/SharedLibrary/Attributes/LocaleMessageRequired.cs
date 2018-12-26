using Abstraction.Attributes;

namespace SharedLibrary.Attributes
{
    public class LocaleMessageRequired : LocaleRequired
    {
        public override string GetLocaleMessage(string name)
        {
            return string.Format(SharedLibrary.Resources.Global.ValidationMessages.RequiredField, name);
        }
    }
}