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
        // ���̃]���r��
        if(isSucceeded)
        {
            isSucceeded = false;
            isArrived = false;
            zombie.SetGoHome();
        }    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Zombie������
        isArrived = true;
        zombie = collision.gameObject.GetComponent<Zombie>();

        // ���V�s���m�F����
        for (int i = 0; i < recipeData.Length; i++)
            recipeData[i] = zombie.recipeData[i];

        // �j���]���r�ł��邩���m�F����
        isMan = zombie.isMan;
    }
}
