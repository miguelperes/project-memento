using UnityEngine;
using System.Collections;
using System;

public class Bob_Pirocoptero : GOAPAction {

    private bool pirocou = false;

    public Bob_Pirocoptero()
    {
        addEffect("pirocoptero", true);
    }

    public override void reset()
    {
        pirocou = false;
        target = null;
    }

    public override bool isDone()
    {
        return pirocou;
    }

    public override bool requiresInRange()
    {
        return false;
    }

    public override bool checkProceduralPrecondition(GameObject agent)
    {
		return true;
    }

    public override bool perform(GameObject agent)
    {
        Debug.Log("<color=green>Bob:</color> Pirocando! Prrr!");
        pirocou = true;
        return true;
    }
}
