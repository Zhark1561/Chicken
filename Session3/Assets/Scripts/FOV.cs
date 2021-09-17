using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOV : MonoBehaviour
{
    float fov = 120;
    float viewDistance = 40f;
    int rayCount = 60;
    float angleIncrease;
    Vector3 direction;
    float start;

    Entity entity;



    void Awake()
    {
        angleIncrease = fov/rayCount;
        entity = GetComponentInParent<Entity>();
    }

    void Update()
    {
        SetUpFOV();
    }

    void SetUpFOV()
    {
        for (float i = 1; i < rayCount; i++)
        {
            direction = transform.forward + new Vector3(((fov/100/2)) - (i/rayCount), 0, 0);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, direction, out hit, viewDistance))
            {
                if (hit.collider.tag == "Player")
                {
                    Vector3 enemyPosition = hit.transform.position;
                    MoveToEnemyPosition(enemyPosition);
                    entity.currentState = States.Attacking;
                    entity.StartShooting(hit.transform);
                }
                if (entity.currentState == States.Attacking)
                {
                    entity.currentState = States.Idle;
                    entity.agent.isStopped = false;
                    
                }
            }
            else if (entity.currentState == States.Attacking)
            {
                entity.currentState = States.Idle;
                entity.agent.isStopped = false;
            }
            

        }
    }

    void MoveToEnemyPosition(Vector3 enemyPosition)
    {

        entity.GetComponent<EntityMover>().destinationObject.transform.position = new Vector3(enemyPosition.x, transform.position.y, enemyPosition.z);
    }
}
