using UnityEngine.SceneManagement;
using UnityEngine;

public class Reset : MonoBehaviour {

	[SerializeField] private Collider2D m_Button;

	private Camera Camera { get; set; }

	void Start() {
		this.Camera = Camera.main;
	}

	void Update() {
		if (Input.GetMouseButtonUp(0)) {
			Vector3 mousePosition = this.Camera.ScreenToWorldPoint(Input.mousePosition);
			mousePosition.z = m_Button.transform.position.z;
			if (m_Button.bounds.Contains(mousePosition)) {
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
				return;
			}
		}
	}
}
