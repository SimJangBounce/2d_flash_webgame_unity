using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GaugeBar : MonoBehaviour
{
    int round = 0;
    int winCount = 0;
    int loseCount = 0;

    [SerializeField] List<float> incrementPowers;
    [SerializeField] List<float> decrementPowers;

    float incrementPower;
    float decrementPower;

    public Image redFill;
    public Image blueFill;
    public Image Player;
    public Image Enemy;
    public Sprite[] playerImages;
    public Sprite[] enemyImages;

    [UnityEngine.Range(0f, 1f)]
    public float value = 0.5f;
    [SerializeField] List<float> gaugeRanges;

    void CheckOver()
    {
        if (value == 0.0f)
        {
            loseCount++;
            round++;
        }
        else if (value == 1.0f)
        {
            winCount++;
            round++;
        }

        if (round > 2)
        {
            
        }
    }
    void SetGaugeValue(float val)
    {
        value = Mathf.Clamp01(val);

        redFill.fillAmount = value;
        blueFill.fillAmount = 1f - value;

        CheckOver();
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
            value += incrementPower * Time.deltaTime;    // 증가
        }

        SetGaugeValue(value);                            // value 관련 정보 갱신
    }

    private void Awake()
    {
        incrementPower = incrementPowers[0];
        decrementPower = decrementPowers[0];
    }

    void Update() // 이건 테스트용. 나중에 주석처리 해주기.
    {
        UpdateValue();
    }
}
