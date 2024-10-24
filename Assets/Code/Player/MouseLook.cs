using Code.Services.Input;
using UnityEngine;
using Zenject;

namespace Code.Player
{
    public class MouseLook : MonoBehaviour
    {
        [SerializeField] private float _mouseSensitivity = 100f;
        [SerializeField] private Transform _playerBody;
        
        private const float MaxRotationAngleX = 90f;
        private IInputService _inputService;
        private float _xRotation;

        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }
        
        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        
        private void Update()
        {
            float mouseX = _inputService.MouseAxis.x * Time.deltaTime * _mouseSensitivity;
            float mouseY = _inputService.MouseAxis.y * Time.deltaTime * _mouseSensitivity;
            
            _xRotation -= mouseY;
            _xRotation = Mathf.Clamp(_xRotation, -MaxRotationAngleX, MaxRotationAngleX);
            
            transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
            _playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}