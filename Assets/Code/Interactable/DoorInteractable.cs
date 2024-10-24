using Code.Interactor;
using DG.Tweening;
using UnityEngine;

namespace Code.Interactable
{
    public class DoorInteractable : MonoBehaviour, IInteractable
    {
        [SerializeField] private Transform _doorLeftTransform;
        [SerializeField] private Transform _doorRightTransform;
        
        private const float Angle = 90f;
        private const float Duration = 1f;
        private bool _isOpen;
        
        public string Tip => _isOpen ? "Close" : "Open";
        public Transform Transform => transform;

        public void Interact(IInteractor interactor)
        {
            if (_isOpen)
                Close();
            else
                Open();
        }

        private void Close()
        {
            _doorLeftTransform.DOLocalRotate(Vector3.zero, Duration).SetEase(Ease.OutQuart);
            _doorRightTransform.DOLocalRotate(Vector3.zero, Duration).SetEase(Ease.OutQuart);
            
            _isOpen = false;
        }

        private void Open()
        {
            _doorLeftTransform.DOLocalRotate(new Vector3(0, -Angle, 0), Duration).SetEase(Ease.OutQuart);
            _doorRightTransform.DOLocalRotate(new Vector3(0, Angle, 0), Duration).SetEase(Ease.OutQuart);
            
            _isOpen = true;
        }
    }
}