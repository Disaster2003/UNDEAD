using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetRanking : MonoBehaviour
{
    [SerializeField] Text txtRank;
    private float[] rank = new float[6]; //���ʍ�ƃG���A

    // Start is called before the first frame update
    void Start()
    {
        txtRank.text = "\0";

        // �����L���O
        InitializeRankArray();
        Ranking();
    }

    /// <summary>
    /// rank�̏�����
    /// </summary>
    private void InitializeRankArray()
    {
        // �f�[�^�̈�̏�������
        if (PlayerPrefs.HasKey("R1"))
        {
            // �f�[�^�̈�ǂݍ���
            for (int idx = 1; idx <= 5; idx++)
                rank[idx] = PlayerPrefs.GetFloat("R" + idx);
            Debug.Log("�f�[�^�̈��ǂݍ��݂܂����B");
        }
        else
        {
            // �ő�l���i�[����
            for (int idx = 1; idx <= 5; idx++)
                PlayerPrefs.SetFloat("R" + idx, float.MaxValue);
            Debug.Log("�f�[�^�̈�����������܂����B");
        }
    }

    /// <summary>
    /// �����L���O����
    /// </summary>
    private void Ranking()
    {
        float ELAPSED = PlayerPrefs.GetFloat("R6");
        int newRank = 0; //�܂�����̃^�C����0�ʂƉ��肷��
        for (int idx = 5; idx > 0; idx--)
        { 
            //�t�� 5...1
            if (rank[idx] > ELAPSED)
            {
                newRank = idx; // �V���������N�Ƃ��Ĕ��肷��
            }
        }
        if (newRank != 0)
        { 
            //0�ʂ̂܂܂łȂ������烉���N�C���m��
            for (int idx = 5; idx > newRank; idx--)
            {
                rank[idx] = rank[idx - 1]; //�J�艺������
            }
            rank[newRank] = ELAPSED; //�V�����N�ɓo�^
            for (int idx = 1; idx <= 5; idx++)
            {
                //�f�[�^�̈�ɕۑ�
                PlayerPrefs.SetFloat("R" + idx, rank[idx]);
            }
        }

        // ���ꂼ��̃����N�̒l��ݒ肷��
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
