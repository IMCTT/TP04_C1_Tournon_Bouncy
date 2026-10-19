using UnityEngine;
using System;




    // Warning: la clase se llama Color, igual que UnityEngine.Color. Por eso adentro de este archivo tenés que escribir UnityEngine.Color y UnityEngine.Random, y en Movement.cs también.
    // Renombrala a ColorChanger o PlayerColor: el nombre de un MonoBehaviour no debería tapar un tipo del motor.
    public class Color : MonoBehaviour
    {

        [SerializeField] private KeyCode C_random = KeyCode.R;
        private SpriteRenderer _color;




        private void Awake()
        {
            _color = GetComponent<SpriteRenderer>();
        }


        private void Update()
        {
         
            //Color random

            if (Input.GetKeyUp(C_random))
            {
                float blue = UnityEngine.Random.Range(0, 1.0f);
                float red = UnityEngine.Random.Range(0, 1.0f);
                float green = UnityEngine.Random.Range(0, 1.0f);
                _color.color = new UnityEngine.Color(blue, red, green);

            }



        }

      
    }

