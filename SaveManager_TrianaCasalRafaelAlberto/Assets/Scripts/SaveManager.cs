using UnityEngine;
using System.IO;
//Permitirá trabajar con archivos
using System.Runtime.Serialization.Formatters.Binary;
//Permitirá convertir los datos en binario para guardarlos en archivo

public static class SaveManager
//En este código se darán las acciones para que se puedan salvar los datos y poder cargarlos
{

    public static void SavePlayerData(Controller2 controller2)
        //El parámetro sigue siendo controller2 como en PlayerData (se gaurdarán los datos)
    {
        PlayerData playerData = new PlayerData(controller2);
        //Los datos que se guardarán serán los que se encuentran en playerData con el mimsmo parámetro
        string dataPath = Application.persistentDataPath + "/controller2.save";
        //Aquí se define la ruta donde estará el archivo de guardado, en este caso será la de "Application.persistentDataPath" la cual Unity provee siendo una ruta persistente que no cambiará y se podrá a adptar a cualqueir sistema operativo
        FileStream fileStream = new FileStream(dataPath, FileMode.Create);
        //Aquí se crea el archivo donde se guardarán los datos donde el "FileStream" nos permite analizar los archivos, con parámetro la ruta donde trabajamos y el "FileMode" donde se define que se hará en el archivo
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        //Aquí se hace la formalización binaria que transformará los datos en binario y poder guardarlos en el archivo
        binaryFormatter.Serialize(fileStream, playerData);
        //Aquí se especifica el Stream y datos que se convertirán en binario y guardar
        fileStream.Close();
        //Aquí se cierra el archivo
    }

    public static PlayerData LoadPlayerData()
        //Aquí son la carga de datos
    {
        string dataPath = Application.persistentDataPath + "/controller2.save";
        //Aquí se ocupará la misma ruta "persistenDataPath"

        if (File.Exists(dataPath)) 
            //Aquí se comprueba que este dicho archivo en la ruta mencionada
        {
            FileStream fileStream = new FileStream(dataPath, FileMode.Open);
            //Aquí se abren los datos en lugar de crearlos gracias al FileMode que es quien demanda que se harán con el archivo
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            PlayerData PlayerData = (PlayerData)binaryFormatter.Deserialize(fileStream);
            //Aqui se deserializan los datos del archivo a una varibale y el único parámetro será el Stream y estos datos se guardarán en PlayerData
            fileStream.Close();
            //Se cierra el archivo
            return PlayerData;
            //Aquí se devuleven los datos a quién haya llamado este método
        }
        else
        {
            Debug.LogError("No se encontró el archivo de guardado ");
            //Se mostrará el mensaje si no se cumple lo susodicho.
            return null;
            //Se regresará al inicio a buscar los datos que se quieren guardar.
        }
    }
}