using Unity.VisualScripting;
using UnityEngine;



namespace playerMovement
{

    public class Movement : MonoBehaviour
    {
        [Header("Movement")]

        [SerializeField] public float Speed = 10000.0f;
        [SerializeField] private KeyCode keyup = KeyCode.W;
        [SerializeField] private KeyCode keydown = KeyCode.S;

        private Rigidbody2D rigidbody2d;


        private void Awake()
        {
            rigidbody2d = GetComponent<Rigidbody2D>();
        }

        public void Update()
        {

            Move();

        }

        public void Move()
        {

            if (Input.GetKey(keyup))
            {

                rigidbody2d.AddForce(Vector3.up * Speed * Time.deltaTime, ForceMode2D.Impulse);

            }

            if (Input.GetKey(keydown))
            {
                rigidbody2d.AddForce(Vector3.down * Speed * Time.deltaTime, ForceMode2D.Impulse);
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

    }
}