using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InvetoryManager : MonoBehaviour
{
    [SerializeField] private Image heartShard;
    [SerializeField] private Image manaShard;
    [SerializeField] private GameObject upCast, sideCast, downCast;

    [SerializeField] private GameObject dash, varJump, wallJump;

    private void OnEnable()
    {
        // heart shard
        heartShard.fillAmount = PlayerController.Instance.heartShards * 0.25f;
        // mana shard
        manaShard.fillAmount = PlayerController.Instance.manaShard * 0.34f;
        if (PlayerController.Instance.unlockedUpCast)
        {
            upCast.SetActive(true);
        }
        else
        {
            upCast.SetActive(false);
        }
        if (PlayerController.Instance.unlockedSideCast)
        {
            sideCast.SetActive(true);
        }
        else
        {
            sideCast.SetActive(false);
        }
        if (PlayerController.Instance.unlockedDownCast)
        {
            downCast.SetActive(true);
        }
        else
        {
            downCast.SetActive(false);
        }
        
        //abillity
        if (PlayerController.Instance.unlockedDash)
        {
            dash.SetActive(true);
        }
        else
        {
            dash.SetActive(false);
        }
        if (PlayerController.Instance.unlockedvarJump)
        {
            varJump.SetActive(true);
        }
        else
        {
            varJump.SetActive(false);
        }
        if (PlayerController.Instance.unlockedWallJump)
        {
            wallJump.SetActive(true);
        }
        else
        {
            wallJump.SetActive(false);
        }
    }
}
