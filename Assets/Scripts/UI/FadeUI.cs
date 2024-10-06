using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeUI : MonoBehaviour
{
    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void FadeUIOut(float _second)
    {
        StartCoroutine(FadeOut(_second));
    }
    
    
    public void FadeUIIn(float _second)
    {
        StartCoroutine(FadeIn(_second));
    }

    IEnumerator FadeOut(float _second)
    {
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.alpha = 1;
        while (_canvasGroup.alpha > 0)
        {
            _canvasGroup.alpha -= Time.unscaledDeltaTime / _second; 
            yield return null;
        }

        yield return null;
    }
    
    IEnumerator FadeIn(float _second)
    {

        _canvasGroup.alpha = 1;
        while (_canvasGroup.alpha < 1)
        {
            _canvasGroup.alpha -= Time.unscaledDeltaTime / _second; 
            yield return null;
        }
        
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;

        yield return null;
    }
}
