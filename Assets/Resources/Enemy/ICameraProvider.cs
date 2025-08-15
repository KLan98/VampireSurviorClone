using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICameraProvider 
{
    Camera GetMainCamera();
    Vector2 GetScreenBounds();
}
