using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
	[SerializeField] public float	sensi;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float rotateHorizontal = Input.GetAxis ("Mouse X");
        float rotateVertical = Input.GetAxis ("Mouse Y");
        transform.RotateAround (this.transform.parent.transform.position, -Vector3.up, rotateHorizontal * sensi);
    }
}
