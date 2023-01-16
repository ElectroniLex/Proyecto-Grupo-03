using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "Personaje", menuName ="Sistema de Dialogo/Nuevo Personjae")]
public class Personaje : ScriptableObject
{
    public string nombre;
    public Sprite imagen;
}