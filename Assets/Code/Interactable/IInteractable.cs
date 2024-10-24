using Code.Interactor;
using UnityEngine;

namespace Code.Interactable
{
    public interface IInteractable
    {
        string Tip { get; }
        Transform Transform { get; }
        void Interact(IInteractor interactor);
    }
}