using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Egg : MonoBehaviour
{
    [NonSerialized] public Entity player;
    Rigidbody body;

    void Awake()
    {
        Destroy(this.gameObject, 1f);

    }

    void OnCollisionEnter(Collision other)
    {
        if (!ReferenceEquals(other.gameObject, null))
        {
            GetComponent<MeshRenderer>().enabled = false;
            Destroy(this.gameObject, 0.5f);
        }
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Entity>().hp -= 10;
            other.gameObject.GetComponent<Entity>().CheckHp();
            if (other.gameObject.GetComponent<Entity>().hp == 0)
            {
                player.kills++;
                Destroy(other.gameObject.GetComponent<EntityMover>().destinationObject);

            }
        }
        
    }
}
