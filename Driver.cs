using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 220f;
    [SerializeField] float moveSpeed = 13f;
    [SerializeField] float slowSpeed = 10f;
    [SerializeField] float boostSpeed = 23f;
    
    
    void Update()
    {
        float rotateAmount = Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -rotateAmount);
        transform.Translate(0, moveAmount, 0);

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        moveSpeed = slowSpeed;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
       if(other.tag == "Booster")
        {
            moveSpeed = boostSpeed;
            // Destroy(other.gameObject);
        }
    }
    
}
