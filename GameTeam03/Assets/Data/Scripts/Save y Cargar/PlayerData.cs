[System.Serializable]

public class PlayerData
{
    public int vida;
    public int score;
    public float[] position = new float[3];

    public PlayerData(Player player)
    {
        vida = player.vida;
        score = player.score;
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

    }

}
