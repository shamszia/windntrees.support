using System;

namespace ApplicationForms.ParentForms
{
    /// <summary>
    /// Entity persistance event arguments.
    /// </summary>
    public class EntityPersistanceEventArgument : EventArgs
    {
        public EntityPersistanceState EntityPersistanceState { get; set; }
    }
}
