using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [Header("Rotation")]

    [SerializeField] private float rotation = 10.0f;
    // Bug: keyrotright y keyrotleft son D y A, exactamente las mismas teclas que Movement.keyRight y Movement.keyLeft, y los dos scripts están en el mismo objeto de la escena.
    // Así que moverse en horizontal hace girar la paleta al mismo tiempo. Cambialas por Q y E, que es lo que venía del TP01, o sacá este script del Pong.
    [SerializeField] private KeyCode keyrotright = KeyCode.D;
    [SerializeField] private KeyCode keyrotleft = KeyCode.A;

    private Rigidbody2D rb2D;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Rotation();
    }

    private void Rotation()
    {
        if (Input.GetKeyDown(keyrotright))
        {
            rb2D.AddTorque(rotation * Time.deltaTime,ForceMode2D.Force);
        }
        if (Input.GetKeyDown(keyrotleft))
        {
            rb2D.AddTorque(-rotation * Time.deltaTime, ForceMode2D.Force);
        }
    }
}