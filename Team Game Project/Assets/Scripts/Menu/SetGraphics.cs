using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGraphics : MonoBehaviour
{
    public void SetQuality (int quality)
    {
        QualitySettings.SetQualityLevel(quality);
    }
}
