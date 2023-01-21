using UnityEngine;
using UnityEngine.UI;

public class InteractableButton : MonoBehaviour
{
    private bool isInteracyible = true;
    private Button button;
    void Start()
    {
        button = GetComponent<Button>();
    }
    void Update()
    {
        button.interactable = isInteracyible ? true : false;
    }

    public void isInt(bool Interacyible) => isInteracyible = Interacyible;
}
