using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BoosterUI : MonoBehaviour
{
    [SerializeField] private GameObject _magnetUI;
    [SerializeField] private GameObject _superJumpUI;
    [SerializeField] private GameObject _scoreBoostUI;
    [SerializeField] private Slider _magnetSlider;
    [SerializeField] private Slider _superJumpSlider;
    [SerializeField] private Slider _scoreBoostSlider;

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