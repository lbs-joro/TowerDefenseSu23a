using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShooter : MonoBehaviour
{
    List<GameObject> enemiesInRange = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemiesInRange.Count > 0)
        {
            print("Det finns en fiende här!");
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
