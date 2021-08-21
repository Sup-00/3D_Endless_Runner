using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private MainMenuUI _mainMenuUI;
    [SerializeField] private SkinShopUI _skinShopUI;
    [SerializeField] private UpgradeShopUI _upgradeShopUI;
        
    public void OpenMainMenuUI()
    {
        gameObject.SetActive(false);
        _mainMenuUI.gameObject.SetActive(true);
    }

    public void OpenSkinShop()
    {
        _skinShopUI.gameObject.SetActive(true);
        _upgradeShopUI.gameObject.SetActive(false);
    }

    public void OpenUpgradeShop()
    {
        _upgradeShopUI.gameObject.SetActive(true);
        _skinShopUI.gameObject.SetActive(false);
    }
}
