using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] float damage = 40f;
    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }
    void Update()
    {
        
    }
    public void AttackHitEvent()
    {
        if(target == null)
        {
            return;
        }
        target.TakeDamage(10);
        Debug.Log("Bang bng");
    }

}
