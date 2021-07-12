using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Transform bar;
    [SerializeField]
    private TextMeshPro textCase;

    public Material mat;
    public Texture m_MainTexture1, m_MainTexture2, m_MainTexture3;

    public void SetSize(float sizeNormalized)
    {

        if (sizeNormalized >= .5f && sizeNormalized < .8f)
        {
            bar.GetComponentInChildren<SpriteRenderer>().color = Color.yellow;
            mat.SetTexture("_MainTex", m_MainTexture1);


            textCase.text = "DECENT";
            textCase.color = Color.yellow;
        }
        if (sizeNormalized < .5f && sizeNormalized >= .3f)
        {
            AudioManager.instance.PlaySFX("fifty");
            bar.GetComponentInChildren<SpriteRenderer>().color = Color.red;
            mat.SetTexture("_MainTex", m_MainTexture2);


            textCase.text = "POOR";
            textCase.color = Color.yellow;
        }
        if(sizeNormalized < .3f)
        {
            bar.GetComponentInChildren<SpriteRenderer>().color = Color.white;
            mat.SetTexture("_MainTex", m_MainTexture2);
            
            print(mat.mainTexture.name + ": " + sizeNormalized);

            textCase.text = "Ultra POOR";
            textCase.color = Color.gray;
        }
    
        if (sizeNormalized >= .8f)
        {
            bar.GetComponentInChildren<SpriteRenderer>().color = Color.green;
            mat.SetTexture("_MainTex", m_MainTexture3);

            textCase.text = "RICH";
            textCase.color = Color.green;


        }

        bar.localScale = new Vector3(sizeNormalized, 1f);
    }

}
