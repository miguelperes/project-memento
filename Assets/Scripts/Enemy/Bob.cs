using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Bob : MonoBehaviour, IGOAP
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
		worldData.Add(new KeyValuePair<string, object>("pirocoptero", true));

        return worldData;
    }

    public HashSet<KeyValuePair<string, object>> createGoalState()
    {
        HashSet<KeyValuePair<string, object>> goal = new HashSet<KeyValuePair<string, object>>();

		goal.Add(new KeyValuePair<string, object>("damagePlayer", true));
        goal.Add(new KeyValuePair<string, object>("pirocoptero", true));

        return goal;
    }

    public bool moveAgent(GOAPAction nextAction)
    {
        Vector3 targetPos = nextAction.target.transform.position;

        if(Vector3.Distance(transform.position, targetPos) <= nextAction.getDistanceToPerform())
        {
            Debug.Log("<color=yellow>Bob Move Agent:</color> true.");
			navAgent.Stop();
            nextAction.setInRange(true);
            return true;
        }
        else
        {
            Debug.Log("<color=yellow>Bob Move Agent:</color> false.");
			navAgent.Resume ();
			navAgent.SetDestination(targetPos);
            return false;
        }
    }

    public void planFound(HashSet<KeyValuePair<string, object>> goal, Queue<GOAPAction> actions)
    {
        Debug.Log("<color=orange>Bob:</color> Plan Found.");
    }

    public void actionsFinished()
    {
        Debug.Log("<color=orange>Bob:</color> Actions finished.");
    }

    public void planAborted(GOAPAction aborter)
    {
        Debug.Log("<color=orange>Bob:</color> Plan aborted.");
    }

    public void planFailed(HashSet<KeyValuePair<string, object>> failedGoal)
    {
        Debug.Log("<color=orange>Bob:</color> Plan failed.");
    }
}
