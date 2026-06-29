using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManeger : MonoBehaviour
{
    
    [SerializeField] float CT;
    private float interval; //指定時間選択(マウスクリック用)
    private float tmptime;
    AudioSource audiosorce;
    public AudioClip Gage_SE;

    [SerializeField] Image ACT_GAGE;
    void Start()
    {
        audiosorce = GetComponent<AudioSource>();
        ACT_GAGE.fillAmount = 1f;
        //　指定時間当たりの時間取得初期化
        interval = 1.0f;
        tmptime = 0;

        
    }


    void Update()
    {
     if(ACT_GAGE.fillAmount < 0.01f)
        {
            SwitchScene();
        }
        tmptime += Time.deltaTime;
        if (tmptime >= interval)
        {
            ACT_GAGE.fillAmount -= 1.0f / CT * Time.deltaTime;
            interval = 0.2f;
        }

        if(ACT_GAGE.fillAmount < 0.25f)
        {
            audiosorce.PlayOneShot(Gage_SE);
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