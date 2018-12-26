using Abstraction.Core.Attributes;

namespace SharedLibrary.Core.Attributes
{
    public class LocaleMessageRequired : LocaleRequired
    {
        public override string GetLocaleMessage(string name)
        {
            return string.Format(SharedLibrary.Core.Resources.Global.ValidationMessages.RequiredField, name);
        }
    }
}