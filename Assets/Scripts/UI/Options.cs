using playerMovement;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;




public class Options : MonoBehaviour
{



    [SerializeField] Movement player1;
    [SerializeField] Movement player2;

  
    [SerializeField] Button optionsbackButton;
    [SerializeField] GameObject optionsPanel;
    [SerializeField] GameObject mainPanel;

    [Header("Speed")]
    [SerializeField] private Slider sliderSpeedPlayer1;
    [SerializeField] private TMP_Text player1Text;
    [SerializeField] private Slider sliderSpeedPlayer2;
    [SerializeField] private TMP_Text player2Text;

    [Header("Height")]
    [SerializeField] private Slider sliderHeightPlayer1;
    [SerializeField] private TMP_Text playerHeightText;

    [Header("Color")]
    private SpriteRenderer colorP1;
    private SpriteRenderer colorP2;
    [SerializeField] private Button colorPreset1;
    [SerializeField] private Button colorPreset2;
    [SerializeField] private Button colorPreset3;
    [SerializeField] private Button colorPreset4;
    [SerializeField] private Button colorDefault;

    private void Awake()
    {
        
        optionsbackButton.onClick.AddListener(OnOptionsBackButtonClicked);

        colorP1 = player1.GetComponent<SpriteRenderer>();
        colorP2 = player2.GetComponent<SpriteRenderer>();
        colorPreset1.onClick.AddListener(SetPlayerColor1);
        colorPreset2.onClick.AddListener(SetPlayerColor2);
        colorPreset3.onClick.AddListener(SetPlayerColor3);
        colorPreset4.onClick.AddListener(SetPlayerColor4);
        colorDefault.onClick.AddListener(SetPlayerColorDefault);

        sliderSpeedPlayer1.onValueChanged.AddListener(SetPlayer1Speed);
        sliderSpeedPlayer2.onValueChanged.AddListener(SetPlayer2Speed);

        sliderHeightPlayer1.onValueChanged.AddListener(SetPlayerHeight);


    }


    private void OnDestroy()
    {

        sliderSpeedPlayer1.onValueChanged.RemoveAllListeners();
        sliderSpeedPlayer2.onValueChanged.RemoveAllListeners();
        sliderHeightPlayer1.onValueChanged.RemoveAllListeners();
    }


    private void OnOptionsBackButtonClicked()
    {
        optionsPanel.SetActive(false);
        mainPanel.SetActive(true);
      
    }


    private void SetPlayer1Speed(float newSpeed)
    {
        player1.SetMovementSpeed(newSpeed);
        player1Text.text = newSpeed.ToString("F2");
    }
    private void SetPlayer2Speed(float newSpeed)
    {
        player2.SetMovementSpeed(newSpeed);
        player2Text.text = newSpeed.ToString("F2");
    }

    private void SetPlayerHeight(float newHeight)
    {
        player1.transform.localScale = new Vector3(0.38f, newHeight, 0.76f);
        player2.transform.localScale = new Vector3(0.38f, newHeight, 0.76f);
        playerHeightText.text = newHeight.ToString("F2");
    }


    private void SetPlayerColor1()
    {
        colorP1.color = UnityEngine.Color.red;
        colorP2.color = UnityEngine.Color.blue;
    }

    private void SetPlayerColor2()
    {
        colorP1.color = UnityEngine.Color.blue;
        colorP2.color = UnityEngine.Color.gray;

    }
    private void SetPlayerColor3()
    {
        colorP1.color = UnityEngine.Color.green;
        colorP2.color = UnityEngine.Color.yellow;
    }

    private void SetPlayerColor4()
    {
        colorP1.color = UnityEngine.Color.gray;
        colorP2.color = UnityEngine.Color.red;
    }
    private void SetPlayerColorDefault()
    {
        colorP1.color = UnityEngine.Color.white;
        colorP2.color = UnityEngine.Color.white;
    }
}
