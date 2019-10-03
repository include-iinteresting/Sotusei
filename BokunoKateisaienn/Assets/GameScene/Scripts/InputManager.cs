using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TouchInfo
{
    None = 99,
    Began = 0,
    Moved = 1,
    Stationary = 2,
    Ended = 3,
    Canceled = 4
}


public class InputManager : MonoBehaviour
{
    private static Vector3 TouchPosition = Vector3.zero;

    /**
     * @brief   タッチを情報を取得
     */
    public static TouchInfo GetTouch()
    {
        if (Application.isEditor)
        {
            if (Input.GetMouseButtonDown(0))
                return TouchInfo.Began;
            if (Input.GetMouseButton(0))
                return TouchInfo.Moved;
            if (Input.GetMouseButtonUp(0))
                return TouchInfo.Ended;
        }
        else
        {
            if (Input.touchCount > 0)
            {
                return (TouchInfo)((int)Input.GetTouch(0).phase);
            }
        }

        return TouchInfo.None;
    }
}
