using UnityEngine;

public class ShowFirstHelp : MonoBehaviour
{
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        if (PlayerPrefs.GetInt("fs") == 0)
        {
            this.gameObject.SetActive(true);
            PlayerPrefs.SetInt("fs", 1);
        }
        else this.gameObject.SetActive(false);
    }
}
