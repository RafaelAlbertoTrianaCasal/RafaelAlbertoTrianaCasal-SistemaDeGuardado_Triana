using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller2 : MonoBehaviour
{
    CharacterController characterController;

    //Toda variable utilizada para control del personaje
    [Header("Personaje")] //Esto solo es estética para el script
    public float walkspeed = 10.0f;
    //velocidad de caminar
    public float runspeed = 20.0f;
    //velocidad al correr
    public float jump = 8.0f;
    //impulso de salto
    public float gravity = 20.0f;
    //gravedad con la que se trabajará

    //Variables para la cámara
    [Header("Cámara")]
    public Camera cam; //Manda a llamar la cámara que usaremos
    //Velocidad de mov. Sensibilidad vaya
    public float mHorizontal = 3.0f;
    public float mVertical = 3.0f;
    //Límites de rotación
    public float minRotation = -65.0f;
    public float maxRotation = 60.0f;
    float h_mouse, v_mouse;

    private Vector3 move = Vector3.zero;
    //Es un Vector3 con los tres ejes en 3, por eso el .zero

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        //Esto busca el component de ChracterController
        Cursor.lockState = CursorLockMode.Locked;
        //Supuestamente para que no se vea el cursos en el juego
    }


    void Update()
    {
        h_mouse = mHorizontal * Input.GetAxis("Mouse X");
        v_mouse += mVertical * Input.GetAxis("Mouse Y");

        v_mouse = Mathf.Clamp(v_mouse, minRotation, maxRotation);
        //Aquí pondremos un límite para que no rote la cámara de manera infinita
        cam.transform.localEulerAngles = new Vector3(-v_mouse, 0, 0);
        //Esto es para poder rotar la cámara, dejando el vmouse como negativo para control coloquial 


        if (characterController.isGrounded)
        {
            move = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical")); //Mov. de derecha a ziquierda 

            if (Input.GetKey(KeyCode.LeftShift)) //Al cumplir con preisonar shift correra la condición de correr
                move = transform.TransformDirection(move) * runspeed;
            else
                move = transform.TransformDirection(move) * walkspeed;

            if (Input.GetKey(KeyCode.Space)) //Salto con tecla Space
                move.y = jump;
        }

        move.y -= gravity * Time.deltaTime;
        characterController.Move(move * Time.deltaTime);

        //Guardado y Carga de datos

        if (Input.GetKeyDown(KeyCode.G)) 
            //Condicional que para presionar la tecla "G" y ocurra el evento que se encunetra dentro de esta.
        {
            SaveManager.SavePlayerData(this);
            //Se salvarán los datos si la acción es realizada.
            Debug.Log("Datos Guardados");
            //Se escribirá esto en conosla una vez realizada la acción con éxito.
        }

        if (Input.GetKeyDown(KeyCode.C))
        //Condicional que para presionar la tecla "C" y ocurra el evento que se encunetra dentro de esta.
        {
            PlayerData playerData = SaveManager.LoadPlayerData(); 
            //Los datos se cargarán al relizar la acción
            transform.position = new Vector3(playerData.position[0], playerData.position[1], playerData.position[2]);
            //Los datos de guardado que serán cargados una vez se haga la acción 
            Debug.Log("Datos Cargados");
            //Se escribirá esto en conosla una vez realizada la acción con éxito.
        }
    }
    
}
