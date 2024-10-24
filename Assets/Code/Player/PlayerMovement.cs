using Code.Services.Input;
using UnityEngine;
using Zenject;

namespace Code.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private CharacterController _controller;
        [SerializeField] private float _speed;
        
        private IInputService _inputService;

        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }
        
        private void FixedUpdate()
        {
            MoveOnDirection();
        }

        private void MoveOnDirection()
        {
            Vector2 input = _inputService.Axis;
            Vector3 move = transform.right * input.x + transform.forward * input.y;
            move.Normalize();
            _controller.Move(move * (_speed * Time.fixedDeltaTime));
        }
    }
}