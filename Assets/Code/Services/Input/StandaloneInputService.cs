using UnityEngine;

namespace Code.Services.Input
{
    public class StandaloneInputService : IInputService
    {
        private const string HorizontalAxisName = "Horizontal";
        private const string VerticalAxisName = "Vertical";

        public Vector2 Axis => 
            new(UnityEngine.Input.GetAxisRaw(HorizontalAxisName), UnityEngine.Input.GetAxisRaw(VerticalAxisName));
        
        public Vector2 MouseAxis =>
            new(UnityEngine.Input.GetAxisRaw("Mouse X"), UnityEngine.Input.GetAxisRaw("Mouse Y"));

        public bool IsInteractPressed =>
            UnityEngine.Input.GetKeyDown(KeyCode.E);
    }
}