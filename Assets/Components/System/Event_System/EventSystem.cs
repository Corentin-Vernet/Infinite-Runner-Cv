using System;

public static class EventSystem
{
    public static Action OnPlayerCollision;
    public static Action<int> OnPlayerLifeUpdated;

    public static Action<State> OnGameStateChange;
}