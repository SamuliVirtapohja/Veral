using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour {

    public GameObject options, mainmenu, loadmenu;

    public void Exit()
    {
        // lopettaa sovelluksen
        Application.Quit();
    }

    public void Loadgame()
    {

        loadmenu.SetActive(true);
        mainmenu.SetActive(false);

    }

    public void Newgame()
    {
        // lataa scenen 1
        SceneManager.LoadScene(1);
    }

    public void Options()
    {
        // asettaa halutut osat aktiivisiksi
        mainmenu.SetActive(false);
        options.SetActive(true);

    }

    public void Back()
    {
        // asettaa halutut osat aktiivisiksi
        mainmenu.SetActive(true);
        loadmenu.SetActive(false);
        options.SetActive(false);

    }


    


}
