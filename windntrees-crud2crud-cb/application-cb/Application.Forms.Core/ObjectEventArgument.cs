using System;

namespace ApplicationForms.Core
{
    public class ObjectEventArgument : EventArgs
    {
        public object Value { get; set; }

        public ObjectEventArgument()
        {
        }

        public ObjectEventArgument(object parameter)
        {
            Value = parameter;
        }
    }
}
