using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectStatus : MonoBehaviour
{
    public float speed;
    public float s;
    [SerializeField] GameObject[] Oxgenprefabs = new GameObject[3];
    [SerializeField] GameObject[] Crystalprefabs = new GameObject[3];
    [SerializeField] GameObject[] EnemyPrefabs = new GameObject[3];
    [SerializeField] GameObject[] Asibaprefabs = new GameObject[3];
    [SerializeField] GameObject   InsekiPrefab;
    [SerializeField] GameObject Base_Ground;

    [SerializeField]  GameObject player;
    float Timecount;
    float GameTime;
    [SerializeField] float[] SpawnTime;  //0:é_ëf 1:ÉNÉäÉXÉ^Éã 2:Ë¶êŒ
    public AudioClip Fire_SE;
    public AudioClip Enemy_SE;
    AudioSource audiosorce;

    void Start()
    {
        audiosorce = GetComponent<AudioSource>();
        /*
        Instantiate(Asibaprefabs[Random.Range(0, Asibaprefabs.Length)], new Vector2(10, -2.8f), Quaternion.identity);
        Asibaprefabs[Random.Range(0, Asibaprefabs.Length)].transform.Translate(-s * Time.deltaTime, 0, 0);
        */
    }
    void Update()
    {
        Timecount += Time.deltaTime;
        GameTime += Time.deltaTime;
        SpawnTime[0] += Time.deltaTime;     
        SpawnTime[1] += Time.deltaTime;
        SpawnTime[2] += Time.deltaTime;
        SpawnTime[3] += Time.deltaTime;


        if (Timecount >= 5)
        {
            audiosorce.PlayOneShot(Enemy_SE);
            Timecount = 0;
            Instantiate(EnemyPrefabs[Random.Range(0, EnemyPrefabs.Length)], new Vector2(player.transform.position.x + 20, 2), Quaternion.identity);
        }



        //if (Time.frameCount % 1500 == 0)
        if(SpawnTime[0] >=8)
        {
            SpawnTime[0] = 0;
            Instantiate(Oxgenprefabs[Random.Range(0,Oxgenprefabs.Length)], new Vector2(player.transform.position.x + 20, 2), Quaternion.identity);
            Oxgenprefabs[Random.Range(0, Oxgenprefabs.Length)].transform.Translate(-speed * Time.deltaTime, 0, 0);
        }

        if(SpawnTime[1] >= 14)
        {
            SpawnTime[1] = 0;

            Instantiate(Crystalprefabs[Random.Range(0, Crystalprefabs.Length)], new Vector2(player.transform.position.x + 20, 2), Quaternion.identity);
            Crystalprefabs[Random.Range(0, Crystalprefabs.Length)].transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        
        if(SpawnTime[2] >= 15)
        {
            audiosorce.PlayOneShot(Fire_SE);
            SpawnTime[2] = 0;
            Instantiate(InsekiPrefab, new Vector2(player.transform.position.x + 20, 4), Quaternion.identity);
        }

        /*
        if(SpawnTime[3] >= 5)
        {
            SpawnTime[3] = 0;
            Instantiate(Asibaprefabs[Random.Range(0, Asibaprefabs.Length)], new Vector2(Base_Ground.transform.position.x , -2.8f), Quaternion.identity);
            Asibaprefabs[Random.Range(0, Asibaprefabs.Length)].transform.Translate(-s * Time.deltaTime, 0, 0);
        }
        */
    }
}
