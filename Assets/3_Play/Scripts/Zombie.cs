using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] GameObject speechBubble;
    [SerializeField] GameObject[] item;
    public bool[] recipeData = new bool[6];
    private Vector2 positionReceive = new Vector2(6, -2);
    private Vector2 positionGoHome = new Vector2(1, -2);
    private Vector2 positionWait = new Vector2(8, -2);
    /// <summary>
    /// ゾンビの状態
    /// </summary>
    private enum ZOMBIE_STATE
    {
        WAIT = 0,    // 待ち
        RECEIVE = 1, // 薬の受け取り
        GO_HOME = 2, // 帰宅
    }
    private ZOMBIE_STATE zombieState = ZOMBIE_STATE.WAIT;

    [SerializeField] Sprite[] zombie;
    public bool isMan = false;

    // Start is called before the first frame update
    void Start()
    {
        // 初期配置
        transform.position = new Vector2(10, -2);

        // 吹き出し・調合素材を非表示
        speechBubble.GetComponent<SpriteRenderer>().enabled = false;
        for (int i = 0; i < item.Length; i++)
            item[i].GetComponent<SpriteRenderer>().enabled = false;

        // レシピの作成
        MakeRecipe();

        // コスチューム選択
        int tmp = Random.Range(0, zombie.Length);
        GetComponent<SpriteRenderer>().sprite = zombie[tmp];
        if (tmp == 0)
            isMan = true;
    }

    // Update is called once per frame
    void Update()
    {
        switch(zombieState)
        {
            case ZOMBIE_STATE.WAIT:
                // 前のゾンビが掃けたら、受け取りに行く
                // 注意:inspectorでZombieのtagを「Zombie」に
                if (GameObject.FindGameObjectsWithTag("Zombie").Length == 1)
                    zombieState = ZOMBIE_STATE.RECEIVE;
                // 待機場所まで移動
                else if (transform.position.x > positionWait.x)
                    transform.position = new Vector2(transform.position.x - Time.deltaTime, -2);
                break;
            case ZOMBIE_STATE.RECEIVE:
                // 受け取り場所まで移動
                if (transform.position.x > positionReceive.x)
                    transform.position = new Vector2(transform.position.x - Time.deltaTime, -2);
                else
                {
                    // 吹き出し・必要な調合素材を表示
                    speechBubble.GetComponent<SpriteRenderer>().enabled = true;
                    for (int i = 0; i < recipeData.Length; i++)
                        item[i].GetComponent<SpriteRenderer>().enabled = recipeData[i];
                }
                break;
            case ZOMBIE_STATE.GO_HOME:
                // 吹き出し・必要な調合素材を表示
                speechBubble.GetComponent<SpriteRenderer>().enabled = false;
                for (int i = 0; i < recipeData.Length; i++)
                    item[i].GetComponent<SpriteRenderer>().enabled = false;

                // 帰宅
                if (transform.position.x > positionGoHome.x)
                    transform.position = new Vector2(transform.position.x - Time.deltaTime, -2);
                else
                    Destroy(gameObject);
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// レシピを作成する
    /// </summary>
    private void MakeRecipe()
    {
        // レシピの作成
        int cntNone = 0;
        for (int i = 0; i < recipeData.Length; i++)
        {
            recipeData[i] = System.Convert.ToBoolean(Random.Range(0, 2));
            if (!recipeData[i])
                cntNone++;
        }

        // 何も調合素材が指定されていなかったら、やり直し
        if (cntNone == 6)
            MakeRecipe();
    }

    /// <summary>
    /// 帰宅を許す
    /// </summary>
    public void SetGoHome()
    {
        zombieState = ZOMBIE_STATE.GO_HOME;
    }
}
