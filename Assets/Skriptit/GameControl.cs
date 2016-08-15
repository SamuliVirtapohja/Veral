using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

    public static GameControl control;

    public bool load = false;

    // asioita joita tulee saveen
    public float health, experience;
    public Vector3 charpos;
    private string scene;

    // asettaa xyz floatiksi
    public float charposx { get { return charpos.x; } set { charpos.x = value; } }
    public float charposy { get { return charpos.y; } set { charpos.y = value; } }
    public float charposz { get { return charpos.z; } set { charpos.z = value; } }


    void Awake () {
        // gamecontrol luodaan jos sitä ei ole olemassa
	    if(control == null)
        {
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }

	}


    void OnGUI()
    {

        GUI.Label(new Rect(0, 0, 140, 40), "Health: " + health);
        GUI.Label(new Rect(0, 20, 140, 40), "Experience: " + experience);
    }

    public void Scansaves()
    {
        // hakee kansiosta kaikki .save tiedostot
        DirectoryInfo dir = new DirectoryInfo(Application.persistentDataPath);
        FileInfo[] info = dir.GetFiles("*.save");
        foreach (FileInfo f in info)
        {
            Canvas canvas = (Canvas)FindObjectOfType(typeof(Canvas));
            if (canvas)
            {
                // todo luo listan kaikista .save tiedostoista, joista peli halutaan ladata
                Debug.Log("asd: " + f.Name);
            }

        }

    }


    public void Save()
    {

        // binary formatointi
        BinaryFormatter bf = new BinaryFormatter();
        // tiedostopolku 
        FileStream file = File.Create(Application.persistentDataPath + "/playerinfo2.save");
        PlayerData data = new PlayerData();
        charpos = GameObject.FindGameObjectWithTag("Player").transform.position;
        // tiedot asetetaan
        data.health = health;
        data.experience = experience;
        data.scene = SceneManager.GetActiveScene().name;

        data.charposx = charposx;
        data.charposy = charposy;
        data.charposz = charposz;
        // asettaa tiedot tiedostoon
        bf.Serialize(file, data);
        // sulkee tiedoston
        file.Close();
    }

    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/playerinfo2.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerinfo2.save", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            // asettaa tiedoston tiedot nykyisiksi
            health = data.health;
            experience = data.experience;

            charposx = data.charposx;
            charposy = data.charposy;
            charposz = data.charposz;

            Vector3 charpos = new Vector3(charposx, charposy, charposz);
            transform.position = charpos;
            Debug.Log(charposx + " " + charposy + " " + charposz);
            // todo, ottaa pelaajan, liikuttaa pelaajan charpos positioniin
            load = true;
            SceneManager.LoadScene(data.scene);



            // todo tuhota olemassa olevat GameControllit
            //

            Cursor.visible = false;
            Time.timeScale = 1;
                   
        }


    }


}


[Serializable]
class PlayerData
{
    public float health, experience, charposx, charposy, charposz;
    public string scene;
    
}

