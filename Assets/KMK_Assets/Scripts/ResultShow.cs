using UnityEngine;

public class ResultShow : MonoBehaviour
{
    public GameObject Win;
    public GameObject Lose;

    //private void Awake()
    //{
    //    Win.SetActive(false);
    //    Lose.SetActive(false);
    //}

    public void ShowResult(bool isWin)
    {
        if (isWin)
        {
            Win.SetActive(true);
        }
        else
        {
            Lose.SetActive(true);
        }
    }
}
