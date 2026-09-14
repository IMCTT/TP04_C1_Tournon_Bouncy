using TMPro;
using UnityEngine;
using UnityEngine.UI;
using playerMovement;





public class SettingsPanel : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] public GameObject mainPanel;
    [SerializeField] public GameObject settingsPanel;

    [Header("Settings")]
    [SerializeField] private Button settingsbackButton;
    [SerializeField] private Slider sliderSpeedPlayer1;
    [SerializeField] private Slider sliderSpeedPlayer2;
    [SerializeField] private TMP_Text player1Text;
    [SerializeField] private TMP_Text player2Text;
    [SerializeField] Movement player1;
    [SerializeField] Movement player2;



    private void Awake()
    {
        settingsbackButton.onClick.AddListener(OnsettingsbackButtonClicked);
        
        sliderSpeedPlayer1.onValueChanged.AddListener(SetPlayer1Speed);
        sliderSpeedPlayer2.onValueChanged.AddListener(SetPlayer2Speed);
        
    }


    private void OnDestroy()
    {
        settingsbackButton.onClick.RemoveListener(OnsettingsbackButtonClicked);
        sliderSpeedPlayer1.onValueChanged.RemoveAllListeners();
        sliderSpeedPlayer2.onValueChanged.RemoveAllListeners();
    }


    private void OnsettingsbackButtonClicked()
    {
        settingsPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

   
    public void SetPlayer1Speed(float newSpeed)
    {
        player1.SetMovementSpeed(newSpeed);
        player1Text.text = newSpeed.ToString("F2");
    }
    public void SetPlayer2Speed(float newSpeed)
    {
        player2.SetMovementSpeed(newSpeed);
        player2Text.text = newSpeed.ToString("F2");
    }



}