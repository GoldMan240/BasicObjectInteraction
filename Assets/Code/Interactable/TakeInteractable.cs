using Code.Interactor;
using DG.Tweening;
using UnityEngine;

namespace Code.Interactable
{
    public class TakeInteractable : MonoBehaviour, IInteractable, IMightHaveParent
    {
        private const float Duration = 0.5f;

        public string Tip => "Take";
        public Transform Transform => transform;
        public IInteractable Parent { get; private set; }

        public void Interact(IInteractor interactor)
        {
            if (Parent != null)
            {
                Parent.Interact(interactor);
                return;
            }
            
            if (interactor.HasInteractable) return;
            
            transform.parent = interactor.InteractableSlot;
            transform.DOLocalMove(Vector3.zero, Duration).SetEase(Ease.OutQuart);
            transform.DOLocalRotate(Vector3.zero, Duration).SetEase(Ease.OutQuart);
            
            interactor.SetInteractable(this);
        }

        public void SetParent(IInteractable parent) => 
            Parent = parent;

        public void RemoveParent() => 
            Parent = null;
    }
}