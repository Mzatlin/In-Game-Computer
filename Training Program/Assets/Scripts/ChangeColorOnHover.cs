using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColorOnHover : MonoBehaviour
{
    IClickable click;
    Button button;
    Image buttonImage;
    Color originalColor;
    // Start is called before the first frame update
    void Start()
    {
        
        button = GetComponent<Button>();
        buttonImage = button.GetComponent<Image>();
        originalColor = buttonImage.color;
        click = GetComponent<IClickable>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(click != null && click.IsHovering)
        {
            buttonImage.color = Color.red;
        }
        else
        {
            buttonImage.color = originalColor;
        }
    }
}
