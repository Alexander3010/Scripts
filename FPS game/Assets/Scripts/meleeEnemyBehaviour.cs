using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class meleeEnemyBehaviour : enemyBehaviour
{  
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        base.playerHP = GameObject.FindGameObjectWithTag("player").GetComponent<playerHelth>();

        base.playerTransform = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>();
        base.enemyTransform = GetComponent<Transform>();

        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate() {
        navMeshAgent.SetDestination(base.playerTransform.position);

        base.enemyTransform.LookAt(base.playerTransform.position);
    }

}
