# Enemy AI Behavior Tree in Unity

This project implements a simple behavior tree system for controlling enemy AI in Unity using C#. The AI includes two types of behaviors:
- **Fleeing**: The enemy runs away from the player when the player is within a certain distance.
- **Searching**: The enemy moves towards the player if the player is within a detectable range.

## Table of Contents
- [Project Structure](#project-structure)
- [Behavior Tree Design](#behavior-tree-design)
- [Scripts](#scripts)
- [How to Use](#how-to-use)
- [Setup in Unity](#setup-in-unity)
- [License](#license)

## Project Structure
This project uses a simple behavior tree structure that determines how the enemy will behave based on the player's position. The structure is as follows:
- **Behavior Tree Root**: A `Selector` which tries different behaviors.
- **Behaviors**: Each specific behavior (`FleeBehavior` or `SearchBehavior`) inherits from `IBehavior` and implements its `Execute()` method.

## Behavior Tree Design
The system is designed to allow for flexible behavior by using a `Selector` node:
- **Selector**: Attempts to run its child behaviors one by one, returning `Success` if any child succeeds.
- **FleeBehavior**: If the player is close to the enemy, the enemy flees.
- **SearchBehavior**: If the player is in sight, the enemy moves towards the player.

### Behavior States
Each behavior returns one of the following states:
- **Running**: The behavior is currently being executed.
- **Success**: The behavior has successfully completed its task.
- **Failure**: The behavior has failed its task.

## Scripts
### `EnemyAI.cs`
This script manages the overall behavior tree for each enemy. It decides which behavior to add to the tree based on whether the enemy should flee or search.

### `FleeBehavior.cs`
Implements a behavior where the enemy flees from the player if they are within a certain distance.

### `SearchBehavior.cs`
Implements a behavior where the enemy searches for and moves toward the player if they are within range and visible.

### `PlayerController.cs`
Handles player movement using keyboard input (WASD or arrow keys).

### `Selector.cs`
The `Selector` node loops through its child behaviors and returns success if any child behavior succeeds.

### `IBehavior.cs`
Interface that all behaviors must implement. Each behavior must have an `Execute()` method that returns a `BehaviorState`.

## License
This project is open-source and can be used freely.

