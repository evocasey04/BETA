using UnityEngine;

public class OpenWebsite : MonoBehaviour
{
    public void OpenURL(string url)
    {
        Application.OpenURL(url);
    }
}

