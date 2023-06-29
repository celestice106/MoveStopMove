using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState<Bot>
{
    public void OnEnter(Bot bot)
    {
        bot.OnMoveStop();
        bot.OnAttack();
        if(bot.IsCanAttack)
        {
            bot.Counter.Start(() =>
            {
                bot.Throw();
                bot.Counter.Start(() =>
                {
                    bot.ChangeState(Utilities.Chance(50, 100) ? new PatrolState() : new IdleState());
                }, Character.TIME_DELAY_THROW);
            }, Character.TIME_DELAY_THROW);
        }
    }

    public void OnExecute(Bot bot)
    {
        bot.Counter.Execute();
    }
    
    public void OnExit(Bot bot)
    {

    }
}
