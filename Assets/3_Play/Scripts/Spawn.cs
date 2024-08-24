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
        // �e�L�X�g�̏�����
        txtNumberPeople.text = cntZombie.ToString("d2");
    }

    // Update is called once per frame
    void Update()
    {
        // ��������������Ȃ�A�������Ȃ�
        if (cntZombie >= zombieMax)
            return;

        // ����:inspector��Zombie��tag���uZombie�v��
        if (GameObject.FindGameObjectsWithTag("Zombie").Length < 2)
        {
            // �X�|�[��������
            if (timer <= 0)
            {
                timer = 3;
                Instantiate(zombie);
                cntZombie++;
                txtNumberPeople.text = cntZombie.ToString("d2");
            }
            // ���Ԍv��
            timer -= Time.deltaTime;
        }
    }
}
