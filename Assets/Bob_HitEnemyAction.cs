﻿using UnityEngine;
using System.Collections;
using System;

public class Bob_HitEnemyAction : GoapAction {

    private bool attacked = false;

    public Bob_HitEnemyAction()
    {
        addEffect("damagePlayer", true);
    }

    public override void reset()
    {
        attacked = false;
        target = null;
    }

    public override bool isDone()
    {
        return attacked;
    }

    public override bool requiresInRange()
    {
        return true;
    }

    public override bool checkProceduralPrecondition(GameObject agent)
    {
        target = GameObject.Find("Player");
        return target != null;
    }

    public override bool perform(GameObject agent)
    {
        Debug.Log("<color=green>Bob:</color> Hitting player! Pow!");

        return true;
    }
}