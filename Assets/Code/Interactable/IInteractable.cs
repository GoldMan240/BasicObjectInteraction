using Code.Interactor;

namespace Code.Interactable
{
    public interface IInteractable
    {
        string Tip { get; }
        void Interact(IInteractor interactor);
    }
}