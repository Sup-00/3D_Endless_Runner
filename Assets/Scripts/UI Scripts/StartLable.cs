using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartLable : MonoBehaviour
{
    private TMP_Text _text;

    private void OnEnable()
    {
        _text = GetComponent<TMP_Text>();
        StartCoroutine(IncreaseLable());
    }


    private IEnumerator IncreaseLable()
    {
        while (_text.fontSize < 28f)
        {
            _text.fontSize += 0.1f;
            yield return null;
        }

        StartCoroutine(DecreaseLable());
    }

    private IEnumerator DecreaseLable()
    {
        while (_text.fontSize > 20f)
        {
            _text.fontSize -= 0.1f;
            yield return null;
        }

        StartCoroutine(IncreaseLable());
    }
}