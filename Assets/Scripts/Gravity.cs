using UnityEngine;
using System.Collections.Generic;

public class Gravity : MonoBehaviour {
	//Радиус действия гравитации
	public float gravityRadius = 3f;
	//На кого действует
	public LayerMask affectedLayer;

	void FixedUpdate () {
		Collider2D[] coliders  = Physics2D.OverlapCircleAll(transform.position, gravityRadius); 

		foreach(Collider2D colider in coliders){
			Rigidbody2D rb = colider.GetComponent<Rigidbody2D>();

			if(rb != null && rb != GetComponent<Rigidbody2D>() && isInLayerMask(affectedLayer, rb.gameObject)){

				Debug.DrawLine(rb.position, rb.position + rb.velocity, Color.green);

				//Вектор от колайдера к центру объекта
				Vector2 offset = transform.position - colider.transform.position;

				//Гравитационная сила
				Vector2 fg = offset.normalized * rb.mass * GetComponent<Rigidbody2D>().mass / offset.sqrMagnitude;
				rb.AddForce(fg);
				Debug.DrawLine(rb.position, rb.position + fg, Color.red);

				//Сила инерции
				Vector2 fi = -offset.normalized * rb.mass * rb.velocity.sqrMagnitude / offset.sqrMagnitude;
				rb.AddForce(fi);
				Debug.DrawLine(rb.position, rb.position + fi);
			}
		}
	}

	bool isInLayerMask(LayerMask mask, GameObject gameObject){
		return (mask.value & 1 << gameObject.layer) == 1 << gameObject.layer;
	}
}
