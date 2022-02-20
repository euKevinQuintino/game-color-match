using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowColor : MonoBehaviour {
    public GameObject colorMeaningTextObject;
    public GameObject textColorTextObject;
    public GameObject textColorBox;
    public Sprite rightAnswerSprite;
    public Sprite wrongAnswerSprite;
    public Sprite defaultSprite;
    public AudioSource audioSource;
    public AudioClip correctAnswer;
    public AudioClip wrongAnswer;

    readonly List<KeyValuePair<int, string>> colors = new List<KeyValuePair<int, string>>() {
        new KeyValuePair<int, string>(1, "amarelo"),
        new KeyValuePair<int, string>(2, "azul"),
        new KeyValuePair<int, string>(3, "vermelho"),
        new KeyValuePair<int, string>(4, "verde"),
        new KeyValuePair<int, string>(5, "branco"),
        new KeyValuePair<int, string>(6, "rosa"),
    };
    readonly List<Color> textColors = new List<Color>() {
            new Color(1, 0.9f, 0, 1),
            new Color(0.14f, 0.14f, 1, 1),
            new Color(1, 0.1f, 0.1f, 1),
            new Color(0, 0.8f, 0, 1),
            new Color(1, 1, 1, 1),
            new Color(1, 0, 0.5f, 1)
    };
 
    int colorMeaningCode;
    int textColorMeaningCode;
    int textColorColorCode;
 
    bool isAnswered = false;
    Image clearSprite = null;
 
    void Awake() => clearSprite = textColorBox.gameObject.GetComponent<Image>();

    void Start() {
        clearSprite.sprite = defaultSprite;
        NewTextColors();
    }
 
    void NewTextColors() {
        isAnswered = false;
 
        Text colorMeaning = GameObject.Find("colorMeaningText").GetComponent<Text>();
        Text textColor = GameObject.Find("textColorText").GetComponent<Text>();
 
        colorMeaningCode = Random.Range(1, 7);
        textColorColorCode = Random.Range(1, 7);
        textColorMeaningCode = Random.Range(1, 7);
 
        foreach (var item in colors) {
            if (item.Key == colorMeaningCode) colorMeaning.text = item.Value;
            if (item.Key == textColorMeaningCode) textColor.text = item.Value;
            if (item.Key == textColorColorCode) textColor.color = textColors[item.Key - 1];
        }
    }
    public void Guessed(bool guessed) {
        bool isAnswerCorrect = colorMeaningCode == textColorColorCode;
        if (guessed == isAnswerCorrect) {
            textColorBox.gameObject.GetComponent<Image>().sprite = rightAnswerSprite;
            audioSource.PlayOneShot(correctAnswer); 
        } else {
            textColorBox.gameObject.GetComponent<Image>().sprite = wrongAnswerSprite;
            audioSource.PlayOneShot(wrongAnswer);
        }
            isAnswered = true;
    }
 
    void Update() {
        if (isAnswered) {
            NewTextColors();
            isAnswered = false;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            Guessed(true);
        } else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            Guessed(false);
        }
    }
}
