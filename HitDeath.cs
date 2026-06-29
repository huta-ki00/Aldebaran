using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HitDeath : MonoBehaviour
{
    public float speed;
    void Start()
    {
       
    }

   
    void Update()
    {
        // 毎フレーム移動
        transform.Translate(-speed * Time.deltaTime, 0, 0);

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
