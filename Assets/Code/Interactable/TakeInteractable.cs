using Code.Interactor;
using DG.Tweening;
using UnityEngine;

namespace Code.Interactable
{
    public class TakeInteractable : MonoBehaviour, IInteractable
    {
        private const float Duration = 0.5f;

        public string Tip => "Take";

        public void Interact(IInteractor interactor)
        {
            if (interactor.HasInteractable) return;
            
            transform.parent = interactor.InteractableSlot;
            transform.DOLocalMove(Vector3.zero, Duration).SetEase(Ease.OutQuart);
            transform.DOLocalRotate(Vector3.zero, Duration).SetEase(Ease.OutQuart);
            
            interactor.SetInteractable(this);
        }
    }
}