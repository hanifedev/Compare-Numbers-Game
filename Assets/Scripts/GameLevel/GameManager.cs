using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject timePanel;

    [SerializeField]
    private GameObject pausePanel;

    [SerializeField]
    private GameObject resultPanel;

    [SerializeField]
    private GameObject collectPointImage;

    [SerializeField]
    private GameObject selectMaxNumberImage;

    [SerializeField]
    private GameObject firstSquareButton;

    [SerializeField]
    private GameObject secondSquareButton;

    [SerializeField]
    private Text firstText, secondText, scoreText;

    [SerializeField]
    private AudioClip startSound, trueSound, falseSound;

    private TimerManager timerManager;

    private CirclesManager circlesManager;

    private TrueFalseManager trueFalseManager;

    private ResultManager resultManager;

    private AdmobManager admobManager;

    private AudioSource audioSource;

    int gameCount, gameCounter;

    int firstValue, secondValue;

    int maxNumber;

    int buttonValue;

    int totalScorePoint, increasePoint;

    int trueCount, falseCount;

    private void Awake()
    {
        timerManager = Object.FindObjectOfType<TimerManager>();
        circlesManager = Object.FindObjectOfType<CirclesManager>();
        admobManager = Object.FindObjectOfType<AdmobManager>();
        trueFalseManager = Object.FindObjectOfType<TrueFalseManager>();
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        gameCount = 0;
        gameCounter = 0;
        totalScorePoint = 0;
        updateScene();
    }

    void updateScene()
    {
        selectMaxNumberImage.GetComponent<CanvasGroup>().DOFade(0f,1f);
        timePanel.GetComponent<CanvasGroup>().DOFade(1f,1f);
        collectPointImage.GetComponent<CanvasGroup>().DOFade(1f,1f);
        firstSquareButton.GetComponent<RectTransform>().DOLocalMoveX(0,0.7f).SetEase(Ease.OutBack);
        secondSquareButton.GetComponent<RectTransform>().DOLocalMoveX(0,0.7f).SetEase(Ease.OutBack);
        startGame();
    }

    
    public void startGame()
    {
        audioSource.PlayOneShot(startSound);
        collectPointImage.GetComponent<CanvasGroup>().DOFade(0, .2f);
        selectMaxNumberImage.GetComponent<CanvasGroup>().DOFade(1, .2f);
        checkGameCount();
        timerManager.startTimer();
        admobManager.showBanner();
    }

    //oyunun kaçıncı oyun olduğunu kontrol eden fonksiyon
    //Sayaça göre yapılacak olan işlemler belirlenmektedir
    void checkGameCount()
    {
        if(gameCounter < 5)
        {
            gameCount = 1;
            increasePoint = 25;
        }else if(gameCounter >= 5 && gameCounter < 10)
        {
            gameCount = 2;
            increasePoint = 50;
        }else if(gameCounter >= 10 && gameCounter < 15)
        {
            gameCount = 3;
            increasePoint = 75;
        }else if(gameCounter >= 15 && gameCounter < 20)
        {
            gameCount = 4;
            increasePoint = 100;
        }else if(gameCounter >= 20 && gameCounter < 25){
            gameCount = 5;
            increasePoint = 125;
        }else {
            gameCount = Random.Range(1,6);
            increasePoint = 150;
        }

        switch(gameCount)
        {
            case 1:
                firstFunction();
                break;
            case 2:
                secondFunction();
                break;
            case 3:
                thirthFunction(); 
                break;   
            case 4:
                fourthFunction();
                break;
            case 5:
                fifthFunction();
                break;        
        }
    }

    void firstFunction()
    {
        int random = Random.Range(1,50);
        if(random <= 25)
        {
            firstValue = Random.Range(2,50);
            secondValue = firstValue + Random.Range(1,15);
        }
        else{
            firstValue = Random.Range(2,50);
            secondValue = Mathf.Abs(firstValue - Random.Range(1,15));
        }

        if(firstValue > secondValue)
        {
            maxNumber = firstValue;
        }else{
            maxNumber = secondValue;
        }

        if(firstValue == secondValue)
        {
            secondFunction();
            return;
        }

        firstText.text = firstValue.ToString();
        secondText.text = secondValue.ToString();
    }

    void secondFunction()
    {
        int firstNumber = Random.Range(1, 10);
        int secondNumber = Random.Range(1, 20);
        int thirdNumber = Random.Range(1, 10);
        int fourthNumber = Random.Range(1, 20);
        firstValue = firstNumber + secondNumber;
        secondValue = thirdNumber + fourthNumber;
        if(firstValue > secondValue)
        {
            maxNumber = firstValue;
        }
        else if(firstValue < secondValue)
        {
            maxNumber = secondValue;
        }

        if(firstValue == secondValue)
        {
            secondFunction();
            return;
        }

        firstText.text = firstNumber + " + " + secondNumber;
        secondText.text = thirdNumber + " + " + fourthNumber;
    }

    void thirthFunction()
    {
         int firstNumber = Random.Range(11, 30);
        int secondNumber = Random.Range(1, 11);
        int thirdNumber = Random.Range(11, 40);
        int fourthNumber = Random.Range(1, 11);
        firstValue = firstNumber - secondNumber;
        secondValue = thirdNumber - fourthNumber;
        if(firstValue > secondValue)
        {
            maxNumber = firstValue;
        }
        else if(firstValue < secondValue)
        {
            maxNumber = secondValue;
        }

        if(firstValue == secondValue)
        {
            thirthFunction();
            return;
        }

        firstText.text = firstNumber + " - " + secondNumber;
        secondText.text = thirdNumber + " - " + fourthNumber;
    }

    void fourthFunction()
    {
        int firstNumber = Random.Range(1, 10);
        int secondNumber = Random.Range(1, 10);
        int thirdNumber = Random.Range(1, 10);
        int fourthNumber = Random.Range(1, 10);
        firstValue = firstNumber * secondNumber;
        secondValue = thirdNumber * fourthNumber;
        if(firstValue > secondValue)
        {
            maxNumber = firstValue;
        }
        else if(firstValue < secondValue)
        {
            maxNumber = secondValue;
        }

        if(firstValue == secondValue)
        {
            fourthFunction();
            return;
        }

        firstText.text = firstNumber + " x " + secondNumber;
        secondText.text = thirdNumber + " x " + fourthNumber;
    }

    void fifthFunction()
    {
        //bölen sayı
        int dividing1 = Random.Range(2, 10);
        firstValue = Random.Range(2, 10);
        //bölünen sayı
        int divided1 = dividing1 * firstValue;

         //bölen sayı
        int dividing2 = Random.Range(2, 10);
        secondValue = Random.Range(2, 10);
        //bölünen sayı
        int divided2 = dividing2 * secondValue;


       if(firstValue > secondValue)
        {
            maxNumber = firstValue;
        }
        else if(firstValue < secondValue)
        {
            maxNumber = secondValue;
        }

        if(firstValue == secondValue)
        {
            fifthFunction();
            return;
        }

        firstText.text = divided1 + " / " + dividing1;
        secondText.text = divided2 + " / " + dividing2;
    }

    //tıklanan butona göre doğruya mı yanlışa mı tıklandığını kontrol eden fonksiyon
    public void assignButtonValue(string buttonName)
    {
        if(buttonName == "FirstSquare")
        {
            buttonValue = firstValue;
        }
        else
        {
            buttonValue = secondValue;
        }
        
        if(buttonValue == maxNumber)
        {
            trueFalseManager.openScale(true);
            circlesManager.openScale(gameCounter % 5);
            gameCounter++;
            totalScorePoint += increasePoint;
            scoreText.text = totalScorePoint.ToString();
            trueCount++;
            audioSource.PlayOneShot(trueSound);
            checkGameCount();
        }
        else
        {
            trueFalseManager.openScale(false);
            decreaseCounter();
            falseCount++;
            audioSource.PlayOneShot(falseSound);
            checkGameCount();
        }
    }

    public void endGame()
    {
        resultPanel.SetActive(true);
        resultManager = Object.FindObjectOfType<ResultManager>();
        resultManager.showResults(trueCount,falseCount,totalScorePoint);
    }

    //yanlış butona tıklandığında kullanıcı bir alt seviyeye düşecek
    public void decreaseCounter()
    {
        gameCounter-=(gameCounter % 5 + 5);
        if(gameCounter < 0)
        {
            gameCounter = 0;
        }

        circlesManager.closeScale();
    }

    public void openPausePanel()
    {
        pausePanel.SetActive(true);
    }
}
