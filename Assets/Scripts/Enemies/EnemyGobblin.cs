using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGobblin : BaseEnemy
{
    public override void Start()
    {
        base.Start();
        damage = 15;
        health = 50.0f;
        speed = 1.0f;

        walkAnimationName = "GobblinWalk";
        dieAnimationName = "GobblinDie";
        damageAnimationName = "GoblinDamage";
}   }
