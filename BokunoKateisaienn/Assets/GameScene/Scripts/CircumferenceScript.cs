using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CircumferenceScript : MonoBehaviour
{
    //! 太陽・月の回転スピード
    public float fRotateSpeed;


    //! 1日の時間
    private float OnedayHour = 24.0f;
    //! 太陽・月の角度
    private float fAngle;
            
    //! 太陽・月の移動時の半径
    public float fRadiusX;
    public float fRadiusY;

    //! 太陽・月の回転の中心のY座標
    public float fCenterY;
    //! 太陽・月の移動速度
    public float fVelocity;
    //! 太陽フラグ（オフなら月）
    public bool bSun;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Mathf.Cos(fAngle) * fRadiusX, Mathf.Sin(fAngle) * fRadiusY + fCenterY, -1);
        fVelocity = 6.28f / OnedayHour;
    }

    // Update is called once per frame
    void Update()
    {
        //!<    回転
        transform.Rotate(new Vector3(0, 0, fRotateSpeed));

        //!<    時間の取得
        int iHour = System.DateTime.Now.Hour;

        //!<    時間に応じた移動
        if (bSun)
            fAngle = fVelocity * (iHour - 6);
        else
            fAngle = fVelocity * (iHour + 6);
      
        transform.position = new Vector3(Mathf.Cos(fAngle) * fRadiusX, Mathf.Sin(fAngle) * fRadiusY + fCenterY, -1);
    }

    /**
     * @brief   角度を取得する
     * @return  fAngle
     */
    public float GetAngle()
    {
        return fAngle;
    }
}
