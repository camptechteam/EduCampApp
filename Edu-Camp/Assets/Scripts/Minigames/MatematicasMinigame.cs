using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MatematicasMinigame : MonoBehaviour
{
    public SceneController SceneController;

    public TMP_Text question;
    public TMP_Text option1_btn;
    public TMP_Text option2_btn;
    public TMP_Text round_label;

    bool option1_is_correct;
    bool option2_is_correct;

    int max_rounds = 5;
    int round = 1;

    void create_round()
    {
        int first_value = Random.Range(0, 50);
        int second_value = Random.Range(0, 50);

        int correct_option = first_value + second_value;
        int incorrect_option;
        
        bool incorrect_interval_is_superior = (Random.Range(1, 100) < 50);
        if (incorrect_interval_is_superior)
        {
            incorrect_option = Random.Range(correct_option + 1, correct_option + 5);
        }
        else
        {
            incorrect_option = Random.Range(correct_option - 1, correct_option - 5);
        }

        // basicamente la respuesta incorrecta, es un intervalo de la respuesta correcta - 5, hasta la
        // respuesta correcta + 5, es un rango entre esos valores

        if (incorrect_option < 0)
        {
            // al ser una respuesta incorrecta y que el intervalo tienda a una posiblidad de que sea menor que 0
            // eliminamos esa posibilidad con la condicion, y colocamos un random entre 1 y 5, para colocar Aleatoreidad

            incorrect_option = Random.Range(0, 5);
        }

        round_label.text = $"Habitación {round}/{max_rounds}";
        question.text = $"{first_value} + {second_value} = ?";

        // Elejir Aleatoriamente el boton correcto y el boton incorrecto
        bool firstbtn_correct = (Random.Range(0, 1) == 1);
        
        option1_is_correct = (firstbtn_correct);
        option2_is_correct = !(firstbtn_correct);
        
        if(firstbtn_correct)
        {
            // boton de lado izquierdo es correcto y el derecho incorrecto
            option1_btn.text = $"{correct_option}";
            option2_btn.text = $"{incorrect_option}";
        } 
        else
        {
            // boton de lado izquierdo es incorrecto y el derecho correcto
            option1_btn.text = $"{incorrect_option}";
            option2_btn.text = $"{correct_option}";
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
            SceneController.goToScene("GameOverScreen");
            round = 0;
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
