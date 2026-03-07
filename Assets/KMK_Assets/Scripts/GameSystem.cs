using Unity.VisualScripting;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    int round = 0;              // 현 라운드
    int totalRound = 2;         // 총 라운드 횟수
    public int TotalRound => totalRound;

    int winCount = 0;           // 승리 횟수
    int loseCount = 0;          // 패배 횟수
    bool isWin;

    [SerializeField] float restartDelay = 3f;
    float restartTime = 0f;
    bool prepareRestart = false;

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
            return true;
        }
        return false;       // 게임 진행
    }

    private void Update()
    {
        if (!prepareRestart) return;

        restartTime += Time.deltaTime;
        if (restartTime >= restartDelay)
        {
            prepareRestart = false;
            restartTime = 0f;
            gaugeObject.GetComponent<GaugeSystem>().Restart();
        }
    }
}
