using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private Transform head;

    [SerializeField]
    private Transform startButton;

    void Start()
    {
        head.transform.GetComponent<RectTransform>().DOLocalMoveX(0f,1f).SetEase(Ease.OutBack);
        startButton.transform.GetComponent<RectTransform>().DOLocalMoveY(-260f,1f).SetEase(Ease.OutBack);
    }

    public void startGame()
    {
        SceneManager.LoadScene("GameLevel");
    }
}
