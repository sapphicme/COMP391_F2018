using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//to allow us to edit min max variables in unity 
[System.Serializable]
// new class created (essentially blue prints for games) 
public class Boundary
{
    // Properties ( variables ) how much speed does it have? etc
    public float xMin, xMax, yMin, yMax;

    // Behaviours ( Functions / Methods ) what does the object do 

}
public class PlayerController : MonoBehaviour
{

    // Variable Declaration
    // to organize code and create headings in unity
    [Header("Movement Settings")]

    // these show up in unity, can be changed there
    public float speed = 5.0f;

    // MOVED TO PUBLIC CLASS BOUNDARY ( public float xMin, xMax, yMin, yMax; )
    public Boundary boundary; // created after commenting out above^^^

    // to organize code and create headings in unity
    [Header("Attack Settings")]
    public GameObject laser;
    public GameObject laserSpawn;
    public float fireRate = 0.5f;

    private Rigidbody2D rBody;

    // counter variable to fireRate
    private float myTime = 0.0f;


    // Use this for initialization
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        myTime += Time.deltaTime;

        //Getting the console to read whether or not a button is being pushed (boolean variable= true or false)
        if (Input.GetButton("Fire1") && myTime > fireRate)
        {
            Instantiate(laser, laserSpawn.transform.position, laserSpawn.transform.rotation);
            // transform is the equiv of GetComponent <laser>;
            myTime = 0.0f;
        }
    }
    // Fixed update increments. Used for physics!
    void FixedUpdate()
    {
        //Read input
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        Debug.Log("x: " + horiz + ", y: " + vert);

        Vector2 movement = new Vector2(horiz, vert);



        //Move player
        //Rigidbody2D rBody = GetComponent<Rigidbody2D>();
        rBody.velocity = movement * speed;

        //Restrict the player from leaving the play area
        rBody.position = new Vector2(
            Mathf.Clamp(rBody.position.x, boundary.xMin, boundary.xMax), // Restrict the x position to xMin and xMax
            Mathf.Clamp(rBody.position.y, boundary.yMin, boundary.yMax)); // Restrict the y position to yMin and yMax

    }


}
