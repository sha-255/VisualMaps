using UnityEngine;

public class CollizionActive : MonoBehaviour
{
    [SerializeField] private GameObject onEnter;
    private void OnTriggerEnter
        (Collider other)
    {
        onEnter.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        onEnter.SetActive(false);
    }
}
