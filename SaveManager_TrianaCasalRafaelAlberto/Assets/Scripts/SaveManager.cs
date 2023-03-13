using UnityEngine;
using System.IO;
//Permitir� trabajar con archivos
using System.Runtime.Serialization.Formatters.Binary;
//Permitir� convertir los datos en binario para guardarlos en archivo

public static class SaveManager
//En este c�digo se dar�n las acciones para que se puedan salvar los datos y poder cargarlos
{

    public static void SavePlayerData(Controller2 controller2)
        //El par�metro sigue siendo controller2 como en PlayerData (se gaurdar�n los datos)
    {
        PlayerData playerData = new PlayerData(controller2);
        //Los datos que se guardar�n ser�n los que se encuentran en playerData con el mimsmo par�metro
        string dataPath = Application.persistentDataPath + "/controller2.save";
        //Aqu� se define la ruta donde estar� el archivo de guardado, en este caso ser� la de "Application.persistentDataPath" la cual Unity provee siendo una ruta persistente que no cambiar� y se podr� a adptar a cualqueir sistema operativo
        FileStream fileStream = new FileStream(dataPath, FileMode.Create);
        //Aqu� se crea el archivo donde se guardar�n los datos donde el "FileStream" nos permite analizar los archivos, con par�metro la ruta donde trabajamos y el "FileMode" donde se define que se har� en el archivo
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        //Aqu� se hace la formalizaci�n binaria que transformar� los datos en binario y poder guardarlos en el archivo
        binaryFormatter.Serialize(fileStream, playerData);
        //Aqu� se especifica el Stream y datos que se convertir�n en binario y guardar
        fileStream.Close();
        //Aqu� se cierra el archivo
    }

    public static PlayerData LoadPlayerData()
        //Aqu� son la carga de datos
    {
        string dataPath = Application.persistentDataPath + "/controller2.save";
        //Aqu� se ocupar� la misma ruta "persistenDataPath"

        if (File.Exists(dataPath)) 
            //Aqu� se comprueba que este dicho archivo en la ruta mencionada
        {
            FileStream fileStream = new FileStream(dataPath, FileMode.Open);
            //Aqu� se abren los datos en lugar de crearlos gracias al FileMode que es quien demanda que se har�n con el archivo
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            PlayerData PlayerData = (PlayerData)binaryFormatter.Deserialize(fileStream);
            //Aqui se deserializan los datos del archivo a una varibale y el �nico par�metro ser� el Stream y estos datos se guardar�n en PlayerData
            fileStream.Close();
            //Se cierra el archivo
            return PlayerData;
            //Aqu� se devuleven los datos a qui�n haya llamado este m�todo
        }
        else
        {
            Debug.LogError("No se encontr� el archivo de guardado ");
            //Se mostrar� el mensaje si no se cumple lo susodicho.
            return null;
            //Se regresar� al inicio a buscar los datos que se quieren guardar.
        }
    }
}