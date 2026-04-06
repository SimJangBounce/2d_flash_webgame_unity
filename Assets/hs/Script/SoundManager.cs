using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    public bool IsSoundOn { get; private set; } = true;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            ApplySound();
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void SetSound(bool isOn)
    {
        IsSoundOn = isOn;
        ApplySound();

        PlayerPrefs.SetInt("SoundOn", isOn ? 1 : 0);
        PlayerPrefs.Save();
    }

    void ApplySound()
    {
        AudioListener.volume = IsSoundOn ? 1f : 0f;
    }
}