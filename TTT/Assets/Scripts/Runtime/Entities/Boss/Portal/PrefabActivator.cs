using UnityEngine;

public class PrefabActivator : MonoBehaviour
{
    [SerializeField] private GameObject prefabToActivate;

    public void ActivatePrefab()
    {
        if (prefabToActivate != null)
        {
            prefabToActivate.SetActive(true);
            Debug.Log("Prefab activated!");
        }
        else
        {
            Debug.LogError("Prefab is not assigned!");
        }
    }

}
