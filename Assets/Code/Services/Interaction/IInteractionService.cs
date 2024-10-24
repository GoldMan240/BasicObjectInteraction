using System;
using Code.Interactable;

namespace Code.Services.Interaction
{
    public interface IInteractionService
    {
        event Action<IInteractable> OnHover;
        event Action OnLeave;
        event Action<IInteractable> OnInteract;
        void Hover(IInteractable interactable);
        void Leave();
        void Interact(IInteractable interactable);
    }
}