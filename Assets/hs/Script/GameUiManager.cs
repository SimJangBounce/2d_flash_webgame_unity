using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUiManager : MonoBehaviour
{
    [SerializeField] Toggle toggle;
    [SerializeField] Image icon;
    [SerializeField] Sprite onSprite;
    [SerializeField] Sprite offSprite;

    void Start()
    {
        if (SoundManager.Instance != null)
        {
            toggle.isOn = SoundManager.Instance.IsSoundOn;
            UpdateSoundUI(toggle.isOn);
        }

        toggle.onValueChanged.AddListener(OnToggleChanged);
    }

    void OnDestroy()
    {
        toggle.onValueChanged.RemoveListener(OnToggleChanged);
    }

    void OnToggleChanged(bool isOn)
    {
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.SetSound(isOn);
        }

        UpdateSoundUI(isOn);
    }

    void UpdateSoundUI(bool isOn)
    {
        if (icon != null)
            icon.sprite = isOn ? onSprite : offSprite;
    }

    public void LoadTitleScene()
    {
        SceneManager.LoadScene("hs_TitleScene");
    }
}