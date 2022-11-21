using System;

namespace ApplicationForms.Core
{
    /// <summary>
    /// Entity persistance event arguments.
    /// </summary>
    public class EntityPersistanceEventArgument : EventArgs
    {
        public EntityPersistanceState EntityPersistanceState { get; set; }
    }
}
