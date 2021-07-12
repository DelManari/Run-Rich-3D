
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private HealthBar healthBar;

    [SerializeField]
    private Animator anim;

    [SerializeField]
    private GameObject startButton;

    [SerializeField]
    private TextMeshProUGUI scoreUi;

    public static float score = 40f;
    public static bool gameStarted = false;

    private void Start()
    {
        healthBar.SetSize(score/100);
    }

    
    public void startGame()
    {
        anim.SetTrigger("run");
        gameStarted = true;
        startButton.SetActive(false); 
        AudioManager.instance.PlayMusic("level");

    }
    public void replayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        score = 40;
    }
     void Update()
    {
        scoreUi.text = score.ToString();
    }
}
