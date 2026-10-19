using System;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;


namespace playerMovement
{
    public class Movement : MonoBehaviour
    {
        [Header("Movement")] [SerializeField] public float Speed = 10000.0f;
        [SerializeField] private KeyCode keyup = KeyCode.W;
        [SerializeField] private KeyCode keydown = KeyCode.S;
        [SerializeField] private KeyCode keyLeft = KeyCode.A;
        [SerializeField] private KeyCode keyRight = KeyCode.D;
        [SerializeField] LayerMask ballMask;
        [SerializeField] LayerMask wallMask;
        private Rigidbody2D rigidbody2d;
        private SpriteRenderer spriteRenderer;
        [SerializeField] private int player = 0;


        private void Awake()
        {
            rigidbody2d = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void Update()
        {
            Move();
            LimitX();
        }

        // Warning: Move() se llama desde el Update, no desde el FixedUpdate, y aplica AddForce con ForceMode2D.Impulse multiplicado por Time.deltaTime. Las llamadas de física van en FixedUpdate, y un Impulse no se multiplica por delta: ya es un golpe instantáneo.
        // Mové la llamada a FixedUpdate y usá ForceMode2D.Force sin el deltaTime. Con eso vas a poder bajar Speed, que hoy está en 10000.
        public void Move()
        {
            if (Input.GetKey(keyup))
            {
                rigidbody2d.AddForce(Vector2.up * Speed * Time.deltaTime, ForceMode2D.Impulse);
            }

            if (Input.GetKey(keydown))
            {
                rigidbody2d.AddForce(Vector2.down * Speed * Time.deltaTime, ForceMode2D.Impulse);
            }

            if (Input.GetKey(keyLeft))
            {
                rigidbody2d.AddForce(Vector2.left * Speed * Time.deltaTime, ForceMode2D.Impulse);
            }

            if (Input.GetKey(keyRight))
            {
                rigidbody2d.AddForce(Vector2.right * Speed * Time.deltaTime, ForceMode2D.Impulse);
            }
        }


        public void SetMovementSpeed(float newSpeed)
        {
            if (newSpeed > 20000)
                return;
            Speed = newSpeed;
        }

        public float GetMovementSpeed()
        {
            return Speed;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (CheckLayerInMask(ballMask, other.gameObject.layer))
            {
                Debug.Log("toco bola");
                float r = Random.value;
                float g = Random.value;
                // Suggestion: el alpha de un UnityEngine.Color va de 0 a 1, no de 0 a 255. El 255 se clampea a 1 así que no rompe nada, pero da a entender otra cosa.
                // Escribilo como 1f, o usá el constructor de tres parámetros que ya deja el alpha en 1.
                float b = Random.value;
                spriteRenderer.color = new UnityEngine.Color(r, g, b, 255f);
            }
            else if (CheckLayerInMask(wallMask, other.gameObject.layer))
            {
                Debug.Log("toco pared");
                spriteRenderer.color = new UnityEngine.Color(0, 0, 0, 255f);
            }
        }
// Warning: el objeto tiene Rigidbody2D y acá se escribe transform.position, que lo teletransporta salteando la detección de colisiones. Además, la velocidad acumulada no se cancela, así que el jugador sigue empujando contra el centro.
// Usá rigidbody2d.position y ponele la componente X de la velocidad en cero cuando corregís.

        private void LimitX()
        {
            if (player == 1 && transform.position.x >= 0.01f)
            {
                transform.position = new Vector2(0f, transform.position.y);
            }
            else if (player == 2 && transform.position.x <= -0.01f)
            {
                transform.position = new Vector2(0f, transform.position.y);
            }
        }

        public static bool CheckLayerInMask(LayerMask mask, int layer)
        {
            return mask == (mask | (1 << layer));
        }
    }
}