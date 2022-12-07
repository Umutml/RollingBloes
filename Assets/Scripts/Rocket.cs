using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private GameObject enemy;
    public float rocketSpeed;
    private Rigidbody rocketRb;

    // Start is called before the first frame update
    void Start()
    {
        rocketRb = GetComponent<Rigidbody>();
        enemy = GameObject.FindWithTag("Enemy");
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        enemy = GameObject.FindWithTag("Enemy");
        Vector3 ourDirection = (enemy.transform.position - transform.position).normalized;
        //Vector3 our1Direction = (boss.transform.position - transform.position).normalized;
            rocketRb.AddForce(ourDirection * rocketSpeed * Time.deltaTime, ForceMode.Impulse);
        transform.LookAt(enemy.transform);
        if (!GameObject.FindWithTag("Enemy"))
        {
            enemy = GameObject.FindWithTag("Enemy");
        }
    }
        
        
        
 }

