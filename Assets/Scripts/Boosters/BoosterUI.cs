using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BoosterUI : MonoBehaviour
{
    [SerializeField] private GameObject _magnetUI;
    [SerializeField] private GameObject _superJumpUI;
    [SerializeField] private GameObject _scoreBoostUI;

    private Slider _magnetSlider;
    private Slider _superJumpSlider;
    private Slider _scoreBoostSlider;

    private void Start()
    {
        _magnetSlider = _magnetUI.GetComponentInChildren<Slider>();
        _superJumpSlider = _superJumpUI.GetComponentInChildren<Slider>();
        _scoreBoostSlider = _scoreBoostUI.GetComponentInChildren<Slider>();
    }

    private IEnumerator ActiveTimer(float activeTime, Slider slider, GameObject UI)
    {
        UI.SetActive(true);
        float currentTimer = activeTime;
        while (currentTimer > 0)
        {
            currentTimer -= 1 * Time.deltaTime;
            slider.value = currentTimer / activeTime;
            yield return null;
        }
        UI.SetActive(false);
    }

    public void ShowSuperJumpUI(float activeTime)
    {
        StartCoroutine(ActiveTimer(activeTime, _superJumpSlider, _superJumpUI));
    }
    
    public void ShowMagnetUI(float activeTime)
    {
        StartCoroutine(ActiveTimer(activeTime, _magnetSlider, _magnetUI));
    }
    
    public void ShowScoreBoostUI(float activeTime)
    {
        StartCoroutine(ActiveTimer(activeTime, _scoreBoostSlider, _scoreBoostUI));
    }
}