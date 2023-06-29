using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState<Bot>
{
    public void OnEnter(Bot bot)
    {
        bot.OnMoveStop();
        bot.Counter.Start(() => bot.ChangeState(new PatrolState()), Random.Range(0f, 2f));
    }

    public void OnExecute(Bot bot)
    {
        bot.Counter.Execute();
    }

    public void OnExit(Bot bot)
    {
        
    }
}
