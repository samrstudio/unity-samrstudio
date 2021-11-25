namespace SamrStudio.Core.Events
{
    interface IEventBase<T>
    {
        public void RaiseEvent(T data);
    }
}
