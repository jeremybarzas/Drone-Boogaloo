using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UserInfo", menuName = "ScriptableObjects/DBUserInfo")]
public class OfflineUserScriptableObject : ScriptableObject
{
	[SerializeField]
	public UserInformation userInfo;


	public void ClearUser()
	{
		userInfo = new UserInformation("", -1);
	}


    public sealed class UserInformation
    {
		public string sessionId;
		public int userID;

        public UserInformation(string sid, int uid)
        {
			sessionId = sid;
			userID = uid;
        }
    }
}