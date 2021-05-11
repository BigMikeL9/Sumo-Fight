using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public float speed;

    public bool hasPowerUp = false;

    public float powerupStrenght;
    public GameObject powerUpIndicator;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
       
        playerRb.AddForce(focalPoint.transform.forward * speed * verticalInput);

        powerUpIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountdownRoutine());
            powerUpIndicator.gameObject.SetActive(true);
        }
    }
        
        IEnumerator PowerUpCountdownRoutine()
        {
            yield return new WaitForSeconds(7);
            hasPowerUp = false; // Wait for 7 seconds then there will be no powerup and no powerup indicator.
            powerUpIndicator.gameObject.SetActive(false);
        }
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp == true)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            enemyRb.AddForce(awayFromPlayer * powerupStrenght, ForceMode.Impulse);

            // This method is called Concatenation, which is adding strings together to create an entire message using the "+" sign.
            Debug.Log("Player has Collided with " + collision.gameObject.name + " with powerup set to " + hasPowerUp);
        }
    }
}
