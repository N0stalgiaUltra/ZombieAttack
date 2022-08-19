//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using Facebook.Unity;
//using PlayFab;
//using PlayFab.ClientModels;
//using LoginResult = PlayFab.ClientModels.LoginResult;
//using UnityEngine.SceneManagement;
//using Photon.Pun;

///// <summary>
///// Script usado para autenticar o login do facebook com o Playfab
///// </summary>
//public class PlayfabAuthentication : MonoBehaviourPunCallbacks
//{
//    // Start is called before the first frame update
//    public string nameFB;
//    public string titleID;
//    public string fbAccessToken;
//    public Button loginButton;
//    public bool isReady;
//    void Awake()
//    {
//        if (FB.IsInitialized)
//            return;
//        SetMessage("Inicializando o Facebook");
//        FB.Init(()=> FB.ActivateApp());
//    }

//    private void Start()
//    {
//        loginButton.onClick.AddListener(() => LoginWithFacebook());
//        isReady = false;
//    }
//    public void LoginWithFacebook()
//    {
//        FB.LogInWithReadPermissions(new List<string> {"public_profile","email"}, this.LoginWithPlayfab );
//        if (FB.IsLoggedIn)
//            FB.LogOut();

//        //FB.LogInWithReadPermissions(null, LoginWithPlayfab);
//    }
//    public void LoginWithPlayfab(ILoginResult result)
//    {
//        if (result == null || string.IsNullOrEmpty(result.Error))
//        {
//            SetMessage("Facebook Auth Complete! Access Token: " + AccessToken.CurrentAccessToken.TokenString + "\nLogging into PlayFab...");

//            PlayFabClientAPI.LoginWithFacebook(new LoginWithFacebookRequest { CreateAccount = true, AccessToken = AccessToken.CurrentAccessToken.TokenString },
//                LoginSucess, LoginFailed);

//        }
//        //PlayFabClientAPI.LoginWithFacebook(new PlayFab.ClientModels.LoginWithFacebookRequest
//        //{
//        //    TitleId = titleID,
//        //    AccessToken = AccessToken.CurrentAccessToken.TokenString,
//        //    CreateAccount = true
//        //},  LoginSucess, LoginFailed);
//    }

//    private void LoginSucess(LoginResult result)
//    {
//        SetMessage("login sucessful");
//        FB.API("me?fields=name", HttpMethod.GET, SetName);

//    }
//    private void LoginFailed(PlayFabError error)
//    {
//        SetMessage($"Error in Login: {error}");
//    }

//    private void SetMessage(string message)
//    {
//        Debug.Log(message);
//    }

//    private void SetName(IResult result)
//    {
//        nameFB = result.ResultDictionary["name"].ToString();
//        PlayerPrefs.SetString("UserName", nameFB);
//        PlayerPrefs.Save();
//        SceneManager.LoadScene("LoadLobby");
//    }


//}
