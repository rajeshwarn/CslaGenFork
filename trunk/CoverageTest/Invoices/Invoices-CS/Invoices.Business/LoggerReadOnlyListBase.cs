using System;
using Csla;

namespace Invoices.Business
{
    public abstract partial class LoggerReadOnlyListBase<T, C> : ReadOnlyListBase<T, C>, IListLog
        where T : LoggerReadOnlyListBase<T, C>, IListLog
        where C : LoggerReadOnlyBase<C>
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
