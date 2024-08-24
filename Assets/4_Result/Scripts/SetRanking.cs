using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetRanking : MonoBehaviour
{
    [SerializeField] Text txtRank;
    private float[] rank = new float[6]; //順位作業エリア

    // Start is called before the first frame update
    void Start()
    {
        txtRank.text = "\0";

        // ランキング
        InitializeRankArray();
        Ranking();
    }

    /// <summary>
    /// rankの初期化
    /// </summary>
    private void InitializeRankArray()
    {
        // データ領域の初期制御
        if (PlayerPrefs.HasKey("R1"))
        {
            // データ領域読み込み
            for (int idx = 1; idx <= 5; idx++)
                rank[idx] = PlayerPrefs.GetFloat("R" + idx);
            Debug.Log("データ領域を読み込みました。");
        }
        else
        {
            // 最大値を格納する
            for (int idx = 1; idx <= 5; idx++)
                PlayerPrefs.SetFloat("R" + idx, float.MaxValue);
            Debug.Log("データ領域を初期化しました。");
        }
    }

    /// <summary>
    /// ランキング処理
    /// </summary>
    private void Ranking()
    {
        float ELAPSED = PlayerPrefs.GetFloat("R6");
        int newRank = 0; //まず今回のタイムを0位と仮定する
        for (int idx = 5; idx > 0; idx--)
        { 
            //逆順 5...1
            if (rank[idx] > ELAPSED)
            {
                newRank = idx; // 新しいランクとして判定する
            }
        }
        if (newRank != 0)
        { 
            //0位のままでなかったらランクイン確定
            for (int idx = 5; idx > newRank; idx--)
            {
                rank[idx] = rank[idx - 1]; //繰り下げ処理
            }
            rank[newRank] = ELAPSED; //新ランクに登録
            for (int idx = 1; idx <= 5; idx++)
            {
                //データ領域に保存
                PlayerPrefs.SetFloat("R" + idx, rank[idx]);
            }
        }

        // それぞれのランクの値を設定する
        for (int idx = 1; idx <= 5; idx++)
        {
            if (rank[idx] >= float.MaxValue)
            {
                txtRank.text += "_.__s" + "\n";
            }
            else
            {
                txtRank.text += rank[idx].ToString("f2") + "s" + "\n";
            }
        }
    }
}
