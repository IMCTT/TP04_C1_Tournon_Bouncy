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
        if (Input.GetKeyDown(KeyCode.Space))
        {

            ball.rb.AddForce(initialForce, ForceMode2D.Impulse);
            ball.rb.AddForce(initialForce);
            
        }
        
    }
    
 

  

}

