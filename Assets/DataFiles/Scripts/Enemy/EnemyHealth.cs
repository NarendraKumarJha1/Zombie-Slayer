using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    bool isDie = false;
    [SerializeField] float hitpoints = 100f;
    [SerializeField] GameObject RespawnAward;
    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        hitpoints -=damage;
        if(hitpoints<=0)
        {
            Die();
        }
    }

    private void Die()
    {
        GetComponent<Animator>().SetTrigger("dead");
        FindObjectOfType<EnemyCount>().ReduceCount();
        isDie = true;
        DestroyEverything();
        Destroy(this);
        if(RespawnAward)
        {
            var reward = Instantiate(RespawnAward, transform.position,Quaternion.identity);
            reward.SetActive(true);
            if(reward.GetComponent<Collider>()==null)
            {
                var collider=reward.AddComponent<BoxCollider>().isTrigger=true;
            }
        }
    }

    private void DestroyEverything()
    {
        var enemyAI=GetComponent<EnemyAI>();
        Destroy(enemyAI);
        var enemyAttack=GetComponent<EnemyAttack>();
        Destroy(enemyAttack);
        var enemyCollider = GetComponent<Collider>();
        Destroy(enemyCollider);
    }

    public bool IsDead()
    {
        return isDie;
    }
}
