using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreItem : MonoBehaviour
{
    public GameObject effect;
    public int score; //é¿ç€ÇÃìæì_

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            Instantiate(effect, transform.position, transform.rotation);
            SpriteRenderer player = collision.gameObject.GetComponent<SpriteRenderer>();
           // FindObjectOfType<Score>().score += 100;  //ìæì_Çâ¡éZ
            Destroy(collision.gameObject, 0.4f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
