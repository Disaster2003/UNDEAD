using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSmoke : MonoBehaviour
{
    public bool isCreated = false;
    [SerializeField] Sprite[] smoke;
    public float changeTimer = 0;

    public float smokeAlpha = 0;

    // Start is called before the first frame update
    void Start()
    {
        // ‰Œ‚ğ”ñ•\¦‚É‚·‚é
        GetComponent<SpriteRenderer>().sprite = smoke[0];
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (isCreated)
        {
            // ‰Œ‚ğ™X‚É“§–¾‚É‚·‚é
            if (GetComponent<SpriteRenderer>().sprite == smoke[1])
            {
                if (smokeAlpha <= 0)
                {
                    smokeAlpha = 0;
                    isCreated = false;
                }
                smokeAlpha -= Time.deltaTime;
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, smokeAlpha);
            }
            // Ÿ‚Ì‰æ‘œ‚Ö
            else if (changeTimer <= 0)
            {
                changeTimer = 0.5f;
                GetComponent<SpriteRenderer>().sprite = smoke[1];
            }
            changeTimer -= Time.deltaTime;
        }
    }
}
