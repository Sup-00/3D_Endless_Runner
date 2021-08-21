using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private ShopUI _shopUI;
    [SerializeField] private RunUI _runUI;
    [SerializeField] private Moving _moving;
    [SerializeField] private StartRunCameraPosition _camera;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) ||
            Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            StartGame();
        }
    }

    public void OpenShopUI()
    {
        gameObject.SetActive(false);
        _shopUI.gameObject.SetActive(true);
    }

    public void OpenSettings()
    {
    }

    private void StartGame()
    {
        _camera.MoveCamera();
        _runUI.gameObject.SetActive(true);
        _moving.enabled = true;
        gameObject.SetActive(false);
    }
}