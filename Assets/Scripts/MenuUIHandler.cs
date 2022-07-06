using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    public TMP_InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text = "Highscore - " + SessionData.Instance.playerName + " : " + SessionData.Instance.highScore;
    }

    //--->  ESTE METODO CARGA LA ESCENA 1 (2da en el orden) ESTABLECIDA EN LAS CONFIGURACIONES DEL PROYECTO
    public void StartNew()
    {
        SessionData.Instance.currentPlayerName = inputField.text;
        SceneManager.LoadScene(1);
    }


    public void Exit()
    {
        //----> COMPILACION CONDICIONAL, SI ESTA EJECUTANDO DESDE EL EDITOR DE UNITY SACARA EL PLAY MODE 
        //---> SI SE ESTA EJECUTANDO YA COMPILADO SE DEBE CERRAR LA APP
        //-->   CON # SE LE ENVIA UNA INSTRUCCION AL COMPILADOR 
        #if UNITY_EDITOR
                EditorApplication.ExitPlaymode();
        #else
                        Application.Quit(); // original code to quit Unity player
        #endif
    }

}
