[System.Serializable]

public class GameData
{
    public int vida;
    public float[] position = new float[3];

    public GameData(Player player)
    {
        vida = player.vida;

        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

    }

}
