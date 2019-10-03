using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StableAspect : MonoBehaviour
{
    //! 画面の縦のサイズ
    private float fDevelopWidth = 1080.0f;
    //! 画面の横のサイズ
    private float fDevelopHeight = 2160.0f;

    // Start is called before the first frame update
    void Start()
    {
        //! 縦画面の縦横比の取得
        float developAspect = fDevelopWidth / fDevelopHeight;
        //! 実機の縦横比の取得
        float deviceAspect = (float)Screen.width / (float)Screen.height;

        float scale = deviceAspect / developAspect;

        Camera mainCamera = Camera.main;

        float deviceSize = mainCamera.orthographicSize;
        float deviceScale = 1.0f / scale;
        mainCamera.orthographicSize = deviceSize * deviceScale;

    }

}
