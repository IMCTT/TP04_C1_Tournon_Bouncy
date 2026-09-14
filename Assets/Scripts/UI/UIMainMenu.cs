using UnityEngine;
using UnityEngine.UI;

    public class UIMainMenu : MonoBehaviour

    {
        [Header("Panels")]

        [SerializeField] private GameObject mainPanel;
        [SerializeField] private GameObject settingsPanel;
        [SerializeField] private GameObject creditsPanel;

        [Header("Main Menu")]

        [SerializeField] private Button playButton;
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button creditsButton;
        [SerializeField] private Button exitButton;


        [Header("Settings")]
        [SerializeField] private Button settingsbackButton;
        [SerializeField] private Slider sliderSpeedPlayer1;
        [SerializeField] private Slider sliderSpeedPlayer2;

        [Header("Credits")]
        
        [SerializeField] private Button creditsbackButton;

        [Header("Players")]
        
        [SerializeField] private GameObject player1;
        [SerializeField] private GameObject player2;
 

        






    private void Awake()
    {
        playButton.onClick.AddListener(OnplayButtonClicked);
        settingsButton.onClick.AddListener(OnsettingsButtonClicked);
        creditsButton.onClick.AddListener(OncreditsButtonClicked);
        settingsbackButton.onClick.AddListener (OnsettingsbackButtonClicked);
        creditsbackButton.onClick.AddListener(OncreditsbackButtonClicked);
        exitButton.onClick.AddListener(OnexitButtonClicked);
        sliderSpeedPlayer1.onValueChanged.AddListener(OnSpeedPlayer1Changed);
        sliderSpeedPlayer2.onValueChanged.AddListener(OnSpeedPlayer2Changed);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) 
        {
            if (!mainPanel.activeSelf)
            {
                mainPanel.SetActive(true);
            }
        }


      }


    private void OnDestroy()
    {
        playButton.onClick.RemoveListener(OnplayButtonClicked);
        settingsButton.onClick.RemoveListener(OnsettingsButtonClicked);
        sliderSpeedPlayer1.onValueChanged.RemoveAllListeners();
        sliderSpeedPlayer2.onValueChanged.RemoveAllListeners();
    }



    private void OnplayButtonClicked()
    {
        mainPanel.SetActive(false);
    }
    private void OnsettingsButtonClicked()
    {
        mainPanel.SetActive(false);
        settingsPanel.SetActive(true);

    }
    private void OncreditsButtonClicked()
    {
            if (mainPanel.activeSelf)
            {
                mainPanel.SetActive(false);
                creditsPanel.SetActive(true);

            }
            else if (creditsPanel.activeSelf)
                    creditsPanel.SetActive(true);
    }
    private void OnsettingsbackButtonClicked()
    {
        settingsPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    private void OncreditsbackButtonClicked()
    {
        creditsPanel.SetActive(false);
        mainPanel.SetActive(true);
    }
        private void OnexitButtonClicked()
    {
        Application.Quit();
//#if UNITY_EDITOR
               // UnityEditor.EditorApplication.isPlaying = false;
//#endif

    }

    private void OnSpeedPlayer1Changed(float speed)    
    {
        
        ///player1Speedtext = speed.ToString();

    }
    private void OnSpeedPlayer2Changed(float speed)
    {
        

    }
    

    
}