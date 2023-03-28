using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    [SerializeField] private Text SpeedTxt;
    [SerializeField] private Text SpeedTxtTop;
    [SerializeField] private Text SpeedTxtFront;
    [SerializeField] private Text PointText;
    [SerializeField] private Text PointTextTop;
    [SerializeField] private Text PointTextFront;
    [SerializeField] private Text DeathScreenText;
    [SerializeField] private Text DeathScreenTextTop;
    [SerializeField] private Text DeathScreenTextFront;
    public float speed;
    public float turnspeed;
    private int point;
    private float lspeed = 0f;
    private float hspeed = 95f;
    private float timespeed = 0f;
    private Rigidbody rb;
    private BoxCollider cld;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cld = GetComponent<BoxCollider>();
    }

    void FixedUpdate()
    {
        SpeedTxt.text = (rb.velocity.magnitude * 2.23693629f).ToString("0") + ("km/h"); //Arabanýn hýzýný hesaplayýp ekrana gönderiyor.
        SpeedTxtTop.text = (rb.velocity.magnitude * 2.23693629f).ToString("0") + ("km/h");
        SpeedTxtFront.text = (rb.velocity.magnitude * 2.23693629f).ToString("0") + ("km/h");
        Move();
        Turn();
        lspeed = rb.velocity.magnitude * 2.23693629f;
        PointCalculate(); 
       
        PointShow();
    }
    void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.CompareTag("PointCalculatePass")) //Engelleri geçince 50 puan ekler.
            {
                point += 50;
                Debug.Log("Pass point added=+50pts");
            }
        }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Side"))//Kaldýrýma çarptýðýnda 25 puan siler.
        {
            point -= 25;
            Debug.Log("You hit the side= -25pts");
        }
    }
    void Move()
    {
 //Blenderdan model aktarýrken koordinatlarý düzgün ayarlayamadýðým için ileri geri yönü ters oldu
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddRelativeForce(new Vector3(Vector3.forward.x,0,Vector3.forward.z)*speed);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            rb.AddRelativeForce(new Vector3(Vector3.forward.x, 0, Vector3.forward.z) * -speed);
        }
        Vector3 localVelocity = transform.InverseTransformDirection(rb.velocity);
        localVelocity.x = 0;
        localVelocity = transform.TransformDirection(localVelocity);
    }
    void Turn()
    {
   if (Input.GetKey(KeyCode.D))
        {
            rb.AddRelativeForce(-Vector3.right*turnspeed);
        }
       else if (Input.GetKey(KeyCode.A))
        {
            rb.AddRelativeForce(Vector3.right * turnspeed);
        }
    }
    void PointCalculate()
    {
       
        if (lspeed > hspeed)
        {
            point += 1; //Hýzýn hspeed'i geçtiðinde puan yazmaya baþlar.Hýzýn hspeed'den düþük olmaya baþladýðýnda puan yazmayý býrakýr.
            timespeed += Time.deltaTime;
            if (timespeed >= 1f)
            {
                timespeed = 0f;
            }
        }
        else 
        {
            timespeed = 0f;
        }
    }
    void PointShow()
    {
        PointText.text = "Puan=" + point;
        PointTextTop.text = "Puan=" + point;
        PointTextFront.text = "Puan=" + point;
        DeathScreenText.text = "Oyun bitti\nPuan=" + point;
        DeathScreenTextTop.text= "Oyun bitti\nPuan=" + point;
        DeathScreenTextFront.text= "Oyun bitti\nPuan=" + point;
    }
   
}
