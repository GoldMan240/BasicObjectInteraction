using Code.Interactable;
using Code.Player;
using Code.Services.Interaction;
using TMPro;
using UnityEngine;
using Zenject;

namespace Code.UI
{
    public class InteractionTip : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _tipText;
        
        private IInteractionService _interactionService;

        [Inject]
        private void Construct(IInteractionService interactionService)
        {
            _interactionService = interactionService;
        }

        private void Awake()
        {
            _interactionService.OnHover += Show;
            _interactionService.OnLeave += Hide;
        }

        private void Show(IInteractable interactable)
        {
            _tipText.text = interactable.Tip;   
            gameObject.SetActive(true);
        }

        private void Hide() => 
            gameObject.SetActive(false);
    }
}