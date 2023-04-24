using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransformControl : MonoBehaviour
{

    public GameObject objectToTrans;
    public Slider Zslider;
    public float farlimit;
    public float nearlimit;
    public Slider Yslider;
    public float uplimit;
    public float bottomlimit;
    public Slider RotateSlider;
    public GameObject projectview;

    // Preserve the original and current orientation
    private float previousValue;

    void Awake()
    {
        // Assign a callback for when this slider changes
         this.RotateSlider.onValueChanged.AddListener(this.OnSliderChanged);
        // And current value
        this.previousValue = this.RotateSlider.value;

        //y position
        Yslider.minValue = bottomlimit;
        Yslider.maxValue = uplimit;
        Yslider.onValueChanged.AddListener(YsliderUpdate);


        Zslider.minValue = nearlimit;
        Zslider.maxValue = farlimit;
        Zslider.onValueChanged.AddListener(ZsliderUpdate);


    }

    void OnSliderChanged(float value)
    {
        // How much we've changed
        float delta = value - this.previousValue;
        this.objectToTrans.transform.Rotate(delta * 120* Vector3.up );

        // Set our previous value for the next change
        this.previousValue = value;
    }

    void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, transform.forward * 100);
        //Debug.DrawLine(transform.position, transform.position + transform.forward * 100, Color.white);

        RaycastHit hit;
        if(Physics.Raycast(ray,out hit ,10))
        {

            projectview.transform.position = hit.point;
            //projectview
            //print(hit.point);
            //print(hit.collider.gameObject);
        }


    }

    void ZsliderUpdate(float Zvalue)
    {
        transform.localPosition = new Vector3(transform.position.x, transform.position.y, Zvalue*-1);
        projectview.transform.localScale = new Vector3(Zvalue, Zvalue,1);

    }

    void YsliderUpdate(float Yvalue)
    {
        transform.localPosition = new Vector3(transform.position.x, Yvalue, transform.position.z);
        
    }

}
