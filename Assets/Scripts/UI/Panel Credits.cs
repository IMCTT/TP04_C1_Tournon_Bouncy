// Error: el archivo se llama "Panel Credits.cs" y la clase CreditsPanel. Unity busca dentro de cada .cs una clase con el mismo nombre que el archivo; cuando no la encuentra, el componente no se puede agregar y los que ya están puestos pueden aparecer como Missing Script.
// Lo mismo pasa con "Panel Settings.cs" (clase SettingsPanel). Renombrá los dos desde el Project de Unity, y de paso sacales el espacio: los archivos de C# no deberían llevarlo.
using UnityEngine;
using UnityEngine.UI;


public class CreditsPanel : MonoBehaviour

{
    [Header("Panels")]
    [SerializeField] public GameObject mainPanel;
    [SerializeField] public  GameObject creditsPanel;
    


    [Header("Credits")]

    [SerializeField] private Button creditsbackButton;

    //link a PanelMain & SettingsPanel
    PanelMain PanelMain;
    SettingsPanel SettingsPanel;

    private void Awake()
    {
      
        creditsbackButton.onClick.AddListener(OncreditsbackButtonClicked);
 
    }


    private void OnDestroy()
    {
        creditsbackButton.onClick.RemoveListener(OncreditsbackButtonClicked);
    
    }

    private void OncreditsbackButtonClicked()
    {
        creditsPanel.SetActive(false);
        mainPanel.SetActive(true);
    }


}