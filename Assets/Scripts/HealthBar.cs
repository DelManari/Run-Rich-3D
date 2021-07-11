using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Transform bar;
    public Material mat;
    public Texture m_MainTexture1, m_MainTexture2, m_MainTexture3;

    public void SetSize(float sizeNormalized)
    {
        if(sizeNormalized >= .5f && sizeNormalized < .8f)
        {
            bar.GetComponentInChildren<SpriteRenderer>().color = Color.yellow;
            mat.SetTexture("_MainTex", m_MainTexture1);
        }
        if (sizeNormalized < .5f )
        {
            AudioManager.instance.PlaySFX("fifty");
            bar.GetComponentInChildren<SpriteRenderer>().color = Color.red;
            mat.SetTexture("_MainTex", m_MainTexture2);

        }
        if (sizeNormalized >= .8f)
        {
            bar.GetComponentInChildren<SpriteRenderer>().color = Color.green;
            mat.SetTexture("_MainTex", m_MainTexture3);

        }

        bar.localScale = new Vector3(sizeNormalized, 1f);
    }

}
