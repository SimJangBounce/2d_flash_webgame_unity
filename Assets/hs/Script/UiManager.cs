using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] GameObject tutorialImage;

    [SerializeField] Toggle toggle;
    [SerializeField] Image icon;
    [SerializeField] Sprite onSprite;
    [SerializeField] Sprite offSprite;

    void Start()
    {
        toggle.isOn = SoundManager.Instance.IsSoundOn;
        UpdateSoundUI(toggle.isOn);

        toggle.onValueChanged.AddListener(OnToggleChanged);
    }

    void OnDestroy()
    {
        toggle.onValueChanged.RemoveListener(OnToggleChanged);
    }

    void OnToggleChanged(bool isOn)
    {
        SoundManager.Instance.SetSound(isOn);
        UpdateSoundUI(isOn);
    }

    void UpdateSoundUI(bool isOn)
    {
        icon.sprite = isOn ? onSprite : offSprite;
    }

    public void ShowTutoImage()
    {
        tutorialImage.SetActive(true);
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("hs_GameScene");
    }
}