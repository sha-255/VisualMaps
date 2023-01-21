using UnityEngine;

public class QuesthionCounter : MonoBehaviour
{
    [SerializeField] private GameObject quest;
    private int count;
    [SerializeField] private int maxCount;
    public void AddCount()
    {
        count++;
        if (count >= maxCount)
        {
            quest.SetActive(true);
            count = 0;
        }
    }
}
