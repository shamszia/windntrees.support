using System;

namespace ApplicationForms
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
