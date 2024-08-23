using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class PostQest : MonoBehaviour
{
    [SerializeField] Image PostImg;
    public bool[] correctAnswers = new bool[6];
    public bool backflg;
    public float speed;
    int img;
    int no;

    [SerializeField] Image[] Itemimg;

    int ItemCnt;

    Vector3 goal= new Vector3(5.00f,0,0);
    Vector3 goal2 = new Vector3(1.00f,0,0);

    Vector3 waitPosition = new Vector3(6.50f, 0, 0);



    // Start is called before the first frame update
    void Start()
    {
        PostImg.color = new Color(1, 1, 1, 0);
        transform.position = new Vector2(10.0f, -2.0f);

        ItemCnt = 0;
        ItemReset();
  
        backflg = false;

        if (GameObject.FindGameObjectsWithTag("Respawn").Length == 2)
        {
            no = 2;
        }
        else
        {
            no = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Respawn").Length == 1)
        {
            no = 1;
        }

        if (backflg)
        {
            if (transform.position.x > goal2.x)
            {
                //‰E•ûŒü‚ÌˆÚ“®“ü—Í
                Vector2 pos = transform.position;
                pos.x -= speed;
                transform.position = pos;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else if (no == 1)
        {
            if (transform.position.x > goal.x)
            {   //ˆê‘Ì–Ú‚Ì‘Ò‹@êŠ‚ÌˆÚ“®“ü—Í
                Vector2 pos = transform.position;
                pos.x -= speed;
                transform.position = pos;
                GetComponent<SpriteRenderer>().sortingOrder = -1;
            }
            else
            {
                PostImg.color = new Color(1, 1, 1,1);

                for (int i = 0; i < 6; i++)
                {
                    if (correctAnswers[i] == true)
                    {
                        Itemimg[i].color = new Color(1, 1, 1, 1);
                    }
                }
            }
        }
        else if (transform.position.x > waitPosition.x)
        {
            //“ñ‘Ì–Ú‚ÌˆÚ“®“ü—Í
            Vector2 pos = transform.position;
            pos.x -= speed;
            transform.position = pos;
            GetComponent<SpriteRenderer>().sortingOrder = -2;
           
        }



    }
    public void ZonbiBack()
    {
        backflg = true;
    }

    public void ItemReset()
    {
        for (int i = 0; i < 6; i++)
        {

            img = Random.Range(0, 2);
            correctAnswers[i] = System.Convert.ToBoolean(img);
            Itemimg[i].color = new Color(1, 1, 1, 0);
            if (correctAnswers[i] == false)
            {
                ItemCnt++;
            }
        }
        if (ItemCnt == 6)
        {
            ItemCnt = 0;
            ItemReset();
        }
    }
}
