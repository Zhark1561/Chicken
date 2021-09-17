using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour
{
    public bool isInObject;
    public bool isClose;
    public GameObject entity;
    public GameObject ground;

    [SerializeField] float offset;

    public void CheckIfOutOfBonds()
    {
        if(transform.position.x > (ground.transform.localScale.x/2))
        {
            transform.position = new Vector3((ground.transform.localScale.x/2) - offset, 2f, transform.position.z);
        }
        else if(transform.position.x < -1 * (ground.transform.localScale.x/2))
        {
            transform.position = new Vector3(-1 * (ground.transform.localScale.x/2) + offset, 2f, transform.position.z);
        }
        
        if(transform.position.z > (ground.transform.localScale.z/2))
        {
            transform.position = new Vector3(transform.position.x, 2f, (ground.transform.localScale.z/2) - offset);
        }
        else if(transform.position.z < -1 * (ground.transform.localScale.x/2))
        {
            transform.position = new Vector3(transform.position.x, 2f, -1 * (ground.transform.localScale.x/2) - offset);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == entity)
        {
            isClose = true;
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == entity)
        {
            isClose = true;
        }
        if (other.gameObject.layer == 3)
        {
            isInObject = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == entity)
        {
            isClose = false;
        }
        if (other.gameObject.layer == 3)
        {
            isInObject = false;
        }
    }
    public Vector3 RandomizePosition()
    {
        return new Vector3(Random.Range(-1, 2)*Random.Range(0f, (ground.transform.localScale.x/2)), transform.position.y, Random.Range(-1, 2)*Random.Range(0f, (ground.transform.localScale.z/2)));
    }

}
