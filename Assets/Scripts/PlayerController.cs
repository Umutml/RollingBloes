using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;
    public float speed = 10f;
    private GameObject focalPoint;
    public bool hasPower1up = false;
    public bool hasPower2up = false;
    public bool hasPower3up = false;
    public float powerUpstrength = 5f;
    public GameObject powerupIndicator;
    public GameObject rocketPrefab;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        
        float axisV = Input.GetAxis("Vertical");
        
        rb.AddForce(focalPoint.transform.forward * speed * Time.deltaTime * axisV, ForceMode.Impulse);

        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            powerupIndicator.gameObject.SetActive(true);
            hasPower1up = true;
            StartCoroutine("PowerupCountdownRoutine");
        }

        else if (other.CompareTag("Powerup1"))
        {
            Destroy(other.gameObject);
            powerupIndicator.gameObject.SetActive(true);
            hasPower2up = true;
            StartCoroutine("PowerupCountdownRoutine");
        }
        else if (other.CompareTag("Powerup2"))
        {
            Destroy(other.gameObject);
            hasPower3up = true;
            StartCoroutine("RocketCountdown");
            rocketSpawner();
        }


    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(10);
        hasPower1up = false;
        hasPower2up = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    IEnumerator RocketCountdown()
    {
        yield return new WaitForSeconds(5);
        hasPower3up = false;
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPower1up)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRigidbody.AddForce(awayFromPlayer * powerUpstrength, ForceMode.Impulse);
           

        }
        else if (collision.gameObject.CompareTag("Enemy") && hasPower2up)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRigidbody.AddForce(awayFromPlayer * powerUpstrength * 5f, ForceMode.Impulse);
        }
    }
    void rocketSpawner()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(rocketPrefab, transform.position + Vector3.up * 2, rocketPrefab.transform.rotation);
           
                
        }
    }

   
    
}
