using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWizrd : BaseEnemy
{
    public override void Start()
    {
        base.Start();
        damage = 10;
        health = 200.0f;
        speed = 2.2f;

        walkAnimationName = "WizardRun";
        dieAnimationName = "Die";
        damageAnimationName = "Hurt";
    }    override protected void moveEnemy(){
        base.moveEnemy();
        damage += 1;
    }
}

