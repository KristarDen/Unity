using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UserMenu : MonoBehaviour
{
    public static bool IsShown;
    public static string ButtonText;
    public Slider SoundSlider;

    public GameObject UserMenuContent;
    public Text bestStatText;
    public Text StatText;

    public GameObject Button;
    public static Text buttonText;

    public static UserMenuMode userMenuMode;

    private const string FILE_BEST_STAT = "best_stat.xml";

    public float SoundSliderValue { get; set; }

    void Start()
    {
        buttonText = Button.GetComponent<Text>();
        IsShown = true;
        buttonText.text = "Start";
        Time.timeScale = IsShown ? 0.0f : 1.0f;
        userMenuMode = UserMenuMode.Start;

        if (File.Exists(FILE_BEST_STAT))
        {
            try
            {
                using (var sr = new StreamReader(FILE_BEST_STAT))
                {
                    XmlSerializer serializer = new XmlSerializer(
                        typeof(List<MoveData>));

                    GameStat.BestMoves = 
                        (List<MoveData>) serializer.Deserialize(sr);

                    ShowBestStat();
                }
            }
            catch (System.Exception ex)
            {
                Debug.LogException(ex);
            }
        }
        ShowBestStat();
        StatText.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsShown)
        {
            switch (userMenuMode)
            {
                case UserMenuMode.Start:
                    buttonText.text = "Start";
                    break;
                case UserMenuMode.GameOver:
                    buttonText.text = "Paly Again";
                    SaveStat();
                    break;
                case UserMenuMode.Pause:
                    buttonText.text = "Continue";
                    break;
            }
        }

        UserMenuContent.SetActive(IsShown);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            IsShown = !IsShown;

            Time.timeScale = IsShown ? 0.0f : 1.0f;
        }
    }

    private void ShowBestStat()
    {
        if (GameStat.BestMoves == null)
        {
            bestStatText.text = "No best stat";
            return;
        }
        string str = "#     K   T   S";
        foreach(var move in GameStat.BestMoves)
        {
            str += $"\n{move.Num} {move.KegelsFall} {move.Time} {move.Score}";
        }
        bestStatText.text = str;
    }
    private void SaveStat()
    {
        try
        {
            using (StreamWriter sw = new StreamWriter(FILE_BEST_STAT))
            {
                XmlSerializer serializer = new XmlSerializer(
                    GameStat.Moves.GetType()); 
                    serializer.Serialize(sw, GameStat.Moves);

            }
        }
        catch(System.Exception ex)
        {
            Debug.LogException(ex);
        }
    }

    public void ButtonClick()
    {
        if(userMenuMode == UserMenuMode.GameOver)
        {
            SceneManager.LoadScene(0);// build index
        }
        else
        {
            IsShown = false;
            Time.timeScale = 1.0f;
        }
        
    }

    public void SoundSliderChange()
    {
        SoundSliderValue = SoundSlider.value;
    }
}

public enum UserMenuMode
{
    Start,
    Pause,
    GameOver
}
