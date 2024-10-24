using System;
using System.Collections.Generic;
using System.Linq;
using Code.Interactor;
using DG.Tweening;
using UnityEngine;

namespace Code.Interactable
{
    public class ContainerInteractable : MonoBehaviour, IInteractable
    {
        private const float Duration = 0.5f;
        
        [SerializeField] private List<Transform> _itemSlots; 
        
        private readonly Dictionary<Transform, IInteractable> _slotByInteractables = new();
        private bool HasEmptySlot => _slotByInteractables.ContainsValue(null);
        private bool IsAllSlotsEmpty => _slotByInteractables.All(pair => pair.Value == null);

        public string Tip => GetTip();
        public Transform Transform => transform;

        private void Awake()
        {
            foreach (Transform itemSlot in _itemSlots) 
                _slotByInteractables[itemSlot] = null;
        }

        public void Interact(IInteractor interactor)
        {
            if (interactor.HasInteractable)
                TryPut(interactor);
            else
                TryTake(interactor);
        }

        private void TryPut(IInteractor interactor)
        {
            if (!HasEmptySlot) return;
                
            Transform emptySlot = GetEmptySlot();
            IInteractable interactable = interactor.GetInteractable();
            SnapTo(emptySlot, interactable);
                
            if (interactable is IMightHaveParent mightHaveParent)
                mightHaveParent.SetParent(this);
                
            _slotByInteractables[emptySlot] = interactable;
        }

        private void TryTake(IInteractor interactor)
        {
            if (IsAllSlotsEmpty) return;
                
            IInteractable lastInteractable = GetLastInteractable();
            interactor.SetInteractable(lastInteractable);
            SnapTo(interactor.InteractableSlot, lastInteractable);

            if (lastInteractable is IMightHaveParent mightHaveParent)
                mightHaveParent.RemoveParent();
        }

        private static void SnapTo(Transform slot, IInteractable interactable)
        {
            interactable.Transform.parent = slot;
            interactable.Transform.DOLocalMove(Vector3.zero, Duration).SetEase(Ease.OutQuart);
            interactable.Transform.DOLocalRotate(Vector3.zero, Duration).SetEase(Ease.OutQuart);
        }

        private Transform GetEmptySlot()
        {
            return _itemSlots.FirstOrDefault(slot => _slotByInteractables[slot] == null);
        }

        private IInteractable GetLastInteractable()
        {
            IInteractable lastInteractable = _slotByInteractables.Values.Last(interactable => interactable != null);
            _slotByInteractables[_slotByInteractables.First(pair => pair.Value == lastInteractable).Key] = null;
            return lastInteractable;
        }

        private string GetTip()
        {
            return HasEmptySlot ? "Put" : "Take";
        }
    }
}