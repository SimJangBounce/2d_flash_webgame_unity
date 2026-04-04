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
        toggle.onValueChanged.AddListener(OnToggleChanged);
        OnToggleChanged(toggle.isOn);
    }

    void OnToggleChanged(bool isOn)
    {
        AudioListener.volume = isOn ? 1f : 0f;
        icon.sprite = isOn ? onSprite : offSprite;
    }


    public void LoadTitleScene()
    {
        SceneManager.LoadScene("hs_TitleScene");
    }
}
