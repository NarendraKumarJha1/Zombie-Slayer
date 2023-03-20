using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieCountAnim : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayUI()
    {
        StartCoroutine(PlayUIAnim());
    }
    IEnumerator PlayUIAnim()
    {
        anim.SetTrigger("Blow");
        yield return new WaitForSeconds(0.1f);
        anim.SetTrigger("Blow");
    }

}
