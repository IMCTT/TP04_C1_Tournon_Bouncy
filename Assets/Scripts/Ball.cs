
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{

    [SerializeField] private float bounce = 1.05f;
    [SerializeField] LayerMask playerMask;
    [SerializeField] public LayerMask leftGoalMask;
    [SerializeField] public LayerMask rightGoalMask;

    [SerializeField] private TMP_Text leftscorePoints;
    [SerializeField] private TMP_Text rightscorePoints;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject goalPanel;
    float timer = 3f;
    bool waiting = true;
    
    
public GameDataSo data;
private float pitytimer = 0f;

    private int player1Score = 0;
    private int player2Score = 0;
    
    public Rigidbody2D rb;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        pitytimer += Time.deltaTime;
        Debug.Log(pitytimer);
        if (pitytimer >= data.goalTimeLimit)
            PityTimer();
        if (!waiting) return;
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            waiting = false;
            goalPanel.SetActive(false);
                
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (CheckLayerInMask(playerMask, other.gameObject.layer))
        {
            Debug.Log("toco jugador");
            Vector2 direction = rb.linearVelocity.normalized;

            rb.AddForce(direction * bounce, ForceMode2D.Impulse);
        }
        else if (CheckLayerInMask(rightGoalMask, other.gameObject.layer))
        {

            
            AddPoint(1);
            
        }
        else if (CheckLayerInMask(leftGoalMask, other.gameObject.layer))
        {

            
            AddPoint(2);
          

        }

    }
    public void Reset()
    {
        
        transform.position = new Vector2(0, 0);
        rb.linearVelocity = Vector2.zero;
        pitytimer = 0f;
    }

    public static bool CheckLayerInMask(LayerMask mask, int layer)
    {
        return mask == (mask | (1 << layer));
    }
    public void AddPoint(int player)
    {
        if (player == 1) 
        {
            player1Score++;
            rightscorePoints.text = player1Score.ToString();
            goalPanel.SetActive(true);
            goalPanel.GetComponentInChildren(typeof(TextMeshProUGUI)).GetComponentInChildren<TextMeshProUGUI>().text = "Goal Player 1!";
            timer = 2f;
            waiting = true;
            Reset();
        }
        else
        {
            player2Score++;
            leftscorePoints.text = player2Score.ToString();
            goalPanel.SetActive(true);
            goalPanel.GetComponentInChildren(typeof(TextMeshProUGUI)).GetComponentInChildren<TextMeshProUGUI>().text = "Goal Player 2!";
            timer = 2f;
            waiting = true;
            Reset();
        }

        if (player1Score >= data.pointsToWin || player2Score >= data.pointsToWin)
        {
            WinCondition();
        }
    }
    void WinCondition()
    {
        if (player1Score >= data.pointsToWin)
        {
            winPanel.SetActive(true);
            winPanel.GetComponentInChildren(typeof(TextMeshProUGUI)).GetComponentInChildren<TextMeshProUGUI>().text = "Player 1 Wins!";
            SceneManager.LoadScene("Main Menu");
        }
        else if (player2Score >= data.pointsToWin)
        {
            winPanel.SetActive(true);
            winPanel.GetComponentInChildren(typeof(TextMeshProUGUI)).GetComponentInChildren<TextMeshProUGUI>().text = "Player 2 Wins!";
            SceneManager.LoadScene("Main Menu");
        }
        
    }

    void PityTimer()
    {
        
        
        if (pitytimer >= data.goalTimeLimit)
        {
            if (transform.position.x >=0)
                AddPoint(1);
            else if (transform.position.x <=0)
                AddPoint(2);
                
        }

        Reset();
    }


}
