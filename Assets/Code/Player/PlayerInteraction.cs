using System;
using Code.Interactable;
using Code.Interactor;
using Code.Services.Input;
using Code.Services.Interaction;
using UnityEngine;
using Zenject;

namespace Code.Player
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private PlayerInteractor _playerInteractor;
        
        private const float MaxDistance = 2f;
        private readonly LayerMask _targetLayerMask = 1 << 6;
        private IInputService _inputService;
        private IInteractionService _interactionService;

        [Inject]
        private void Construct(IInputService inputService, IInteractionService interactionService)
        {
            _inputService = inputService;
            _interactionService = interactionService;
        }
        
        private void Update()
        {
            if (Raycast(out RaycastHit hit) && IsInteractable(hit, out IInteractable interactable))
            {
                _interactionService.Hover(interactable);

                if (_inputService.IsInteractPressed == false) return;
                
                interactable.Interact(_playerInteractor);
                _interactionService.Interact(interactable);
            }
            else
                _interactionService.Leave();
        }

        private void OnDrawGizmos()
        {
            if (_camera == null) return;
            
            Gizmos.color = Color.red;
            Gizmos.DrawRay(_camera.transform.position, _camera.transform.forward * MaxDistance);
        }

        private bool Raycast(out RaycastHit hit) => 
            Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, MaxDistance, _targetLayerMask);

        private bool IsInteractable(RaycastHit hit, out IInteractable interactable) => 
            hit.collider.TryGetComponent(out interactable);
    }
}