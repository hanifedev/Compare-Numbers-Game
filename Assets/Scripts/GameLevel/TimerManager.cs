using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    [SerializeField]
    private Text timeText;

    int time;

    bool timeCount;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }

    void Start()
    {
        time = 90;
        timeCount = true;    
    }

    public void startTimer()
    {    
        StartCoroutine(timeRoutine());
    }

    IEnumerator timeRoutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);
            if(time < 10)
            {
                timeText.text = "0" + time.ToString();
            }
            else{
                timeText.text = time.ToString();
            }

            if(time <= 0)
            {
                timeCount = false;
                timeText.text = "";
                gameManager.endGame();
            }

            time--;
        }
    }
}
