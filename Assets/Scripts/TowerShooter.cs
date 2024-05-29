using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UIElements;

public class TowerShooter : MonoBehaviour
{
    List<GameObject> enemiesInRange = new List<GameObject>();

    public GameObject bulletPrefab;
    public GameObject gun;

    float cooldown = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
        if(enemiesInRange.Count > 0)
        {
            Vector2 aimDirection = enemiesInRange[0].transform.position - transform.position;
            //Sikta mot fienden

            //TODO: Få bara toppen att rotera, inte basen!
            float angle = Vector2.SignedAngle(Vector2.up, aimDirection);
            gun.transform.rotation = Quaternion.Euler(0, 0, angle);
            
            if (cooldown < 0)
            {
                //Spawna ett skott
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
                
                //Sätt velocity på bulleten mot fienden.
                bulletRigidbody.velocity = aimDirection.normalized * 25f;
                
                cooldown = 1f;

            }

            

        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Var det en fiende som gick in? --> lägg till i listan
        if(collision.gameObject.tag == "Enemy")
        {
            enemiesInRange.Add(collision.gameObject);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemiesInRange.Remove(collision.gameObject);
        }
    }


}
