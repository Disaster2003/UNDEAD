using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeforeOnDestroy : MonoBehaviour
{
    private void OnDestroy()
    {
        // クリック音ON
        GameManager.isPlayed = true;
    }
}
