using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene("hs_GameScene");
    }
}
