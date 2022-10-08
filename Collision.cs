using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField] Color32 hasChangedPackaged = new Color32 (1, 1, 1, 1);
    [SerializeField] Color32 hasChangedPackaged2 = new Color32(1, 1, 1, 1);
    [SerializeField] float explosion;

    bool hasPackage;
    // bool hasBoost;
    SpriteRenderer spriteRenderer;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D()
    {
        Debug.Log("Collided");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up");
            hasPackage = true;
            spriteRenderer.color = hasChangedPackaged;
            Destroy(other.gameObject, explosion);
        }

        if (other.tag == "Customer" && hasPackage) 
        {
            Debug.Log("Delivered");
            spriteRenderer.color = hasChangedPackaged2;
            hasPackage = false;
            
        }
        
        else if (other.tag == "Customer" && !hasPackage)
        {
            Debug.Log("Customer is waiting");
        }
        
    }
}
