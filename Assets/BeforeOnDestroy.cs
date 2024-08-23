using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeforeOnDestroy : MonoBehaviour
{
    private void OnDestroy()
    {
        // ƒNƒŠƒbƒN‰¹ON
        GameManager.isPlayed = true;
    }
}
