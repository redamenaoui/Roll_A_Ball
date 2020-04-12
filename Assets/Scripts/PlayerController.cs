﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Text countText;
    public Text winText;
    public float speed;

    private Rigidbody rb;
    private int count;
    

    void Start()
    {
        count = 0;
        speed = 12.5F;
        rb = GetComponent<Rigidbody>();
        winText.text = "";
        SetCountText();
    }
    void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0F, moveVertical);

        rb.AddForce(movement * speed) ;    
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {

            other.gameObject.SetActive (false);
            count = count + 1;
            SetCountText();
        }

    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 8)
        {
            winText.text = "YOU WIN !";
        }
    }

}
