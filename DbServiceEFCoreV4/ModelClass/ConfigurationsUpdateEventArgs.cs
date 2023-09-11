using System;

namespace detectVideoApp
{
    public class ConfigurationsUpdateEventArgs : EventArgs
    {
        #region Members
        public bool IsCreated { get; set; }
        #endregion
        #region Constructors
        public ConfigurationsUpdateEventArgs()
        {
            IsCreated = false;
        }
        public ConfigurationsUpdateEventArgs(bool isCreated)
        {
            this.IsCreated = isCreated;
        }
        #endregion
    }
}
