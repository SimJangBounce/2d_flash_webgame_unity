using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    public bool IsSoundOn { get; private set; } = true;

    [Header("Audio Sources")]
    public AudioSource bgmSource;
    public AudioSource sfxSource;

    [Header("Audio Clips")]
    public AudioClip gameBgm;
    public AudioClip clickSound;
    public AudioClip roundStartSound;
    public AudioClip winSound;
    public AudioClip loseSound;

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

    //void Start()
    //{
    //    PlayBGM();
    //}

    void Update()
    {
        if (!IsSoundOn) return;

        if (Input.GetMouseButtonDown(0))
        {
            PlayClick();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayClick();
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

    // ======================
    // BGM
    // ======================
    public void PlayBGM()
    {
        if (gameBgm == null) return;

        bgmSource.clip = gameBgm;
        bgmSource.loop = true;
        bgmSource.volume = 0.3f;
        bgmSource.Play();
    }

    // ======================
    // SFX
    // ======================
    public void PlayClick()
    {
        if (clickSound != null)
            sfxSource.PlayOneShot(clickSound, 0.2f);
    }

    public void PlayRoundStart()
    {
        if (roundStartSound != null)
            sfxSource.PlayOneShot(roundStartSound);
    }

    public void PlayWin()
    {
        if (winSound != null)
            sfxSource.PlayOneShot(winSound);
    }

    public void PlayLose()
    {
        if (loseSound != null)
            sfxSource.PlayOneShot(loseSound);
    }
}