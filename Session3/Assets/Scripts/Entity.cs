using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

public class Entity : MonoBehaviour
{
    public States currentState;
    public NavMeshAgent agent;
    public Slider slider;

    public float hp = 100;
    public float bulletSpeed = 60;
    public int kills = 0;
    public Canvas nameCanvas;

    [SerializeField] GameObject eggPrefab;
    [SerializeField] GameObject gun;
    [SerializeField] GameObject deathMark;

    bool canShoot = true;
    public TextMeshProUGUI nameTMP;

    void Awake()
    {
        currentState = States.Idle;
        agent = GetComponent<NavMeshAgent>();
        slider.value = CalculateHealth();
    }

    void Update()
    {
        slider.value = CalculateHealth();
    }

    public void StartShooting(Transform enemy)
    {
        if (currentState != States.Attacking)
        {
            return;
        }
        transform.LookAt(enemy);
        agent.isStopped = true;
        if (canShoot)
        {
            StartCoroutine(Shoot(0.2f));      
        }
    }

    IEnumerator Shoot(float shootCooldown)
    {
        canShoot = false;
        var eggInstance = Instantiate(eggPrefab, gun.transform.position, Quaternion.identity);
        eggInstance.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
        eggInstance.GetComponent<Egg>().player = GetComponent<Entity>();
        yield return new WaitForSeconds(shootCooldown);
        canShoot = true;
    }

    public void CheckHp()
    {
        if (hp <= 0)
        {
            hp = 0;
            Instantiate(deathMark, new Vector3(transform.position.x, 49, transform.position.z), Quaternion.Euler(90, 0, 0));
            nameCanvas.transform.SetParent(null);
            nameCanvas.transform.position = transform.position;
            Destroy(this.gameObject);
        }
    }
    

    float CalculateHealth()
    {
        return hp/100;
    }

}
