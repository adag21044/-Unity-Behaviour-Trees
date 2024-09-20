using System.Collections.Generic;

public class Selector : IBehavior
{
    private List<IBehavior> behaviors;

    public Selector(List<IBehavior> behaviors)
    {
        this.behaviors = behaviors;
    }

    public BehaviorState Execute()
    {
        foreach(var behavior in behaviors)
        {
            BehaviorState state = behavior.Execute();

            if(state == BehaviorState.Success)
            {
                return BehaviorState.Success;
            }
        }

        return BehaviorState.Failure;
    }
}