using UnityEngine;

public class IfPosithionMathc : MonoBehaviour
{
    [SerializeField] private GameObject[] mathGameObjects;
    [SerializeField] private GameObject hideObject;
    void Update()
    {
        for (int i = 0; i < mathGameObjects.Length; i++)
        {
            try
            {
                if (mathGameObjects[i].transform.position.x == mathGameObjects[i + 1].transform.position.x &&
                    mathGameObjects[i].transform.position.z == mathGameObjects[i + 1].transform.position.z)
                {
                    hideObject.SetActive(false);
                }
            }
            catch { }
        }
    }
}
