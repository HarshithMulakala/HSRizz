using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiScript : MonoBehaviour
{

    public Image Q;
    public Image E;
    public Image R;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var Qimage = Q.GetComponent<Image>();
        var Eimage = E.GetComponent<Image>();
        var Rimage = R.GetComponent<Image>();
        if(Input.GetKeyDown(KeyCode.Q)){
            var tempColor = Qimage.color;
            tempColor.a = 1f;
            Qimage.color = tempColor;

            tempColor = Eimage.color;
            tempColor.a = 0f;
            Eimage.color = tempColor;

            tempColor = Rimage.color;
            tempColor.a = 0f;
            Rimage.color = tempColor;
        }
        if(Input.GetKeyDown(KeyCode.E)){
            var tempColor = Qimage.color;
            tempColor.a = 0f;
            Qimage.color = tempColor;

            tempColor = Eimage.color;
            tempColor.a = 1f;
            Eimage.color = tempColor;

            tempColor = Rimage.color;
            tempColor.a = 0f;
            Rimage.color = tempColor;
        }
        if(Input.GetKeyDown(KeyCode.R)){
            var tempColor = Qimage.color;
            tempColor.a = 0f;
            Qimage.color = tempColor;

            tempColor = Eimage.color;
            tempColor.a = 0f;
            Eimage.color = tempColor;

            tempColor = Rimage.color;
            tempColor.a = 1f;
            Rimage.color = tempColor;
        }
    }
}
