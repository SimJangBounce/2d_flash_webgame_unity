using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonHoverImageChanger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image targetImage;

    public Sprite normalSprite;
    public Sprite hoverSprite;

    public void OnPointerEnter(PointerEventData eventData)
    {
        targetImage.sprite = hoverSprite;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        targetImage.sprite = normalSprite;
    }
}