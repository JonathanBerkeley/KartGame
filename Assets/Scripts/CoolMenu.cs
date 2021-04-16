using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolMenu : MonoBehaviour
{
    //This only takes the alpha from the colour
    [Header("Script only uses Alpha, ignores RGB data.")]
    public Color initialColor;

    //Change this before running game - runtime changes do nothing
    [Header("Lower is faster")]
    public int changeRate;

    //This is just 1 / 255, representing 1 unit on a 255 scale.
    private const float oneUnit = 0.00392156862f;
    private float tinyUnit;
    private Image image;
    private bool rFlip, gFlip, bFlip;

    private void Awake()
    {
        image = gameObject.GetComponent<Image>();
    }

    private void Start()
    {
        tinyUnit = oneUnit / changeRate;
        image.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), initialColor.a);
        rFlip = gFlip = bFlip = false;
    }

    private void Update()
    {
        ColourChange();
    }

    private void ColourChange()
    {
        //Debug.Log($"R: {(int)(image.color.r * 255)} G: {(int)(image.color.g * 255)} B: {(int)(image.color.b * 255)}");

        if (image.color.r < tinyUnit * 10)
            rFlip = false;
        else if (image.color.r > 1.0f)
            rFlip = true;

        if (image.color.g < tinyUnit * 10)
            gFlip = false;
        else if (image.color.g > 1.0f)
            gFlip = true;

        if (image.color.b < tinyUnit * 10)
            bFlip = false;
        else if (image.color.b > 1.0f)
            bFlip = true;

        int _path = Random.Range(1, 4);
        switch (_path)
        {
            //Red
            case 1:
                if (rFlip)
                    image.color = new Color(image.color.r - tinyUnit, image.color.g, image.color.b, image.color.a);
                else
                    image.color = new Color(image.color.r + tinyUnit, image.color.g, image.color.b, image.color.a);
                break;
            //Green
            case 2:
                if (gFlip)
                    image.color = new Color(image.color.r, image.color.g - tinyUnit, image.color.b, image.color.a);
                else
                    image.color = new Color(image.color.r, image.color.g + tinyUnit, image.color.b, image.color.a);
                break;
            //Blue
            case 3:
                if (bFlip)
                    image.color = new Color(image.color.r, image.color.g, image.color.b - tinyUnit, image.color.a);
                else
                    image.color = new Color(image.color.r, image.color.g, image.color.b + tinyUnit, image.color.a);
                break;
            default:
                break;
        }
    }
}
