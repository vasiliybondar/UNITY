﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] protected int fence = 0;
    [SerializeField] protected float acceleration;

    protected Rigidbody rb;

    protected virtual void Move() { }

    protected virtual void NextMove() { }

    public virtual void StartEndMove() { }

    protected virtual void EndMove() { }

}
