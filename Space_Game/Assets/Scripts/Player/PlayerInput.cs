using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInput : MonoBehaviour
{
    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }
    public bool NormalAttack { get; private set; }

    public event Action onNormalAttack;
    
    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");

        NormalAttack = Input.GetKeyDown(KeyCode.Z);
        if(NormalAttack) onNormalAttack?.Invoke();
    }
}
