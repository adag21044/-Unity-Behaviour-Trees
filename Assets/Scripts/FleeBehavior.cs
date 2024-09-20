using UnityEngine;

public class FleeBehavior : IBehavior
{
    private Transform player;
    private Transform enemy;
    private float fleeDistance;
    private float speed;

    public FleeBehavior(Transform player, Transform enemy, float fleeDistance, float speed)
    {
        this.player = player;
        this.enemy = enemy;
        this.fleeDistance = fleeDistance;
        this.speed = speed;
    }

    public BehaviorState Execute()
    {
        float distance = Vector3.Distance(player.position, enemy.position);

        if(distance < fleeDistance)
        {
            Vector3 direction = enemy.position - player.position;
            enemy.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
            return BehaviorState.Running;
        }

        return BehaviorState.Failure;
    }
}