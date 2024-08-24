using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{    
    /// <summary>
    /// シーン番号
    /// </summary>
    enum INDEX_SCENE
    {
        TITLE = 0,   // タイトル
        EXPLAIN = 1, // 説明
        PLAY = 2,    // プレイ
        RESULT = 3,  // 結果
        CREDIT,      // クレジット
    }

    public static bool isPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        // ゲーム終了までオブジェクトを残す
        DontDestroyOnLoad(gameObject);
    }    

    // Update is called once per frame
    void Update()
    {
        // クリック音を鳴らす
        if (isPlayed)
        {
            isPlayed = false;
            GetComponent<AudioSource>().Play();
        }

        // 結果画面へ
        if(SceneManager.GetActiveScene().buildIndex == (int)INDEX_SCENE.PLAY)
        {
            if (Spawn.cntZombie >= Spawn.zombieMax)
                if (!GameObject.FindGameObjectWithTag("Zombie"))
                    OnClickNextScene();
        }
    }

    /// <summary>
    /// クリックしたら、次のシーンへ
    /// </summary>
    public void OnClickNextScene()
    {
        // 次のシーンへ
        int buildIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(buildIndex + 1);
    }

    /// <summary>
    /// クリックしたら、タイトルへ
    /// </summary>
    public void OnClickTitle()
    {
        // タイトルへ
        SceneManager.LoadSceneAsync((int)INDEX_SCENE.TITLE);
    }

    /// <summary>
    /// クリックしたら、クレジットへ
    /// </summary>
    public void OnClickCredit()
    {
        // クレジットへ
        SceneManager.LoadSceneAsync((int)INDEX_SCENE.CREDIT);
    }
}
