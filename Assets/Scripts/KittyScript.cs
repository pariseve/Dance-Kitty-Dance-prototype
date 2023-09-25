using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KittyScript : MonoBehaviour
{
    private SpriteRenderer theSR;
    public Sprite defaultKitty;
    public Sprite rightKitty;
    public Sprite leftKitty;
    public Sprite upKitty;
    public Sprite downKitty;

    // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            theSR.sprite = rightKitty;
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            theSR.sprite = leftKitty;
        }

        else if (Input.GetKey(KeyCode.UpArrow))
        {
            theSR.sprite = upKitty;
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            theSR.sprite = downKitty;
        }
        else
        {
            theSR.sprite = defaultKitty;
        }
      
    }
}
