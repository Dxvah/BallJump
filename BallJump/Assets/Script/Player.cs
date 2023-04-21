using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float jumpForce = 3f;
    [SerializeField] float ultraSpeed = 10.0f;
    Rigidbody ballRigidbody;
    [SerializeField] GameObject trail;
    [SerializeField] int nivel = 1;
    public GameObject gameOverPanel;
    public float initialPosition;
    public float endPosition;
    public GameObject retryMenu;

    void Awake()
    {
        ballRigidbody = GetComponent<Rigidbody>();
        trail.SetActive(false);
        initialPosition = transform.position.y;
        retryMenu.SetActive(false);

        //Debug.Log("Record actual =" + nivel.ToString());
    }

    void Update()
    {
        trail.SetActive(ballRigidbody.velocity.y < -ultraSpeed);

        float metrosRecorridos = initialPosition - transform.position.y;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (ballRigidbody.velocity.y < -ultraSpeed)
        {
            Destroy(collision.gameObject);
        }
        else
        {
            ballRigidbody.velocity = Vector3.zero;
            ballRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (collision.gameObject.tag == "Destructor")
        {
            gameObject.SetActive(false);
            retryMenu.SetActive(true);
        }
        if (collision.gameObject.tag == "Meta")
        {
            endPosition = transform.position.y;
            ballRigidbody.constraints = RigidbodyConstraints.FreezeAll;
            GuardarDatos(true);
            retryMenu.SetActive(true);
        }
    }

    void GuardarDatos(bool hasWon)
    {
        float metrosRecorridos = initialPosition - transform.position.y;
        string keyLevel = "MetrosNivel" + nivel.ToString();
        if (PlayerPrefs.GetFloat(keyLevel, 0.0f) < metrosRecorridos)
        {
            PlayerPrefs.SetFloat(keyLevel, metrosRecorridos);
        }
        if (hasWon == true)
        {
            PlayerPrefs.SetInt("Nivel Superado" + nivel.ToString(), 1);
        }
    }
    
    public void PlayerDied()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }
    
    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void ReturnToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}


