using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonajeControlador : MonoBehaviour 
{
	public int maxPuntos;
	public float Velocidad;
	public float fuerzaSalto;
	public Text textoPuntos;
	public GameObject panelGanador;

	private Rigidbody rb;
	private int Puntos;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		Puntos = 0;
		SetCountText ();
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		float moveUp = Input.GetAxis("Jump");

		Vector3 movimiento = new Vector3 (moveHorizontal, moveUp, moveVertical);

		rb.AddForce (movimiento * Velocidad);
		rb.AddForce (movimiento * fuerzaSalto);
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ( "Puntos"))
		{
			other.gameObject.SetActive (false);
			Puntos = Puntos + 1;
			SetCountText ();
		}
	}

	void SetCountText ()
	{
		textoPuntos.text = Puntos.ToString() + " / " + maxPuntos.ToString();
		if (Puntos >= maxPuntos)
		{
			panelGanador.SetActive(true);
		}
	}
}
