using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BoosterUI : MonoBehaviour
{
    [SerializeField] private CoinMagnet _coinMagnet;
    [SerializeField] private SuperJump _superJump;
    [SerializeField] private ScoreMultiplayer _scoreMultiplayer;
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

    public void ShowSuperJumpUI()
    {
        StartCoroutine(ActiveTimer(_superJump.ActiveTime, _superJumpSlider, _superJumpUI));
    }

    public void ShowMagnetUI()
    {
        StartCoroutine(ActiveTimer(_coinMagnet.ActiveTime, _magnetSlider, _magnetUI));
    }

    public void ShowScoreBoostUI()
    {
        StartCoroutine(ActiveTimer(_scoreMultiplayer.ActiveTime, _scoreBoostSlider, _scoreBoostUI));
    }
}