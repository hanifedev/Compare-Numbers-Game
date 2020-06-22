using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CirclesManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] circles;

    void Start()
    {
        closeScale();
    }

    public void closeScale()
    {
        foreach(GameObject circle in circles)
        {
            circle.GetComponent<RectTransform>().localScale = Vector3.zero;
        }
    }

    public void openScale(int circle)
    {
        Debug.Log("circle : "+ circle.ToString());
        circles[circle].GetComponent<RectTransform>().DOScale(1, 0.3f);
        if(circle % 5 == 0)
        {
            closeScale();
        }
    }
}
