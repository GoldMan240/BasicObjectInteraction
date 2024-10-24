using UnityEngine;

namespace Code.Services.Input
{
    public interface IInputService
    {
        Vector2 Axis { get; }
        bool IsInteractPressed { get; }
        Vector2 MouseAxis { get; }
    }
}