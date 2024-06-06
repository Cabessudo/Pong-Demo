using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine;

public class RestartButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOKill();
        transform.DOScale(1.1f, 1).SetEase(Ease.Linear);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOKill();
        transform.DOScale(1, 1).SetEase(Ease.Linear);
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.DOScale(0, 1).SetEase(Ease.Linear).From();
    }
}
