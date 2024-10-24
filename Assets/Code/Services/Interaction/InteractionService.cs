using System;
using Code.Interactable;

namespace Code.Services.Interaction
{
    public class InteractionService : IInteractionService
    {
        public event Action<IInteractable> OnHover;
        public event Action OnLeave;
        public event Action<IInteractable> OnInteract;

        public void Hover(IInteractable interactable) =>
            OnHover?.Invoke(interactable);
        
        public void Leave() =>
            OnLeave?.Invoke();
        
        public void Interact(IInteractable interactable) =>
            OnInteract?.Invoke(interactable);
    }
}