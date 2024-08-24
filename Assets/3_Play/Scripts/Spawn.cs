using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject zombie;
    private float timer = 3;
    public static int cntZombie = 0;
    public static int zombieMax = 10;

    [SerializeField] Text txtNumberPeople;

    // Start is called before the first frame update
    void Start()
    {
        // テキストの初期化
        txtNumberPeople.text = cntZombie.ToString("d2");
    }

    // Update is called once per frame
    void Update()
    {
        // 治した数が上限なら、何もしない
        if (cntZombie >= zombieMax)
            return;

        // 注意:inspectorでZombieのtagを「Zombie」に
        if (GameObject.FindGameObjectsWithTag("Zombie").Length < 2)
        {
            // スポーンさせる
            if (timer <= 0)
            {
                timer = 3;
                Instantiate(zombie);
                cntZombie++;
                txtNumberPeople.text = cntZombie.ToString("d2");
            }
            // 時間計測
            timer -= Time.deltaTime;
        }
    }
}
