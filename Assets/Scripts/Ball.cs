
using TMPro;
using UnityEngine;

public class Ball : MonoBehaviour
{
    
    [SerializeField] private float bounce = 1.05f;
    [SerializeField] LayerMask playerMask;
    [SerializeField] public LayerMask leftGoalMask;
    [SerializeField] public LayerMask rightGoalMask;
     
    [SerializeField] private TMP_Text leftscorePoints;
    [SerializeField] private TMP_Text rightscorePoints;
    public GameDataSo data;

    private int player1Score = 0;
    private int player2Score = 0;
    
    public Rigidbody2D rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (CheckLayerInMask(playerMask, other.gameObject.layer))
        {
            Debug.Log("toco jugador");
            Vector2 direction = rb.linearVelocity.normalized;

            rb.AddForce(direction * bounce, ForceMode2D.Impulse);
        }
        else if (CheckLayerInMask(leftGoalMask, other.gameObject.layer))
        {

            SetTransformX();


            rb.linearVelocity = Vector2.zero;
            rightScore++;
            
            AddPoint(1);


        }
        else if (CheckLayerInMask(rightGoalMask, other.gameObject.layer))
        {

            SetTransformX();


            rb.linearVelocity = Vector2.zero;
            AddPoint(2);
            leftScore++;
            leftscorePoints.text = leftScore.ToString();

        }

    }
    void SetTransformX()
    {
        transform.position = new Vector2(0, 0);
    }

    public static bool CheckLayerInMask(LayerMask mask, int layer)
    {
        return mask == (mask | (1 << layer));
    }
    public void AddPoint(int player)
    {
        if (player == 1) player1Score++;
        {
            rightscorePoints.text = player1Score.ToString();
        }
        else player2Score++;

        if (player1Score >= data.pointsToWin || player2Score >= data.pointsToWin)
        {
            Debug.Log($"Gana el jugador {(player1Score > player2Score ? 1 : 2)}");
        }
    }

}
