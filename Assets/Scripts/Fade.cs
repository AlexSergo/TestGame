using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    [SerializeField] private Image _fadeImage;

    private float _a = 0;
    private bool _isTimeLeft = false;
    private bool _isFadeIn = false;

    public void FadeIn()
    {
        _a = 0;
        _isTimeLeft = true;
        _isFadeIn = true;
    }

    public void FadeOut()
    {
        _a = 0;
        _isTimeLeft = true;
        _isFadeIn = false;
    }

    private void Update()
    {
        if (_isTimeLeft)
        {
            if (_isFadeIn)
                 StartCoroutine(FadeInOut(0.1f));
            else
                StartCoroutine(FadeInOut(-0.1f));
        }
    }

    private IEnumerator FadeInOut(float value)
    {
        _isTimeLeft = false;
        _fadeImage.color = new Color(0,0,0,_a + value);
        if (_fadeImage.color.a == 0 || _fadeImage.color.a == 1)
        {
            yield return null;
        }
        yield return new WaitForSeconds(0.01f);
        _a += value;
        _isTimeLeft = true;
    }
}
