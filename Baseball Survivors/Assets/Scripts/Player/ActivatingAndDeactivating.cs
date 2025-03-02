using UnityEngine;

public class ActivatingAndDeactivating : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;

    public void ActivatingGameObject()
    {
        if(!_gameObject.activeInHierarchy)
        {
            _gameObject.SetActive(true);
        }
    }

    public void DeactivatingGameObject()
    {
        if (_gameObject.activeInHierarchy)
        {
            _gameObject.SetActive(false);
        }
    }
}
