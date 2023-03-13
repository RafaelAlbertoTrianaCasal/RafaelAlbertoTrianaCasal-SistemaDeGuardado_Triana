[System.Serializable]
//Habilitar� la serializaci�n de datos de esta clase
public class PlayerData
//En este c�digo se colocar� todos los datos que se busquen guardar
{
    public float[] position = new float[3]; 
    //No se serilizan datos espec�ficos de Unity asi que se definir� una raid de floats para almacenar coordenadas (En este caso 3)
    public PlayerData (Controller2 controller2) 
        //Aqu� se toma de par�metro del jugador, en este caso llamado "controller2"
    {
        position[0] = controller2.transform.position.x;
        position[1] = controller2.transform.position.y;
        position[2] = controller2.transform.position.z;
        //Este apartado guardar� la posici�n del jugador (Aqu� depender� el tipo de juego si es 2D o 3D, ya que se gaurdar�n las coordenadas)
    }
}