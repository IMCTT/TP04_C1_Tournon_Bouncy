using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    [SerializeField] private Ball ball;
    [SerializeField] private Vector2 initialForce = new Vector2(5, 1);
    
    
    private void Update()
    {
        // Warning: el saque se dispara con Space y no hay nada que impida apretarlo de nuevo, así que la pelota se puede acelerar indefinidamente. Además se aplican dos AddForce seguidos, uno Impulse y uno Force, lo que hace muy difícil predecir la velocidad de salida.
        // Usá un bool que se ponga en false al sacar y vuelva a true en el Reset de la pelota, y dejá un solo AddForce.
        if (Input.GetKeyDown(KeyCode.Space))
        {

            ball.rb.AddForce(initialForce, ForceMode2D.Impulse);
            ball.rb.AddForce(initialForce);
            
        }
        
    }
    
 

  

}

