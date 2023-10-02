using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    GameObject deathParticleSystem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Bird>() != null)
        {
            Instantiate(deathParticleSystem, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            return;
        }
        if (collision.collider.GetComponent<Enemy>() != null)
        {
            return;
        }
        if (collision.contacts[0].normal.y < -.5) // handle crate falling on enemy
        {
            Instantiate(deathParticleSystem, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            return;
        }
    }
}
