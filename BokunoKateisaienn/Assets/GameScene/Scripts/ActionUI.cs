using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionUI : MonoBehaviour
{
    public float m_fCollideArea;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //! タッチが離されたら
        if (InputManager.GetTouch() == TouchInfo.Ended)
        {
            //! タッチされた座標を取得
            if(InputManager.GetTouchPosition() == this.transform.position)
            {

            }
        }
    }
}
