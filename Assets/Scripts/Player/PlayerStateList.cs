using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateList : MonoBehaviour
{
    public bool jumping = false;
    public bool dashing = false;
    public bool recoilingX, recoilingY;
    public bool lookingRight;
    public bool invincible;
    public bool healing;
    public bool casting;
    public bool cutscene = false;
    public bool alive;

    public void playerRespawnIdle()
    {
        jumping = false;
        dashing = false;
        recoilingX = false;
        recoilingY = false;
        lookingRight = true;
        invincible = false;
        healing = false;
        casting = false;
        cutscene = false;
        alive = true;
    }
}


