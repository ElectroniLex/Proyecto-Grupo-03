using System;
using System.Collections;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{
    public void CreateUser(string userName, string email, string pass,  Action<Response> response)
    {
        StartCoroutine(CO_Createuser(userName, email, pass, response));
    }

    private IEnumerator CO_Createuser(string userName, string email, string pass, Action<Response> response)
    {
        WWWForm form = new WWWForm();
        form.AddField("userName", userName);
        form.AddField("email", email);
        form.AddField("pass", pass);

        WWW w = new WWW("http://localhost/thekingway/createUser.php", form);

        yield return w;

        response( JsonUtility.FromJson<Response>(w.text) );
        

    }
}


[Serializable]

public class Response
{
    public bool done = false;
    public string message = "";
}
