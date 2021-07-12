using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField]
    private HealthBar healthBar;
    [SerializeField]
    private GameObject particlePrefab;
    [SerializeField]
    private ParticleSystem ps;
    TextMesh textM;

    private void Start()
    {
        textM = particlePrefab.GetComponentInChildren<TextMesh>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("gold"))
        {
            Destroy(other.gameObject);
            GameManager.score += 10;
            AudioManager.instance.PlaySFX("good");
            textM.text = "+10";
            textM.color = Color.green;
            Instantiate(particlePrefab, new Vector3(transform.position.x + 1f,transform.position.y + 1f, transform.position.z), Quaternion.Euler(0f, -180f, 0f));
            ps.Stop();
            ps.Play();
            healthBar.SetSize(GameManager.score / 100);

        }
        if (other.tag.Equals("calculator"))
        {
            Destroy(other.gameObject);
            GameManager.score += 15;
            AudioManager.instance.PlaySFX("good");
            textM.text = "+15";
            textM.color = Color.green;
            Instantiate(particlePrefab, new Vector3(transform.position.x + 1f, transform.position.y + 1f, transform.position.z), Quaternion.Euler(0f, -180f, 0f));
            healthBar.SetSize(GameManager.score / 100);
            ps.Stop();
            ps.startColor = Color.yellow;
            ps.Play();

        }
        if (other.tag.Equals("bad1"))
        {
            Destroy(other.gameObject);
            GameManager.score -= 20;
            AudioManager.instance.PlaySFX("bad");
            textM.text = "-20";
            textM.color = Color.red;
            Instantiate(particlePrefab, new Vector3(transform.position.x + 1f, transform.position.y + 1f, transform.position.z), Quaternion.Euler(0f, -180f, 0f));
            healthBar.SetSize(GameManager.score / 100);
            ps.Stop();
            ps.startColor = Color.red;
            ps.Play();

        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Destroy(collision.collider);
            GameManager.score -= 10;
            textM.text = "-10";
            textM.color = Color.red;
            ps.Stop();
            ps.startColor = Color.red;
            ps.Play();
            Instantiate(particlePrefab, new Vector3(transform.position.x + 1f, transform.position.y + 1f, transform.position.z), Quaternion.Euler(0f, -180f, 0f));
            AudioManager.instance.PlaySFX("bad");
            healthBar.SetSize(GameManager.score / 100);
        }

    }
}
