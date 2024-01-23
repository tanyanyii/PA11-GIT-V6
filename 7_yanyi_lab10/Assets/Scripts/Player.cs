using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;
    public Text ScoreText;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float verticalInput = Input.GetAxis("Vertical");

        transform.position = transform.position + new Vector3(0 , verticalInput * speed * Time.deltaTime, 0);

        if (transform.position.y >= 3.89f)

        {
            transform.position = new Vector3(transform.position.x, 3.89f,transform.position.z);
        }

        else if (transform.position.y <= -3.87f)

        {
            transform.position = new Vector3(transform.position.x, -3.87f,transform.position.z);
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PassObstacle")
        {
            score++;
            ScoreText.GetComponent<Text>().text = " Score :" + score;
        }
    }
}
