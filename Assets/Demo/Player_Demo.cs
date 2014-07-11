using UnityEngine;

public class Player_Demo : MonoBehaviour
{

	Animator animator;

	void Start ()
	{
		animator = GetComponent<Animator> ();
	}

	void Update ()
	{
		animator.SetBool ("Vaut", Input.GetKeyDown (KeyCode.UpArrow));
		animator.SetBool ("Slide", Input.GetKeyDown (KeyCode.DownArrow));
	}

	void OnTriggerEnter (Collider other)
	{
		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.Vaut") && other.name == "Block") {
			return;
		}

		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.Slide") && other.name == "Hardle") {
			return;
		}

		animator.SetTrigger ("Dead");
	}
}