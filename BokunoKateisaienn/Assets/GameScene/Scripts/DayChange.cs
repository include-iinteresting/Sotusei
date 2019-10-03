using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayChange : MonoBehaviour
{
    SpriteRenderer m_SpriteRenderer;

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
        int iHour = (System.DateTime.Now.Hour + 12) % 24;
        float tmp = Mathf.PI * iHour / 24.0f;
        float brightness =  1.0f - (Mathf.Sin(tmp) * 0.7f);
        m_SpriteRenderer.color = new Color(brightness, brightness, 1.0f, 1.0f);
    }
}
