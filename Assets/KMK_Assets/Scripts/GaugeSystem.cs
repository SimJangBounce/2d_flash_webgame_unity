using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GaugeSystem : MonoBehaviour
{
    public GameSystem gameSystem;                   // 게임 전체 flow 관리하는 오브젝트
    bool isOver = false;

    // 라운드 별 난이도 관련 변수
    [SerializeField] List<float> incrementPowers;   // 라운드 별 게이지 증가량
    [SerializeField] List<float> decrementPowers;   // 라운드 별 게이지 감소량
    float incrementPower;
    float decrementPower;
    int round = 0;

    public Image redFill;
    public Image blueFill;
    public Image Player;
    public Image Enemy;
    public Sprite[] playerImages;
    public Sprite[] enemyImages;

    [UnityEngine.Range(0f, 1f)]
    public float value = 0.5f;
    [SerializeField] float gaugeRange;

    enum State : int    // 캐릭터 sprite 상태
    {
        Safe = 0,
        Normal,
        Danger
    }

    void SetGaugeValue()
    {
        value = Mathf.Clamp01(value);

        redFill.fillAmount = value;
        blueFill.fillAmount = 1f - value;

        isOver = gameSystem.CheckOver(value, ref round);
    }

    bool TouchDown()
    {
        if (Input.touchCount > 0)
        {
            return Input.GetTouch(0).phase == UnityEngine.TouchPhase.Began; // 터치 시작 단계일 경우에만 true 반환 
        }
        return false;
    }

    void UpdateValue()
    {
        value -= decrementPower * Time.deltaTime;        // 감소
        if (Input.GetMouseButtonDown(0)||                // 마우스 왼클릭
            Input.GetMouseButtonDown(1)||                // 마우스 오클릭
            Input.GetKeyDown(KeyCode.Space)||            // 스페이스바
            TouchDown())                                 // 스크린 터치
        {
            value += incrementPower;    // 증가
            Debug.Log("버튼이 클릭되었습니다.");
        }

        SetGaugeValue();                            // value 관련 정보 갱신
    }

    void UpdateSprites()                                 // value 값에 따른 캐릭터 sprite 변화
    {
        if (value > 0.5 - gaugeRange && value < 0.5 + gaugeRange)       // 중간
        {
            Player.sprite = playerImages[(int)State.Normal];
            Enemy.sprite = enemyImages[(int)State.Normal];
        }
        else if (value <= 0.5 - gaugeRange)                             // 밀림
        {
            Player.sprite = playerImages[(int)State.Danger];
            Enemy.sprite = enemyImages[(int)State.Safe];
        }
        else if (value >= 0.5 + gaugeRange)                             // 우세
        {
            Player.sprite = playerImages[(int)State.Safe];
            Enemy.sprite = enemyImages[(int)State.Danger];
        }
    }

    void ChangeDifficulty()                             // 라운드 변화에 따른 난이도 변화
    {
        incrementPower = incrementPowers[round];
        decrementPower = decrementPowers[round];
    }

    private void Awake()
    {
        ChangeDifficulty();
    }

    void Update()
    {
        if (isOver) return;

        UpdateValue();
        UpdateSprites();
        ChangeDifficulty();
    }

    public void Restart()
    { 
        isOver = true;
        value = 0.5f;
        SetGaugeValue();
        Debug.Log("재시작");
    }
}
