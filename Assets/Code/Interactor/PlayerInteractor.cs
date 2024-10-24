using Code.Interactable;
using UnityEngine;

namespace Code.Interactor
{
    public class PlayerInteractor : MonoBehaviour, IInteractor
    {
        [SerializeField] private Transform _interactableSlot;
        
        public Transform InteractableSlot { get; private set; }
        public IInteractable Interactable { get; private set; }
        public bool HasInteractable { get; private set; }

        private void Awake()
        {
            InteractableSlot = _interactableSlot;
        }

        public void SetInteractable(IInteractable interactable)
        {
            if (HasInteractable) return;
            
            Interactable = interactable;
            HasInteractable = true;
        }

        public IInteractable GetInteractable()
        {
            if (!HasInteractable) return null;
            
            IInteractable interactable = Interactable;
            HasInteractable = false;
            Interactable = null;
            return interactable;
        }
    }
}