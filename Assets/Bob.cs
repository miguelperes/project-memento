﻿using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Bob : MonoBehaviour, IGoap
{
    NavMeshAgent navAgent;

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    public HashSet<KeyValuePair<string, object>> getWorldState()
    {
        HashSet<KeyValuePair<string, object>> worldData = new HashSet<KeyValuePair<string, object>>();

        worldData.Add(new KeyValuePair<string, object>("damagePlayer", false)); //to-do: change player's state for world data here

        return worldData;
    }

    public HashSet<KeyValuePair<string, object>> createGoalState()
    {
        HashSet<KeyValuePair<string, object>> goal = new HashSet<KeyValuePair<string, object>>();

        goal.Add(new KeyValuePair<string, object>("damagePlayer", true));

        return goal;
    }

    public bool moveAgent(GoapAction nextAction)
    {
        Vector3 targetPos = nextAction.target.transform.position;

        navAgent.SetDestination(targetPos);

        if(Vector3.Distance(transform.position, targetPos) <= nextAction.getDistanceToPerform())
        {
            navAgent.Stop();
            return true;
        }
        else
        {
            return false;
        }
    }

    public void planFound(HashSet<KeyValuePair<string, object>> goal, Queue<GoapAction> actions)
    {
        Debug.Log("<color=orange>Bob:</color> Plan Found.");
    }

    public void actionsFinished()
    {
        Debug.Log("<color=orange>Bob:</color> Actions finished.");
    }

    public void planAborted(GoapAction aborter)
    {
        Debug.Log("<color=orange>Bob:</color> Plan aborted.");
    }

    public void planFailed(HashSet<KeyValuePair<string, object>> failedGoal)
    {
        Debug.Log("<color=orange>Bob:</color> Plan failed.");
    }
}
