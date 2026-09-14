using UnityEngine;
using UnityEngine.UI;



public class PanelMain : MonoBehaviour

{
    [Header("Panels")]
    [SerializeField] public GameObject mainPanel;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private GameObject Scoreboard;

    [Header("Buttons")]

    [SerializeField] private Button playButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button creditsButton;
    [SerializeField] private Button exitButton;





    private void Awake()
    {
        playButton.onClick.AddListener(OnplayButtonClicked);
        optionsButton.onClick.AddListener(OnOptionsButtonClicked);
        creditsButton.onClick.AddListener(OncreditsButtonClicked);
        exitButton.onClick.AddListener(OnexitButtonClicked);
        Time.timeScale = 0;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!mainPanel.activeSelf)
            {
                mainPanel.SetActive(true);
                Time.timeScale = 0;
            }
        }


    }


    private void OnDestroy()
    {
        playButton.onClick.RemoveListener(OnplayButtonClicked);
        optionsButton.onClick.RemoveListener(OnOptionsButtonClicked);

    }



    private void OnplayButtonClicked()
    {
        mainPanel.SetActive(false);
        Scoreboard.SetActive(true);
        Time.timeScale = 1;
    }
    private void OnOptionsButtonClicked()
    {
        mainPanel.SetActive(false);
        optionsPanel.SetActive(true);

    }
    private void OncreditsButtonClicked()
    {
        if (mainPanel.activeSelf)
        {
            mainPanel.SetActive(false);
            creditsPanel.SetActive(true);

        }
        else if (creditsPanel.activeSelf)
            optionsPanel.SetActive(true);


        Scoreboard.SetActive(false);
    }

    private void OnexitButtonClicked()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

    }

}