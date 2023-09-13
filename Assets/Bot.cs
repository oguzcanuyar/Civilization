using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot : MonoBehaviour
{
    [SerializeField] private int Woods;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Tree targetTree;
    [SerializeField] private Animator animator;
    public MapManager _MM;
    private void Update()
    {
        if (!agent.hasPath)
        {
            FindNewPath();
        }
    }

    private void ResetPath()
    {
        agent.ResetPath();
        animator.SetBool("Walking", false);
        FindNewPath();
    }

    private void FindNewPath()
    {
        if (Woods == 0)
        {
            FindTree();
        }
        else
        {
            SetDestination(_MM._market.transform.position);
        }
    }

    private void SetDestination(Vector3 target)
    {
        agent.SetDestination(target);
        animator.SetBool("Walking", true);
    }
    public void CutTree()
    {
        Woods++;
        ResetPath();

    }

    public void SellWoods()
    {
        DataManager.Gold += Woods;
        Woods = 0;
        ResetPath();
    }
    private void FindTree()
    {
        if (_MM._forest.Trees.Count == 0)
            return;
        tree tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (tree t in _MM._forest.Trees)
        {
            float dist = Vector3.Distance(t.transform.position, currentPos);
            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }
        SetDestination(tMin.transform.position);
    }

}
