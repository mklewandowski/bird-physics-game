using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    Vector3 initialPosition;
    float power = 300f;
    string currentScene = "";
    bool launched = false;
    float gameTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = this.transform.localPosition;
        GetComponent<LineRenderer>().enabled = false;
        currentScene = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.localPosition.x < -30f || this.transform.localPosition.x > 30f ||
            this.transform.localPosition.y < -20f || this.transform.localPosition.y > 40f)
        {
            SceneManager.LoadScene(currentScene);
        }
        if (launched && GetComponent<Rigidbody2D>().velocity.magnitude < 0.5f)
        {
            gameTimer += Time.deltaTime;
            if (gameTimer > 3f)
                SceneManager.LoadScene(currentScene);
        }
    }

    void OnMouseDown()
    {
        if (launched) return;
        GetComponent<SpriteRenderer>().color = Color.red;
        GetComponent<LineRenderer>().enabled = true;
    }

    void OnMouseUp()
    {
        if (launched) return;
        GetComponent<SpriteRenderer>().color = Color.white;
        GetComponent<Rigidbody2D>().gravityScale = 1;
        GetComponent<Rigidbody2D>().AddForce(power * (initialPosition - this.transform.localPosition));
        GetComponent<LineRenderer>().enabled = false;
        launched = true;
    }

    void OnMouseDrag()
    {
        if (launched) return;
        Vector3 screenToWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 newPosition = new Vector3(screenToWorldPosition.x, screenToWorldPosition.y, this.transform.localPosition.z);
        this.transform.localPosition = newPosition;
        GetComponent<LineRenderer>().SetPosition(0, newPosition);
        GetComponent<LineRenderer>().SetPosition(1, initialPosition);

    }
}
