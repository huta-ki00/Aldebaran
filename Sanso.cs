using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sanso : MonoBehaviour
{
    public float speed;
    public GameObject HealEffect;
    private GameObject player;
    [SerializeField] Image ACT_GAGE;
    public AudioClip oxygenSE;

    AudioSource audiosorce;


    void Start()
    {
        audiosorce = GetComponent<AudioSource>();
    }


    void Update()
    {
        // 毎フレーム移動
        transform.Translate(-speed * Time.deltaTime, 0, 0);

        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Sanso")
        {
            GeneraterEffect();
            audiosorce.PlayOneShot(oxygenSE);
            SpriteRenderer player = collision.gameObject.GetComponent<SpriteRenderer>();
            ACT_GAGE.fillAmount += 0.25f;
            Destroy(collision.gameObject, 0.4f);
        }
        else if (collision.gameObject.tag == "Sanso2")
        {
            GeneraterEffect();
            audiosorce.PlayOneShot(oxygenSE);
            SpriteRenderer player = collision.gameObject.GetComponent<SpriteRenderer>();
            ACT_GAGE.fillAmount += 0.5f;
            Destroy(collision.gameObject, 0.4f);
        }
        else if (collision.gameObject.tag == "Sanso3")
        {
            GeneraterEffect();
            audiosorce.PlayOneShot(oxygenSE);
            SpriteRenderer player = collision.gameObject.GetComponent<SpriteRenderer>();
            ACT_GAGE.fillAmount += 1f;
            Destroy(collision.gameObject, 0.4f);
        }
    }

    void GeneraterEffect()
    {
        //エフェクト生成?
        GameObject effect = Instantiate(HealEffect) as GameObject;
        //発生場所
        effect.transform.position = player.transform.position;
    }
}
