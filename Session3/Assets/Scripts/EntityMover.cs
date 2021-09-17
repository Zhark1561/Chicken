using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EntityMover : MonoBehaviour
{
    public GameObject ground;
    public GameObject destinationObject;
    public GameObject destinationObjectPrefab;
    public GameObject spawnPosition;
    public GameObject spawnPositionPrefab;
    private Vector3 destination;
    private Entity entity;
    
    bool canSetUpDestination;
    bool settingUpSpawn;

    void Awake()
    {
        entity = GetComponent<Entity>();
        ground = GameObject.Find("Ground");
        spawnPosition = Instantiate(spawnPositionPrefab, new Vector3(transform.position.x, 1.5f, transform.position.z), Quaternion.identity);
        spawnPosition.GetComponent<Destination>().entity = this.gameObject;
        spawnPosition.GetComponent<Destination>().ground = this.ground;
        spawnPosition.transform.position = spawnPosition.GetComponent<Destination>().RandomizePosition();
        settingUpSpawn = true;
    }

    void Update()
    {
        if(settingUpSpawn)
        {
            SetUpSpawn();
            transform.position = spawnPosition.transform.position;
        }
        if (canSetUpDestination)
        {
            SetUpDestination();
        }
        if (spawnPosition == null && destinationObject != null)
        {
            Move();
        }
        
    }

    IEnumerator Idle(float waitTime)
    {
        entity.currentState = States.Idle;
        yield return new WaitForSeconds(waitTime);
        entity.currentState = States.Walk;
    }

    void Move()
    {
        if (destinationObject.GetComponent<Destination>().isClose || destinationObject.GetComponent<Destination>().isInObject)
        {
            destinationObject.transform.position = destinationObject.GetComponent<Destination>().RandomizePosition();
            destinationObject.GetComponent<Destination>().CheckIfOutOfBonds();
            entity.currentState = States.Idle;
        }
        if(entity.currentState == States.Walk)
        {
            entity.agent.isStopped = false;
            destination = destinationObject.transform.position;
            entity.agent.SetDestination(destination);
        }
        if (entity.currentState == States.Idle)
        {
            StartCoroutine(Idle(Random.Range(0.1f, 2f)));
        }
    }
    void SetUpDestination()
    {
        destinationObject = Instantiate(destinationObjectPrefab, new Vector3(transform.position.x, 2f, transform.position.z), Quaternion.identity);
        destinationObject.GetComponent<Destination>().entity = this.gameObject;
        destinationObject.GetComponent<Destination>().ground = ground;
        canSetUpDestination = false;
    }
    void SetUpSpawn()
    {
        if (spawnPosition.GetComponent<Destination>().isInObject)
        {
            spawnPosition.transform.position = spawnPosition.GetComponent<Destination>().RandomizePosition();
            spawnPosition.GetComponent<Destination>().CheckIfOutOfBonds();
        }
        if (spawnPosition.GetComponent<Destination>().isClose && !spawnPosition.GetComponent<Destination>().isInObject)
        {
            Destroy(spawnPosition);
            settingUpSpawn = false;
            canSetUpDestination = true;
        }
    }
    
}
