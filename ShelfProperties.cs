using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfProperties : MonoBehaviour //Makes adding shelves easier, simply make a parent object where all the shelves will be children of then add this script to the parent
{
    private Transform Parent;
    private int ChildCount;
    private Rigidbody2D rbChild; 

    // Start is called before the first frame update
    void Start()
    {
        Parent = this.gameObject.transform;
        ChildCount = Parent.childCount;

        for (int i = 0; i < ChildCount; i++)
        {
            Parent.GetChild(i).gameObject.AddComponent<Rigidbody2D>();
            rbChild = Parent.GetChild(i).gameObject.GetComponent<Rigidbody2D>();
            rbChild.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePosition;

            Parent.GetChild(i).gameObject.AddComponent<BoxCollider2D>();
             
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
