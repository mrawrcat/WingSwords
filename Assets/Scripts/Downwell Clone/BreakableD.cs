using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableD : MonoBehaviour
{
    public float health;
    public GameObject deathParticle;
    void Update()
    {
        if (health <= 0)
        {
            GameObject effect = Instantiate(deathParticle, transform.position, Quaternion.identity);
            Destroy(effect, .5f);
            gameObject.SetActive(false);
        }
    }

    public void TakeDmg(float dmg)
    {
        Debug.Log("Enemy took " + dmg + " dmg");
        health -= dmg;

    }
}
