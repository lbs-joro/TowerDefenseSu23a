using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public List<GameObject> waypoints;
    int currentWaypointIndex = 0;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = waypoints[currentWaypointIndex].transform.position - transform.position;

        rb.velocity = direction.normalized * 2f;

        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < 0.1f) {
            //Jag har kommit fram till waypointen!

            currentWaypointIndex += 1;

            // �r jag p� sista waypointen?

            if (currentWaypointIndex == waypoints.Count)
            {
                Destroy(gameObject);
                //TODO: Spelaren f�rlorar ett liv ? etc. 
            }
        
        }

        float angle = Vector2.SignedAngle(Vector2.right, direction);

        transform.rotation = Quaternion.Euler(0, 0, angle);

        
    }
}
