using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    int health = 3;

    TowerBuilder towerBuilder;

    // Start is called before the first frame update
    void Start()
    {
        //När jag har spawnat, hitta TowerBuilder-objektet i scenen!
        towerBuilder = FindObjectOfType<TowerBuilder>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Var det ett skott?
        if (collision.gameObject.tag == "Bullet")
        {
            health -= 1;
            if(health <= 0)
            {
                //Ge spelaren pengar!
                towerBuilder.money += 10;

                Destroy(gameObject);
            }

            //Oavsett: ta bort bullet-objektet.
            Destroy(collision.gameObject);
        }
    }
}
