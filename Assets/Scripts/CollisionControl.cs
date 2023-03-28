using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionControl : MonoBehaviour
{
    public int Health = 1;
    private int currentHealth;
    public Text DeathText;
    public Text DeathTextT;
    public Text DeathTextF;
    public Image DeathScreen;
    public Image DeathScreenT;
    public Image DeathScreenF;
    private bool isDead = false;
    void Start()
    {
       
        currentHealth = Health;
        DeathScreen.gameObject.SetActive(false);
        DeathScreenT.gameObject.SetActive(false);
        DeathScreenF.gameObject.SetActive(false);
        DeathText.gameObject.SetActive(false);
        DeathTextT.gameObject.SetActive(false);
        DeathTextF.gameObject.SetActive(false);
    }

 
    void Update()
    {
        if (isDead)
        {

            GetComponent<CarController>().enabled = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Die();
        }

    }
    private void Die()
    {
        currentHealth--;
        if (currentHealth <= 0 && !isDead)
        {

            isDead = true;
            GetComponent<CarController>().enabled = false;
            GetComponent<CameraController>().enabled = false;
            DeathScreen.gameObject.SetActive(true);
            DeathScreenT.gameObject.SetActive(true);
            DeathScreenF.gameObject.SetActive(true);
            DeathText.gameObject.SetActive(true);
            DeathTextT.gameObject.SetActive(true);
            DeathTextF.gameObject.SetActive(true);
            Debug.Log("Car is uncontrollablle");
        }
    }
}
