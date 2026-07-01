using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerControl : MonoBehaviour
{
    ///<summary> プレイヤーのx軸の位置 </summary>
    [SerializeField] private float positionX;

    ///<summary> ジャンプ力の最大 </summary>
    [SerializeField] private float jumpPowerMax;

    ///<summary> 空中でジャンプできる回数 </summary>
    [SerializeField] private int jumpCountMax;

    [SerializeField] private float stopTime;

    ///<summary> 空中用ジャンプ力 </summary>
    [SerializeField] private float jetpackPower;
    [SerializeField] private float addValue;

    public GameObject[] Crystalprefabs = new GameObject[3];
    //[SerializeField] TextMeshProUGUI TextScore;

    private Rigidbody2D player;
    private Rigidbody2D rb;
    public GameObject GetEffect;
    public AudioClip jumpSE;

    AudioSource audiosorce;

    ///<summary> 空中でジャンプした回数 </summary>
    private int jumpCount;

    ///<summary> 地上用ジャンプ力 </summary>
    [SerializeField] private float jumpPower;

    ///<summary> ジャンプしているか </summary>
    [SerializeField] private bool isJump;
    float Score;
    //アニメーターコンポ―メント取得変数
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        audiosorce = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        jumpCount = 0;
        isJump = true;

    }

    // Update is called once per frame
    void Update()
    {
        //  プレイヤーのx軸を固定
        Vector3 pos = transform.position;
        pos.x = positionX;
        transform.position = pos;

        if (Input.GetKey(KeyCode.Space))
        {
            AddJumpPower();
        }
    }

    private void LateUpdate()
    {
        //  開始して一定時間は操作を受け付けない
        if (stopTime > 0)
        {
            stopTime -= Time.deltaTime;
            jumpPower = 0;
            return;
        }

        //  空中ジャンプの回数が一定数以上ならジャンプしない
        if (jumpCount >= jumpCountMax)
        {
            return;
        }

        //  空中にいるとき
        if (isJump)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                float fallSpeed = 0;

                //  落下していたら補助
                if (player.velocity.y < 0)
                {
                    //  落下速度分プラスして力を補助
                    fallSpeed = player.velocity.magnitude;
                }

                Jump(jetpackPower + fallSpeed);

                //jumpPower = 0;
                jumpCount++;    //  空中ジャンプ回数をプラス
            }
        }
        //  地面にいるとき
        else
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                Jump(jumpPower);
                jumpPower = 0;
            }
        }
    }

    //  地面に触れたら
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //jumpPower = 0;
        jumpCount = 0;
        isJump = false;
        animator.SetBool("jump", false);
    }

    //  ジャンプ
    private void Jump(float power)
    {
        //アニメーションのジャンプフラグをtrueへ
        animator.SetBool("jump", true);

        audiosorce.PlayOneShot(jumpSE);
        Vector2 force = new Vector2(0, power);
        player.AddForce(force, ForceMode2D.Impulse);
    }

    //  ジャンプ力を溜める
    private void AddJumpPower()
    {
        //  最大1秒溜めれる
        if (jumpPower < jumpPowerMax)
        {
            jumpPower += addValue * Time.deltaTime;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "C1")
        //{
        //    Score += 100;
        //}
        //else if (collision.gameObject.tag == "C2")
        //{
        //    Score += 200;
        //    TextScore.text = Score.ToString("F2");
        //}
        //else if (collision.gameObject.tag == "C3")
        //{
        //    Score += 400;
        //    TextScore.text = Score.ToString("F2");
        //}
        ////  床
        //else
        //{
        //    isJump = true;
        //}
        isJump = true;
    }
    void GeneraterEffect_Get()
    {
        //エフェクト生成?
        GameObject effect = Instantiate(GetEffect) as GameObject;

        //発生場所
        effect.transform.position = player.transform.position;
    }

}