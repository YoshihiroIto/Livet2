namespace Livet.Messaging
{
    public enum TransitionMode
    {
        /// <summary>
        /// Open new Window
        /// </summary>
        Normal,
        /// <summary>
        /// Open new Window as modal
        /// </summary>
        Modal,
        /// <summary>
        /// Open new Window or active window(same type of window)
        /// </summary>
        NewOrActive,
        /// <summary>
        /// unknown
        /// </summary>
        UnKnown
    }
}
