using System.Collections.Generic;
using UnityEngine;

public class SpikeObjectPool : MonoBehaviour
{
    private List<GameObject> _pooledObjects = new();

    [SerializeField] private GameObject _spikePrefab;

    [SerializeField] private int _poolSize = 10;

    [SerializeField] private Color _color1, _color2;

    private void Awake()
    {
        _pooledObjects.Clear();
        for (int i = 0; i < _poolSize; i++)
        {
            GameObject obj = Instantiate(_spikePrefab, transform);
            obj.GetComponent<SpriteRenderer>().color = (i % 2 == 0) ? _color1 : _color2;
            obj.SetActive(false);
            _pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        foreach (var obj in _pooledObjects)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }

        // Optionally, you can expand the pool if no inactive objects are available
        GameObject newObj = Instantiate(_spikePrefab, transform);
        newObj.SetActive(false);
        _pooledObjects.Add(newObj);
        return newObj;
    }

}
