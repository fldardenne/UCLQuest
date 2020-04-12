using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterMindController : MonoBehaviour
{
    private int num;

    private int countGuess;

    [SerializeField]
    private Text text;

    [SerializeField]
    private Text prev;

    [SerializeField]
    private InputField input;

    [SerializeField]
    private Text prev2;
    [SerializeField]
    private Text prev3;
    [SerializeField]
    private Text essaiprev;
    [SerializeField]
    private Text essaiprev2;
    [SerializeField]
    private Text essaiprev3;
    [SerializeField]
    private Text prev11;
    [SerializeField]
    private Text prev21;
    [SerializeField]
    private Text prev31;
    [SerializeField]
    private Text prev41;
    [SerializeField]
    private Text prev12;
    [SerializeField]
    private Text prev22;
    [SerializeField]
    private Text prev32;
    [SerializeField]
    private Text prev42;
    [SerializeField]
    private Text prev13;
    [SerializeField]
    private Text prev23;
    [SerializeField]
    private Text prev33;
    [SerializeField]
    private Text prev43;
    [SerializeField]
    private GameObject ret; 

    int value;

    void Awake()
    {
        num = 3196; //code du pc
        text.text = "Devine le code à 4 chiffres du pc";
        prev.text = "";
        prev2.text = "";
        prev3.text = "";
        prev11.text = "";
        prev21.text = "";
        prev31.text = "";
        prev41.text = "";
        prev12.text = "";
        prev22.text = "";
        prev32.text = "";
        prev42.text = "";
        prev13.text = "";
        prev23.text = "";
        prev33.text = "";
        prev43.text = "";
        essaiprev.text = "Essai précédent";
        essaiprev2.text = "Essai précédent";
        essaiprev3.text = "Essai précédent";
    }
    public void GetInput(string guess) {
        //Debug.Log("Texte entré : " + guess);
        if (guess.Length < 4)
        {
            text.text = "Le code inséré est trop petit, il doit contenir 4 chiffres";
        }
        else {
            CompareGuesses(guess);
        }
        input.text = "";
    }

    void CompareGuesses(string guess) {
        if (int.TryParse(guess, out value)) {
            
            //actualise historique
            prev3.text = prev2.text;
            prev2.text = prev.text;
            prev.text = guess.ToString();
            prev13.text = prev12.text;
            prev23.text = prev22.text;
            prev33.text = prev32.text;
            prev43.text = prev42.text;
            prev12.text = prev11.text;
            prev22.text = prev21.text;
            prev32.text = prev31.text;
            prev42.text = prev41.text;

            if (int.Parse(guess[0].ToString()) < 3)
            { //compare le premier chiffre
                prev11.text = "<";
            }
            else if (int.Parse(guess[0].ToString()) > 3) {
                prev11.text = ">";
            }
            else if (int.Parse(guess[0].ToString()) == 3)
            {
                prev11.text = "=";
            }
            if (int.Parse(guess[1].ToString()) < 1)
            { //compare le second chiffre
                prev21.text = "<";
            }
            else if (int.Parse(guess[1].ToString()) > 1)
            {
                prev21.text = ">";
            }
            else if (int.Parse(guess[1].ToString()) == 1)
            {
                prev21.text = "=";
            }
            if (int.Parse(guess[2].ToString()) < 9)
            { //compare le troisieme chiffre
                prev31.text = "<";
            }
            else if (int.Parse(guess[2].ToString()) > 9)
            {
                prev31.text = ">";
            }
            else if (int.Parse(guess[2].ToString()) == 9)
            {
                prev31.text = "=";
            }
            if (int.Parse(guess[3].ToString()) < 6)
            { //compare le quatrieme chiffre
                prev41.text = "<";
            }
            else if (int.Parse(guess[3].ToString()) > 6)
            {
                prev41.text = ">";
            }
            else if (int.Parse(guess[3].ToString()) == 6)
            {
                prev41.text = "=";
            }
            if (guess == "3196") {
                text.text = "Bravo tu as récupéré le programme !";
                ret.SetActive(true);
                
            }
        }
        else {
            text.text = "Le code est composé de chiffres pas de lettres !";
        } 
    }
}
