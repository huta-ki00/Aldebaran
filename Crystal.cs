using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    public float speed;
    public GameObject GetEffect;
    private GameObject player;
    public AudioClip crystalSE;

    AudioSource audiosorce;

    // Start is called before the first frame update
    void Start()
    {
        audiosorce = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // 毎フレーム移動
        transform.Translate(-speed * Time.deltaTime, 0, 0);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GeneraterEffect_Get();
            audiosorce.PlayOneShot(crystalSE);
            SpriteRenderer player = collision.gameObject.GetComponent<SpriteRenderer>();
            Destroy(collision.gameObject, 0.4f);
        }
    }

    void GeneraterEffect_Get()
    {
        //エフェクト生成?
        GameObject effect = Instantiate(GetEffect) as GameObject;

        //発生場所
        effect.transform.position = player.transform.position;
    }

}
