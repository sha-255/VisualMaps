using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text counterText;
    private int counter = 0;
    public void AddCount()
    {
        counter++;
        counterText.text = "Количество очков: " + counter.ToString();
    }
}
