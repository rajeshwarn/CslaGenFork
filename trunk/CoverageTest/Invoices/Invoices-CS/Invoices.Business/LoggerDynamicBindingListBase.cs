using System;
using Csla;

namespace Invoices.Business
{
    public abstract partial class LoggerDynamicBindingListBase<T> : DynamicBindingListBase<T>, IListLog
        where T : LoggerBusinessBase<T>
    {

        #region OnDeserialized actions

        /*/// <summary>
        /// This method is called on a newly deserialized object
        /// after deserialization is complete.
        /// </summary>
        protected override void OnDeserialized()
        {
            base.OnDeserialized();
            // add your custom OnDeserialized actions here.
        }*/

        #endregion

    }
}
