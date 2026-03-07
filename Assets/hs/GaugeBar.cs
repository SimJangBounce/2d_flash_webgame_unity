using UnityEngine;
using UnityEngine.UI;

public class GaugeBar : MonoBehaviour
{
    public Image redFill;
    public Image blueFill;

    [Range(0f, 1f)]
    public float value = 0.5f;

    public void SetGaugeValue(float val)
    {
        value = Mathf.Clamp01(val);

        redFill.fillAmount = value;
        blueFill.fillAmount = 1f - value;
    }

    void Update() // 이건 테스트용. 나중에 주석처리 해주기.
    {
        SetGaugeValue(value);
    }
}
