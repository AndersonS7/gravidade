using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGravity : MonoBehaviour
{
    private GameObject[] planets;
    public GameObject targetPlanet;
    private float forceGMax;
    private float velG;
    private float forceGPlanet;
    private Vector3 direction;
    private Rigidbody2D rb;

    void Start()
    {
        velG = 0.05f;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FindForceBetweenPlanets();
        PointToDirection();

        direction = targetPlanet.transform.position - transform.position; // mostra a direção da nave para o planeta
        rb.AddForce(direction * velG); // aplica a força G
    }

    void FindForceBetweenPlanets()
    {
        planets = GameObject.FindGameObjectsWithTag("planet");
        forceGMax = 0;
        foreach (var planet in planets)
        {
            forceGPlanet = planet.transform.localScale.z / Vector2.Distance(transform.position, planet.transform.position);
            if (forceGPlanet > forceGMax)
            {
                forceGMax = forceGPlanet;
                targetPlanet = planet;
            }
        }
    }
    void PointToDirection()
    {
        if (Vector2.Distance(transform.position, targetPlanet.transform.position) < 3.5f)
        {
            Quaternion rotationRef;

            rotationRef = Quaternion.FromToRotation(-transform.up, direction) * transform.rotation;
            transform.rotation = rotationRef;
        }
        else
        {
            transform.rotation = Quaternion.Euler(0,0,0);
        }
    }

    // Formula símples
    /*
     planet = GameObject.FindGameObjectsWithTag("planet");
        foreach (GameObject p in planet)
        {
            if (Vector2.Distance(p.transform.position, transform.position) < 10)
            {
                transform.position += (p.transform.position - transform.position) * 0.01f * Time.fixedDeltaTime;
            }
        }
     */
}
