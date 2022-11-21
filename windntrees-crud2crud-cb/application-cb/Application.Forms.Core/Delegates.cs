using System;
using System.Collections.Generic;

namespace ApplicationForms.Core
{
    /// <summary>
    /// No parameter delegate.
    /// </summary>
    public delegate void NoParamDelegate();
    /// <summary>
    /// Object parameter delegate.
    /// </summary>
    /// <param name="obj"></param>
    public delegate void ObjectParamDelegate(object parameter);
    /// <summary>
    /// Object parameter event.
    /// </summary>
    /// <param name="source"></param>
    /// <param name="eventArgs"></param>
    public delegate void ObjectParamEventDelegate(object source, ObjectEventArgument eventArgs);
    /// <summary>
    /// Boolean (bool) parameter delegate.
    /// </summary>
    /// <param name="param"></param>
    public delegate void BoolParamDelegate(bool parameter);
    /// <summary>
    /// List parameter delegate.
    /// </summary>
    /// <param name="obj"></param>
    public delegate void ListParamDelegate(List<Object> list);
}
