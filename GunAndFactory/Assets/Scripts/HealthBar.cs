using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField] private float maxHP = 100;
    [SerializeField] Slider slider;
   
    public Color color = Color.red;
    public int width = 4;

    private bool _isRight;
    private static float current;

    private void Awake()
    {
        _isRight = true;
    }

    void Start()
    {
        slider.fillRect.GetComponent<Image>().color = color;

        slider.maxValue = maxHP;
        slider.minValue = 0;
        current = maxHP;

        UpdateUI();
    }

    public static float currentHP
    {
        get { return current; }
    }

    // Update is called once per frame
    void Update()
    {
        if (current < 0) current = 0;
        if (current > maxHP) current = maxHP;
        slider.value = current;
    }


    void UpdateUI()
    {
        RectTransform rect = slider.GetComponent<RectTransform>();

        int rectDeltaX = Screen.width / width;
        float rectPosX = 0;

        if (_isRight)
        {
            rectPosX = rect.position.x - (rectDeltaX - rect.sizeDelta.x) / 2;
            slider.direction = Slider.Direction.RightToLeft;
        }
        else
        {
            rectPosX = rect.position.x + (rectDeltaX - rect.sizeDelta.x) / 2;
            slider.direction = Slider.Direction.LeftToRight;
        }

        rect.sizeDelta = new Vector2(rectDeltaX, rect.sizeDelta.y);
        rect.position = new Vector3(rectPosX, rect.position.y, rect.position.z);
    }

    public static void AdjustCurrentHP(float adjust)
    {
        current += adjust;
    }

}
