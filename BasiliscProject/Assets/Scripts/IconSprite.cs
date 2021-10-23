using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconSprite : MonoBehaviour
{
    public SpriteRenderer mySprite;

    public Sprite upSprite;
    public Sprite downSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;



    public void SetUpSprite()
    {
        mySprite.sprite = upSprite;
    }

    public void SetDownSprite()
    {
        mySprite.sprite = downSprite;
    }

    public void SetLeftSprite()
    {
        mySprite.sprite = leftSprite;
    }

    public void SetRightSprite()
    {
        mySprite.sprite = rightSprite;
    }
}
