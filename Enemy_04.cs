using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy_04 : MonoBehaviour
{
    public float nowPos;
    public float speed;

    void Start()
    {
        nowPos = this.transform.position.y;
    }

    
    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
        transform.position = new Vector3(transform.position.x, nowPos + Mathf.PingPong(Time.time / 3, 0.3f), transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SpriteRenderer player = collision.gameObject.GetComponent<SpriteRenderer>();
            Destroy(collision.gameObject, 0.4f);
            SwitchScene();
        }
    }

    public void SwitchScene()
    {
        //引数１:シーン名　引数２:シーンを読み込むときのモード
        //Singleは全てのシーンを閉じて、ロード。
        //Additiveは現在ロードしているシーンにシーンを追加。
        SceneManager.LoadScene("GameOver2", LoadSceneMode.Single);
    }
}
