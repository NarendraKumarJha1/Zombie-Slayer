using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnemyCount : MonoBehaviour
{
    int totalObject;
    [SerializeField] TextMeshProUGUI totalzombie;
    ZombieCountAnim zombieCountAnim;
    private void Awake()
    {
        zombieCountAnim = FindObjectOfType<ZombieCountAnim>();
    }
    void Start()
    {
        totalObject = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    // Update is called once per frame
    void Update()
    {
        
        totalzombie.SetText(totalObject.ToString());
    }
    public void ReduceCount()
    {
        StartCoroutine(Reduce());
    }

    IEnumerator Reduce()
    {
        yield return new WaitForSeconds(1f);
        totalObject -= 1;
        GetComponent<AudioSource>().Play();
        zombieCountAnim.PlayUI();
    }
}
