using UnityEngine;
using System.Collections;
using System;

public class Bob_HitEnemyAction : GOAPAction {

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

		bool requiredDistance = Vector3.Distance (transform.position, target.transform.position) <= getMinDistanceToEnable ();
		Debug.Log ("CHECANDO..............................");

		return (target != null) && requiredDistance;
    }

    public override bool perform(GameObject agent)
    {
        Debug.Log("<color=green>Bob:</color> Hitting player! Pow!");
        attacked = true;
        return true;
    }
}
