using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

	[SerializeField] Rigidbody	rb;
	[SerializeField] float		speed;
	bool						grounded;
	bool						doubleJump;

    // Start is called before the first frame update
    void Start()
    {
		doubleJump = true;
		grounded = true;
    }

	void Update()
	{
		Transform camTransform = Camera.main.transform;
		Vector3 camPosition = new Vector3(camTransform.position.x, transform.position.y, camTransform.position.z);
		Vector3 direction = (transform.position - camPosition).normalized;
		Vector3 forwardMovement = direction * Input.GetAxis("Vertical");
		Vector3 horizontalMovement = camTransform.right * Input.GetAxis("Horizontal");
		Vector3 movement = Vector3.ClampMagnitude(forwardMovement + horizontalMovement, 1);
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (!grounded && !doubleJump)
				rb.AddForce(Vector3.up * -50f, ForceMode.Impulse);
			else if (!grounded)
			{
				rb.AddForce(Vector3.up * 10f, ForceMode.Impulse);
				doubleJump = false;
			}
			else
				rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
			grounded = false;
		}
		transform.Translate(movement * speed * Time.deltaTime, Space.World);
	}

	void	OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.name == "Ground")
		{
			grounded = true;
			doubleJump = true;
		}
	}
}
