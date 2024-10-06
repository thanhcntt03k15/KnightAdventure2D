using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private GameObject deathScreen;
    public GameObject mapHandler;

    public GameObject inventory;
    [SerializeField] private GameObject halfMana, fullMana;

    public enum ManaState
    {
        FullMana, 
        HalfMana
    }

    public ManaState manaState;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
        
    }

    public SceneFader sceneFader;

    public void Start()
    {
        sceneFader = GetComponentInChildren<SceneFader>();
    }

    public void SwitchMana(ManaState _manaState)
    {
        switch (_manaState)
        {
            case ManaState.FullMana:
                halfMana.SetActive(false);
                fullMana.SetActive(true);
                break;
            case ManaState.HalfMana:
                halfMana.SetActive(true);
                fullMana.SetActive(false);
                break;
        }

        manaState = _manaState;
    }

    public IEnumerator DeathScreen()
    {
        yield return new WaitForSeconds(0.8f);

        StartCoroutine(sceneFader.Fade(SceneFader.FadeDirection.In));

        yield return new WaitForSeconds(0.8f);
        deathScreen.SetActive(true);
    }

    public IEnumerator DeactiveDeathScreen()
    {
        yield return new WaitForSeconds(0.5f);
        deathScreen.SetActive(false);

        StartCoroutine(sceneFader.Fade(SceneFader.FadeDirection.Out));
    }

    public void RespawnPlayerUI()
    {
        GameManager.Instance.RespawnPlayer();
    }
}