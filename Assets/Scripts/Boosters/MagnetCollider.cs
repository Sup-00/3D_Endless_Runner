using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class MagnetCollider : MonoBehaviour
{
    [SerializeField] private BoosterUI _boosterUI;

    private bool _isBoosted = false;
    private CharectorMoving _charectorMoving;

    private void Awake()
    {
        _charectorMoving = FindObjectOfType<CharectorMoving>();
    }

    public void ActiveMagnet(float activeTime)
    {
        if (_isBoosted == false)
        {
            GetComponent<BoxCollider>().enabled = true;
            _isBoosted = true;
            _boosterUI.ShowMagnetUI(activeTime);
            StartCoroutine(ActiveTimer(activeTime));
        }
    }

    private IEnumerator ActiveTimer(float activeTime)
    {
        yield return new WaitForSeconds(activeTime);
        _isBoosted = false;
        GetComponent<BoxCollider>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isBoosted)
        {
            Coin coin = other.GetComponent<Coin>();
            if (coin != null)
            {
                coin.ActiveBooster(true);
            }
        }
    }
}