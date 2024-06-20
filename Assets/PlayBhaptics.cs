using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bhaptics.SDK2;
public class PlayBhaptics : MonoBehaviour
{
    public void playHaptics()
    {
        BhapticsLibrary.Play("r_index");
    }
}
