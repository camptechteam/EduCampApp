using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PalabrasMinigame : MonoBehaviour
{
    public PalabrasStorage PalabrasStorage;
    public SceneController SceneController;

    public TMP_Text palabra;
    public TMP_Text round_label;

    public Image option1_btn;
    public Image option2_btn;

    bool option1_is_correct;
    bool option2_is_correct;

    int round = 1;
    int max_rounds = 5;

    void create_round()
    {
        int correct_index = Random.Range(0, PalabrasStorage.palabras.Length);
        string correct_palabra = PalabrasStorage.palabras[correct_index];

        int incorrect_index = PalabrasStorage.get_diferent_index(correct_index);
        string incorrect_palabra = PalabrasStorage.palabras[incorrect_index];

        palabra.text = $"{correct_palabra}";
        round_label.text = $"Habitación {round}/{max_rounds}";

        bool firstbtn_correct = (Random.Range(1, 100) < 50);
        
        option1_is_correct = (firstbtn_correct);
        option2_is_correct = !(firstbtn_correct);

        if(firstbtn_correct)
        {
            // boton de lado izquierdo es correcto y el derecho incorrecto
            option1_btn.sprite = Resources.Load<Sprite>("Sprites/" + correct_palabra);
            option2_btn.sprite = Resources.Load<Sprite>("Sprites/" + incorrect_palabra);
        } 
        else
        {
            option1_btn.sprite = Resources.Load<Sprite>("Sprites/" + incorrect_palabra);
            option2_btn.sprite = Resources.Load<Sprite>("Sprites/"+ correct_palabra);
        }
    }

    void next_round(bool option_pressed_is_correct)
    {
        if (option_pressed_is_correct)
        {
            if (round == max_rounds)
            {
                SceneController.goToScene("WinnerScreen");
            }
            else
            {
                round += 1;
                create_round();
            }
        }
        else
        {
            round = 0;
            SceneController.goToScene("GameOverScreen");
        }
    }

    public void pressed_option_1() 
    {
        next_round(option1_is_correct);
    }

    public void pressed_option_2() 
    {
        next_round(option2_is_correct);
    }

    void Start()
    {
        create_round();
    }
}
