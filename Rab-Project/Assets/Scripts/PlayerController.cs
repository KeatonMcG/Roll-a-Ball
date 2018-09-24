using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;
    public AudioSource breakSource;

    private int count;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        count = 0;
        setCountText();
        winText.text = "";

        breakSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
     
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            breakSource.Play();
            count = count + 1;
            setCountText();
        }
    }
    void setCountText()
    {
        countText.text = " Count: " + count.ToString();
        if(count >= 11)
        {
            winText.text = "You Win!";
        }
    }
    public void BackButon()
    {
        SceneManager.LoadScene(0);
    }

}
