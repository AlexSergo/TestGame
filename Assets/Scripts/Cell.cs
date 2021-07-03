using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class Cell : MonoBehaviour
{
    private Symbol _symbol;
    private GameOver _gameOver;

    private void Awake()
    {
        transform.DOScale(1f, 0.5f).SetEase(Ease.OutElastic);
    }

    private void Start()
    {
        _symbol = GetComponentInChildren<Symbol>();
        _gameOver = FindObjectOfType<GameOver>();
    }
    private void OnMouseDown()
    {
        if (_symbol.IsCurrect)
            FinishLevel();
        else
            transform.DOPunchPosition(new Vector3(0.5f,0,0), 0.5f, 10, 1, false).SetEase(Ease.InBounce);
    }

    private void FinishLevel()
    {
        transform.DOScale(0, 0.3f).SetEase(Ease.OutCubic);
        StartCoroutine(_gameOver.FinishLevel());
    }
}
