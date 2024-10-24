using System.Collections.Generic;
using UnityEngine;

namespace Code.Interactable
{
    public class FillContainer : MonoBehaviour
    {
        [SerializeField] private ContainerInteractable _container;
        [SerializeField] private List<TakeInteractable> _itemPrefabs;

        private void Start()
        {
            for (int i = 0; i < _container.SlotAmount; i++) 
                _container.ForcePut(Instantiate(GetRandomItemPrefab(), _container.Transform));
        }
        
        private TakeInteractable GetRandomItemPrefab() => 
            _itemPrefabs[UnityEngine.Random.Range(0, _itemPrefabs.Count)];
    }
}