using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField]
    private HealthBar healthBar;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("gold"))
        {
            Destroy(other.gameObject);
            GameManager.score += 10;
            AudioManager.instance.PlaySFX("good");
            healthBar.SetSize(GameManager.score / 100);

        }
        if (other.tag.Equals("calculator"))
        {
            Destroy(other.gameObject);
            GameManager.score += 15;
            AudioManager.instance.PlaySFX("good");
            healthBar.SetSize(GameManager.score / 100);

        }
        if (other.tag.Equals("bad1"))
        {
            Destroy(other.gameObject);
            GameManager.score -= 20;
            AudioManager.instance.PlaySFX("bad");
            healthBar.SetSize(GameManager.score / 100);

        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Destroy(collision.collider);
            GameManager.score -= 10;
            AudioManager.instance.PlaySFX("bad");
            healthBar.SetSize(GameManager.score / 100);
        }

    }
}
