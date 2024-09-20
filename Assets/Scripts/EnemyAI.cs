using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private IBehavior behaviorTree;
    public Transform player;
    public float fleeDistance = 5f;
    public float speed = 3f;
    public float searchDistance = 10f;
    public bool isFleeingEnemy;
    

    private void Start()
    {
        if(isFleeingEnemy)
        {
            behaviorTree = new Selector(new List<IBehavior>
            {
                new FleeBehavior(player, transform, fleeDistance, speed)
            });
        }
        else
        {
            behaviorTree = new Selector(new List<IBehavior>
            {
                new SearchBehavior(player, transform, speed, searchDistance)
            });
        }
    }

    private void Update()
    {
        behaviorTree.Execute();
    }
}