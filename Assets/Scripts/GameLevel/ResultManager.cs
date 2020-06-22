using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    [SerializeField]
    private Text trueCountText, falseCountText, pointText;

    int pointTime = 10;
    bool isTimeOver;

    int totalPoint, increaseAmount, textValue;

    private void Awake()
    {
        isTimeOver = true;
    }

    public void showResults(int trueCount, int falseCount, int point)
    {
        trueCountText.text = trueCount.ToString();
        falseCountText.text = falseCount.ToString();
        pointText.text = point.ToString();
        totalPoint = point;
        increaseAmount = totalPoint / 10;
        StartCoroutine(writePoint());
    }

    IEnumerator writePoint()
    {
        while(isTimeOver)
        {
            yield return new WaitForSeconds(0.1f);
            textValue += increaseAmount;
            if(textValue >= totalPoint)
            {
                textValue = totalPoint;
            }

            pointText.text = textValue.ToString();

            if(pointTime <= 0)
            {
                isTimeOver = false;
            }

            pointTime--;
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MenuLevel");
    }

    public void playAgain()
    {
        SceneManager.LoadScene("GameLevel");
    }
}
