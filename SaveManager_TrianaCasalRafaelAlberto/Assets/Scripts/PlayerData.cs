[System.Serializable]
//Habilitará la serialización de datos de esta clase
public class PlayerData
//En este código se colocará todos los datos que se busquen guardar
{
    public float[] position = new float[3]; 
    //No se serilizan datos específicos de Unity asi que se definirá una raid de floats para almacenar coordenadas (En este caso 3)
    public PlayerData (Controller2 controller2) 
        //Aquí se toma de parámetro del jugador, en este caso llamado "controller2"
    {
        position[0] = controller2.transform.position.x;
        position[1] = controller2.transform.position.y;
        position[2] = controller2.transform.position.z;
        //Este apartado guardará la posición del jugador (Aquí dependerá el tipo de juego si es 2D o 3D, ya que se gaurdarán las coordenadas)
    }
}