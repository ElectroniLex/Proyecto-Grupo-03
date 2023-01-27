[System.Serializable]

public class GameData
{

    
    public int vida;
    public float[] position = new float[3];

    public GameData(PlayerYazmin playerYazmin)
    {
        vida = playerYazmin.vidaPlayer;

        position[0] = playerYazmin.transform.position.x;
        position[1] = playerYazmin.transform.position.y;
        position[2] = playerYazmin.transform.position.z;

    }

}
