using UnityEngine;

public class VisibleCompass : MonoBehaviour
{
    [SerializeField] private GameObject compass;
    //void OnBecameVisible()
    //{
    //    compass.SetActive(false);
    //}

    //void OnBecameInvisible()
    //{
    //    compass.SetActive(true);
    //}
    private void Update()
    {
        if (this.GetComponent<Renderer>().isVisible)
        {
            compass.SetActive(false);
        }
        else
        {
            compass.SetActive(true);
        }
    }
}
