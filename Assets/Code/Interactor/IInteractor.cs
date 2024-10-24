using Code.Interactable;
using UnityEngine;

namespace Code.Interactor
{
    public interface IInteractor
    {
        Transform InteractableSlot { get; }
        bool HasInteractable { get; }
        void SetInteractable(IInteractable interactable);
        IInteractable GetInteractable();
    }
}