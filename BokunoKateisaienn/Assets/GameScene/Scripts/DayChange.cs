using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayChange : MonoBehaviour
{
    SpriteRenderer m_SpriteRenderer;

    [SerializeField]
    private float m_fDayTime;     //! 一日の時間

    // Start is called before the first frame update
    void Start()
    {
        //!<    SpriteRendererの取得
        m_SpriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //!<    時間の取得
        float fTime = (Time.time + m_fDayTime * 0.5f) % m_fDayTime;
        float tmp = Mathf.PI * fTime / m_fDayTime;
        float brightness =  1.0f - (Mathf.Sin(tmp) * 0.7f);
        m_SpriteRenderer.color = new Color(brightness, brightness, 1.0f, 1.0f);
    }
}
