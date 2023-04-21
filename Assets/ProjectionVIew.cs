using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectionVIew : MonoBehaviour
{
    public GameObject target; 

    Vector3 currentEulerAngles;
    public int type;
    float angle;
    Transform view;

    private void Awake()
    {
        
    }
    void Start()
    {
        view =target.transform;
    }

    void Update()
    {


        transform.position = new Vector3(transform.position.x, view.position.y,  transform.position.z);
        transform.localScale = new Vector3(view.position.z*type, view.position.z*type, view.position.z*type);
    }

    
}