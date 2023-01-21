using UnityEngine;

public class Compass : MonoBehaviour
{
    [SerializeField] private GameObject compass;
    [SerializeField] private GameObject[] targets;
    private int targetIndex;

    void Update()
    {
        compass.transform.position = transform.position;
        Vector3 direction = targets[targetIndex].transform.position - compass.transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        compass.transform.rotation = Quaternion.Lerp(compass.transform.rotation, rotation, 10*Time.deltaTime);
    }

    public void TargetChanger(int index) => targetIndex = index;
}
