using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TrueFalseManager : MonoBehaviour
{
    [SerializeField]
    private GameObject trueIcon, falseIcon;

    void Start()
    {
        closeScale();
    }

    public void openScale(bool isTrueOrFalse)
    {
        if(isTrueOrFalse)
        {
            trueIcon.GetComponent<RectTransform>().DOScale(1,0.2f);
            falseIcon.GetComponent<RectTransform>().localScale = Vector3.zero;
        }
        else
        {
            falseIcon.GetComponent<RectTransform>().DOScale(1,0.2f);
            trueIcon.GetComponent<RectTransform>().localScale = Vector3.zero;
        }

        Invoke("closeScale", 0.5f);
    }

    void closeScale()
    {
        trueIcon.GetComponent<RectTransform>().localScale = Vector3.zero;
        falseIcon.GetComponent<RectTransform>().localScale = Vector3.zero;
    }
}
