using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bench : MonoBehaviour
{
    public bool interacted;

    private void OnTriggerStay2D(Collider2D _other)
    {
        if (_other.CompareTag("Player") && Input.GetButton("Interact"))
        {
            interacted = true;
        }
    }
}
