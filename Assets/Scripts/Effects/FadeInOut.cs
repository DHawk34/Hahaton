using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class FadeInOut : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    private bool fadeIn = false;
    private bool fadeOut = false;
    private bool fadeInOut = false;

    [SerializeField]
    private float fadeInTime = 1;

    [SerializeField]
    private float fadeOutTime = 1;

    [SerializeField]
    private float sleepTime = 1;

    private float sleepTimeBackup = 1;

    public Action FadeInEnded;
    public Action FadeOutEnded;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        sleepTimeBackup = sleepTime;
    }

    private void Update()
    {
        if (fadeIn)
        {
            canvasGroup.alpha += 1 / fadeInTime * Time.deltaTime;
            if (canvasGroup.alpha >= 1)
            {
                if (sleepTimeBackup > 0)
                {
                    sleepTimeBackup -= Time.deltaTime;
                }
                else
                {
                    fadeIn = false;

                    if (fadeInOut)
                        fadeOut = true;

                    FadeInEnded?.Invoke();
                }
            }

        }

        if (fadeOut)
        {
            canvasGroup.alpha -= 1 / fadeOutTime * Time.deltaTime;
            if (canvasGroup.alpha <= 0)
            {
                fadeOut = false;
                fadeInOut = false;

                FadeOutEnded?.Invoke();
            }

        }
    }

    public void FadeIn()
    {
        sleepTimeBackup = sleepTime;
        fadeIn = true;
        fadeOut = false;
    }

    public void FadeOut()
    {
        fadeOut = true;
    }
    public void FadeInOutAuto()
    {
        fadeIn = true;
        fadeInOut = true;
    }
}
