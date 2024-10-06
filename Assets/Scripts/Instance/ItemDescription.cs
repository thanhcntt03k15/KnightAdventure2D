using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDescription : MonoBehaviour
{
    public GameObject textDesc;

    private void Start()
    {
        textDesc.SetActive(false);
    }

    public void Show()
    {
        textDesc.SetActive(true);

    }

    public void Hide()
    {
        textDesc.SetActive(false);

    }
}
