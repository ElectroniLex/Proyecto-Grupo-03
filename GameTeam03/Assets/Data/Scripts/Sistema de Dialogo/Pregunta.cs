using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityExtensions;

[System.Serializable]


public struct Opciones
{
    [TextArea(2, 4)]
    public string opciones;
    public Conversacion convResultantes;

}

[CreateAssetMenu(fileName = "Personaje", menuName = "Sistema de Dialogo/Nuevo Personjae")]
public class Pregunta : ScriptableObject
{
    [TextArea(3,5)]
    public string pregunta;
    [ReorderableList]
    public Opciones[] opciones;
}
