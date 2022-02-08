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
        if (GetComponent<Rigidbody2D>() != null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
        else
        {
            print($"Precisa adicionar um RigidBody ao objeto <{gameObject.name.ToUpper()}>");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //PointToDirection();
        FindPlanet();
        AddForceToBody();

        direction = targetPlanet.transform.position - transform.position;
        forceGMax = 0;
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
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    void AddForceToBody()
    {
        if (rb != null)
        {
            rb.AddForce(direction * velG);
            print(direction * velG);
        }
    }
    void FindPlanet()
    {
        planets = GameObject.FindGameObjectsWithTag("planet");
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
