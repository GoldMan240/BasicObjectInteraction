namespace Code.Interactable
{
    public interface IMightHaveParent
    {
        IInteractable Parent { get; }
        void SetParent(IInteractable parent);
        void RemoveParent();
    }
}