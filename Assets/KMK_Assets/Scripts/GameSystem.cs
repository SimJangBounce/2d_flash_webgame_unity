using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameSystem : MonoBehaviour
{
    int round = 0;              // 현 라운드
    int totalRound = 2;         // 총 라운드 횟수
    public int TotalRound => totalRound;

    int winCount = 0;           // 승리 횟수
    int loseCount = 0;          // 패배 횟수
    bool isWin;

    [SerializeField] float restartDelay = 5f;
    float restartTime = 0f;
    bool prepareRestart = true;
    [SerializeField] Image countDown;
    [SerializeField] List<Sprite> countDownSprites;

    [SerializeField] List<GameObject> RoundImages;

    [SerializeField] List<GameObject> RoundUiImages;

    public GameObject resultObject;
    public GameObject gaugeObject;

    public bool CheckOver(float gaugeValue, ref int _round)
    {
        if (gaugeValue == 1f) {
            round++;
            winCount++;
        }
        else if (gaugeValue == 0f) {
            round++;
            loseCount++;
        }

        if (round > totalRound)     // 게임 종료
        {
            isWin = (winCount > loseCount) ? true : false;

            resultObject.SetActive(true);
            resultObject.GetComponent<ResultShow>().ShowResult(isWin);

            return true;
        }
        else if(round != _round)    // 라운드 종료
        {
            _round = round;
            prepareRestart = true;
            //countDown
            return true;
        }
        return false;               // 게임 진행
    }

    private void Update()
    {
        if (!prepareRestart) return;

        restartTime += Time.deltaTime;
        if ((int)restartTime == 0)
        {
            RoundImages[round].SetActive(true);
            if (round > 0)
            {
                RoundUiImages[round - 1].SetActive(false);
            }
        }
        else if ((int)restartTime == 1)
        {
            RoundImages[round].SetActive(false);
            RoundUiImages[round].SetActive(true);

            countDown.transform.gameObject.SetActive(true);    // 카운트다운 이미지 활성화
            countDown.sprite = countDownSprites[0];
        }
        else if ((int)restartTime == 2)
        {
            countDown.sprite = countDownSprites[1];
        }
        else if ((int)restartTime == 3)
        {
            countDown.sprite = countDownSprites[2];
        }
        else if ((int)restartTime == 4)
        {
            countDown.sprite = countDownSprites[3];
        }
        if (restartTime >= restartDelay)
        {
            prepareRestart = false;
            restartTime = 0f;
            gaugeObject.GetComponent<GaugeSystem>().Restart();
            countDown.transform.gameObject.SetActive(false);    // 카운트다운 이미지 비활성화
        }
    }
}
