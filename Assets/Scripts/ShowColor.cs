using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowColor : MonoBehaviour {

    /*public GameObject colorMeaningTextObject;
    public GameObject textColorTextObject;
    public GameObject textColorBox;
    public Sprite rightAnswerSprite;
    public Sprite wrongAnswerSprite;
    public Sprite defaultSprite;

    // Start is called before the first frame update
    void Start() {
        isAnswered = true;
        textColorBox.gameObject.GetComponent<Image>().sprite = defaultSprite;
    }

    readonly int yellow = 1;
    readonly int blue = 2;
    readonly int red = 3;
    readonly int green = 4;
    readonly int gray = 5;
    readonly int white = 6;
    readonly int pink = 7;

    int colorMeaningCode;
    int textColorMeaningCode;
    int textColorColorCode;

    bool isAnswered = false;

    private void NewRandomNumbers() {
        colorMeaningCode = Random.Range(1, 8);
        textColorColorCode = Random.Range(1, 8);
        textColorMeaningCode = Random.Range(1, 8);
    }

    public void NewTextColors() {


        colorMeaningCode = 0;
        textColorMeaningCode = 0;
        textColorColorCode = 0;

        Text colorMeaning = GameObject.Find("colorMeaningText").GetComponent<Text>();
        Text textColor = GameObject.Find("textColorText").GetComponent<Text>();

        isAnswered = false;

        NewRandomNumbers();

        SortNewColorMeaning(colorMeaning);
        SortNewTextColorMeaning(textColor);
        SortNewTextColor(textColor);

    }

    private void SortNewColorMeaning(Text colorMeaning) {
        if (colorMeaningCode == yellow) {
            colorMeaning.text = "amarelo";
        } else if (colorMeaningCode == blue) {
            colorMeaning.text = "azul";
        } else if (colorMeaningCode == red) {
            colorMeaning.text = "vermelho";
        } else if (colorMeaningCode == green) {
            colorMeaning.text = "verde";
        } else if (colorMeaningCode == gray) {
            colorMeaning.text = "cinza";
        } else if (colorMeaningCode == white) {
            colorMeaning.text = "branco";
        } else if (colorMeaningCode == pink) {
            colorMeaning.text = "rosa";
        }
    }

    private void SortNewTextColorMeaning(Text textColor) {
        if (textColorMeaningCode == yellow) {
            textColor.text = "amarelo";
        } else if (textColorMeaningCode == blue) {
            textColor.text = "azul";
        } else if (textColorMeaningCode == red) {
            textColor.text = "vermelho";
        } else if (textColorMeaningCode == green) {
            textColor.text = "verde";
        } else if (textColorMeaningCode == gray) {
            textColor.text = "cinza";
        } else if (textColorMeaningCode == white) {
            textColor.text = "branco";
        } else if (textColorMeaningCode == pink) {
            textColor.text = "rosa";
        }
    }

    private void SortNewTextColor(Text textColor) {
        if (textColorColorCode == yellow) {
            textColor.color = new Color(1, 0.9f, 0, 1);
        } else if (textColorColorCode == blue) {
            textColor.color = new Color(0.14f, 0.14f, 1, 1);
        } else if (textColorColorCode == red) {
            textColor.color = new Color(1, 0.1f, 0.1f, 1);
        } else if (textColorColorCode == green) {
            textColor.color = new Color(0, 0.8f, 0, 1);
        } else if (textColorColorCode == gray) {
            textColor.color = new Color(0.5f, 0.5f, 0.5f, 1);
        } else if (textColorColorCode == white) {
            textColor.color = new Color(1, 1, 1, 1);
        } else if (textColorColorCode == pink) {
            textColor.color = new Color(1, 0, 0.5f, 1);
        }
    }

    public void Guessed(bool guessed) {
        if ((guessed == true && (colorMeaningCode == textColorColorCode)) || (guessed == false && (colorMeaningCode != textColorColorCode))) {
            textColorBox.gameObject.GetComponent<Image>().sprite = rightAnswerSprite;
        } else {
            textColorBox.gameObject.GetComponent<Image>().sprite = wrongAnswerSprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isAnswered) {
            NewTextColors();
        }
    }*/

        public GameObject colorMeaningTextObject;
        public GameObject textColorTextObject;
        public GameObject textColorBox;
        public Sprite rightAnswerSprite;
        public Sprite wrongAnswerSprite;
        public Sprite defaultSprite;
 
        readonly List<KeyValuePair<int, string>> colors = new List<KeyValuePair<int, string>>()
        {
            new KeyValuePair<int, string>(1, "amarelo"),
            new KeyValuePair<int, string>(2, "azul"),
            new KeyValuePair<int, string>(3, "vermelho"),
            new KeyValuePair<int, string>(4, "verde"),
            new KeyValuePair<int, string>(5, "cinza"),
            new KeyValuePair<int, string>(6, "branco"),
            new KeyValuePair<int, string>(7, "rosa"),
        };
        readonly List<Color> textColors = new List<Color>()
        {
            new Color(1, 0.9f, 0, 1),
            new Color(0.14f, 0.14f, 1, 1),
            new Color(1, 0.1f, 0.1f, 1),
            new Color(0, 0.8f, 0, 1),
            new Color(0.5f, 0.5f, 0.5f, 1),
            new Color(1, 1, 1, 1),
            new Color(1, 0, 0.5f, 1)
        };
 
        int colorMeaningCode;
        int textColorMeaningCode;
        int textColorColorCode;
 
        bool isAnswered = false;
        Image clrBoxImg = null;
 
        void Awake() => clrBoxImg = textColorBox.gameObject.GetComponent<Image>();

        void Start()
        {
            clrBoxImg.sprite = defaultSprite;
            NewTextColors();
        }
 
        void NewTextColors()
        {
            isAnswered = false;
 
            Text colorMeaning = GameObject.Find("colorMeaningText").GetComponent<Text>();
            Text textColor = GameObject.Find("textColorText").GetComponent<Text>();
 
            colorMeaningCode = Random.Range(1, 8);
            textColorColorCode = Random.Range(1, 8);
            textColorMeaningCode = Random.Range(1, 8);
 
            foreach (var item in colors)
            {
                if (item.Key == colorMeaningCode) colorMeaning.text = item.Value;
                if (item.Key == textColorMeaningCode) textColor.text = item.Value;
                if (item.Key == textColorColorCode) textColor.color = textColors[item.Key];
            }
        }
        public void Guessed(bool guessed)
        {
            bool isColorSame = colorMeaningCode == textColorColorCode;
            textColorBox.gameObject.GetComponent<Image>().sprite = (guessed == isColorSame) ? rightAnswerSprite : wrongAnswerSprite;
            isAnswered = true;
        }
 
        void Update()
        {
            if (isAnswered)
            {
                NewTextColors();
                isAnswered = false;
            }
        }
}
