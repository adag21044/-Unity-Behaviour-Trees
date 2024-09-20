using UnityEngine;

public class SearchBehavior : IBehavior
{
    private Transform player;
    private Transform enemy;
    private float speed;
    private float maxSearchDistance;

    public SearchBehavior(Transform player, Transform enemy, float speed, float maxSearchDistance)
    {
        this.player = player;
        this.enemy = enemy;
        this.speed = speed;
        this.maxSearchDistance = maxSearchDistance;
    }

    public BehaviorState Execute()
    {
        RaycastHit hit;
        Vector3 direction = (player.position - enemy.position).normalized;

        if(Physics.Raycast(enemy.position, direction, out hit, maxSearchDistance))
        {
            if(hit.transform == player)
            {
                enemy.position += direction * speed * Time.deltaTime;
                return BehaviorState.Success;
            }
        }

        return BehaviorState.Failure;
    }
    
}