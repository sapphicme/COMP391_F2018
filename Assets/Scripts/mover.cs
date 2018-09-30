using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover : MonoBehaviour {


    //Variable Declartations 
    public float speed;

	// Use this for initialization
	void Start () {

        Rigidbody2D rBody = GetComponent<Rigidbody2D>();
            rBody.velocity = transform.right * speed; 
	}
	
}
