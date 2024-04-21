using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class SpatulaCol : MonoBehaviour
{
    private GameObject spatula;
  
    // Start is called before the first frame update
    void Start()
    {
        spatula = this.gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(spatula); 
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }


}
