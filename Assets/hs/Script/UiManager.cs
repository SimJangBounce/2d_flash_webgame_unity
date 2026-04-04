using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    [SerializeField] GameObject tutorialImage;

    public void ShowTutoImage()
    {
        tutorialImage.SetActive(true);
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("hs_GameScene");
    }
}
