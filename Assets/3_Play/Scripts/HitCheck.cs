using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCheck : MonoBehaviour
{
    public bool[] recipeData = new bool[6];
    public bool isArrived = false;
    public bool isSucceeded = false;
    private Zombie zombie;

    public bool isMan = false;

    // Update is called once per frame
    void Update()
    {
        // 次のゾンビへ
        if(isSucceeded)
        {
            isSucceeded = false;
            isArrived = false;
            zombie.SetGoHome();
        }    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Zombieが到着
        isArrived = true;
        zombie = collision.gameObject.GetComponent<Zombie>();

        // レシピを確認する
        for (int i = 0; i < recipeData.Length; i++)
            recipeData[i] = zombie.recipeData[i];

        // 男性ゾンビであるかを確認する
        isMan = zombie.isMan;
    }
}
