using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCameraProvider : ICameraProvider
{
    public Camera GetMainCamera()
    {
        return Camera.main;
    }

    public Vector2 GetScreenBounds()
    {
        Camera cam = GetMainCamera();
        if (cam == null)
        {
            Debug.LogError("No main camera found in scene!");
            return Vector2.zero;
        }

        return cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));
    }
}
