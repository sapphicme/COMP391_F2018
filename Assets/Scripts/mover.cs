using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {


    //Variable Declartations 
    //this shows up in the unity program
    public float speed;


    private Rigidbody2D rBody;

	// Use this for initialization
	void Start () {
        rBody = GetComponent<Rigidbody2D>();
        rBody.velocity = transform.right * speed; 
	}
	
}
