using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player1 : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody _rigid;
    public float speedMovement = 0.1f;
    public GameObject bulletPrefab1;
    public GameObject bulletPrefab2;
    public GameObject bulletPrefab3;
    public GameObject gun1;
    public GameObject gun2;
    public GameObject gun3;
    public static int SCORE = 0;
    public static float xBorderLimit, yBorderLimit;
    private SoundManager soundManager;
    [SerializeField] float rotationSpeed = 120f;

    private void Awake(){
        Debug.Log("Player Awake");
        soundManager = FindObjectOfType<SoundManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody>();

        yBorderLimit = Camera.main.orthographicSize + 1;
        xBorderLimit = (Camera.main.orthographicSize + 1) * Screen.width / Screen.height;
    }

    private void FixedUpdate()
    {
        // obtenemos las pulsaciones de teclado
        float rotation = Input.GetAxis("Rotate") * rotationSpeed * Time.deltaTime;
        float forward  = Input.GetAxis("Forward") * speedMovement;
        // la dirección de empuje por defecto es .right (el eje X positivo)
        //thrustDirection = transform.right;

        // rotamos con el eje "Rotate" negativo para que la dirección sea correcta
        transform.Rotate(Vector3.forward, -rotation);

        // añadimos la fuerza capturada arriba a la nave del jugador
        _rigid.AddForce(forward * speedMovement * transform.right);
    }

    // Update is called once per frame
    void Update()
    {
        /*float rotation = Input.GetAxis("Rotate");
        float forward = Input.GetAxis("Forward");  

        transform.Rotate(Vector3.forward, -rotation);
        _rigid.AddForce(forward * speedMovement * transform.right); // asuming that is in only one direction.
        */
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet1 = Instantiate(bulletPrefab1, gun1.transform.position, Quaternion.identity);
            GameObject bullet2 = Instantiate(bulletPrefab2, gun2.transform.position, Quaternion.identity);
            GameObject bullet3 = Instantiate(bulletPrefab3, gun3.transform.position, Quaternion.identity);
            // we are looking for the script bullet
            Bullet bulleScript1 = bullet1.GetComponent<Bullet>();
            bulleScript1.targetVector = transform.right;
            Bullet bulleScript2 = bullet2.GetComponent<Bullet>();
            bulleScript2.targetVector = transform.right;
            Bullet bulleScript3 = bullet3.GetComponent<Bullet>();
            bulleScript3.targetVector = transform.right;

            soundManager.SeleccionAudio(0, 0.5f);
        } else if(Input.GetKey("escape")){
            SceneManager.LoadScene("MainScene");
        }
    }


    public void OnCollisionEnter(Collision collision){
        if (collision.gameObject.tag == "Enemy")
        {
            StartCoroutine(ChangeToScene());
            
            SCORE = 0; 
        }
    }

    public IEnumerator ChangeToScene()
    {
        soundManager.SeleccionAudio(2, 0.5f);
        yield return new WaitForSeconds(1);
        Application.LoadLevel(Application.loadedLevel);
        //yield return new WaitForSeconds(1);
        //Application.LoadLevel(sceneToChangeTo);
    }

    void LateUpdate () {
        // Limitar la posición del personaje a la cámara actual
        Vector3 v3 = transform.position;
        float distance = transform.position.z - Camera.main.transform.position.z;
        v3.x = Mathf.Clamp(v3.x, Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance)).x, Camera.main.ViewportToWorldPoint(new Vector3(1, 1, distance)).x);
        v3.y = Mathf.Clamp(v3.y, Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance)).y, Camera.main.ViewportToWorldPoint(new Vector3(1, 1, distance)).y);
        transform.position = v3;
    }
}
