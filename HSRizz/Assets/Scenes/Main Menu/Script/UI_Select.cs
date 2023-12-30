using UnityEngine;
using UnityEngine.UI;

public class UI_Select : MonoBehaviour
{
    [Header("Select")]
    public Button left_button;
    public Button right_button;
    public Text active_item;

    public int active_index = 0;
    public string[] options;

    void Start()
    {
        if(options.Length > 2){
            active_index = PlayerPrefs.GetInt("volume");
            active_item.text = options[PlayerPrefs.GetInt("volume")];
        }
        left_button.onClick.AddListener(delegate { change_selected_option(-1); });
        right_button.onClick.AddListener(delegate { change_selected_option(1); });
    }

    void change_selected_option(int n)
    {
        active_index += n;
        if (active_index >= options.Length)
            active_index = 0;
        else if (active_index <= -1)
            active_index = options.Length - 1;

        active_item.text = options[active_index];

        if(options.Length > 2){
            PlayerPrefs.SetInt("volume", active_index);
        }
        else{
            Screen.fullScreen = !Screen.fullScreen;
        }
    }

}
