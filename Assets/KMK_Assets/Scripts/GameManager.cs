using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance = null;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PauseFromWeb()
    {
        Time.timeScale = 0f;
        AudioListener.pause = true;
    }

    public void ResumeFromWeb()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }
}
