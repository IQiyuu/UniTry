using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{

	int	timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer++ == 100)
		{
			transform.Rotate(new Vector3(transform.rotation.x + 0.1f, 0, 0));
			timer = 0;
		}
    }
}
