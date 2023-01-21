using UnityEngine;

public class BackButton : MonoBehaviour
{
    [SerializeField] private GameObject HideOnEscape;
    private void Update() => HideOnEscape.SetActive(Input.GetKeyDown(KeyCode.Escape));
}
