using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;



public class Pausedmenu : MonoBehaviour {

    public GameObject options, pausedmenu, savedmenu, loadmenu;


    public void Exit()
    {
        // lopettaa sovelluksen
        Application.Quit();
    }

   
    public void Continue()
    {
        // peli jatkuu
        pausedmenu.SetActive(false);
        Cursor.visible = false;
        Time.timeScale = 1;
    }

    public void Options()
    {
        // asettaa halutut osat aktiivisiksi
        pausedmenu.SetActive(false);
        options.SetActive(true);
        
    }

    public void Back()
    {
        // asettaa halutut osat aktiivisiksi
        pausedmenu.SetActive(true);
        savedmenu.SetActive(false);
        loadmenu.SetActive(false);
        options.SetActive(false);

    }

    public void Savedgames()
    {
        pausedmenu.SetActive(false);
        savedmenu.SetActive(true);
        
        
    }

    public void Loadgames()
    {
        loadmenu.SetActive(true);
        pausedmenu.SetActive(false);
    }

}

