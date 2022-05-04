using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private TextMeshProUGUI text;
    public Canvas win, lost, lifesc;
    int lives = 3;
    void Start()
    {
        rb.AddForce(new Vector3(20, 0,0));
        lost.enabled = false;
        win.enabled = false;
    }

   
    void Update()
    {
        float x=Input.GetAxis("Horizontal");  
        rb.AddForce(new Vector3(0,0, x*10));
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(new Vector3(-10,0,0));
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(new Vector3(10,0,0));
                
        }
        text.text = "Lives :" + lives;
        if (lives == 0)
        {
            lost.enabled = true;
            lifesc.enabled = false;
            Time.timeScale = 0;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            lives--;
            Destroy(collision.gameObject);  
            
        }
        else if(collision.gameObject.tag == "win")
        {
            Time.timeScale = 0;
            win.enabled = true;
        }
    }
}
