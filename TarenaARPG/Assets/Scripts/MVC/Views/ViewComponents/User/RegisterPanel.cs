using cn.SMSSDK.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TarenaMVC.Core;
using UnityEngine;
using UnityEngine.UI;

namespace TRPG.MVC.Views
{
    /// <summary>
    ///  注册面板
    /// </summary>
    public class RegisterPanel : BasePanel,SMSSDKHandler
    {
        private InputField userInput;
        private InputField pwdInput;
        private InputField pwdInput2;
        private Button loginButton;
        private Button registerButton;
        private Button sendCode;
        
        private Text timer;
        private string phone;
        private string code;
        private InputField codeInput;
        private GameObject codePanel;
        private SMSSDK ssdk;
        private bool isSend;
        private int time;
        private float t;

        protected override void Awake()
        {
            base.Awake();
            ssdk = GetComponent<SMSSDK>();
            ssdk.init("292449f735890", "f1bee8045aac2e6cbb7c535a5277aa1c", true);
            ssdk.setHandler(this);
            codePanel = transform.Find("CodePanel").gameObject;
            codePanel.SetActive(false);
            userInput = Find<InputField>( "userInput" );
            pwdInput = Find<InputField>( "pwdInput" );
            pwdInput2 = Find<InputField>( "pwdInput2" );
            loginButton = Find<Button>( "loginButton" );
            registerButton = Find<Button>( "registerButton" );

            sendCode = codePanel.transform.Find("send").GetComponent<Button>();
            timer = codePanel.transform.Find("Timer").GetComponentInChildren<Text>();
            codeInput = codePanel.transform.Find("codeInput").GetComponent<InputField>();
            timer.gameObject.transform.parent.gameObject.SetActive(false);

            loginButton.onClick.AddListener( ShowLogin );
            registerButton.onClick.AddListener( Register );
            closeButton.onClick.AddListener( ShowLogin );
            sendCode.onClick.AddListener(SendCode);
            
        }

        private void Update()
        {
            if (isSend)
            {
                timer.text = time.ToString();
                t += Time.deltaTime;
                if (t >= 1)
                {
                    time--;
                    t = 0;
                }
                if (time < 0)
                {
                    isSend = false;
                    sendCode.gameObject.SetActive(true);

                    timer.gameObject.transform.parent.gameObject.SetActive(false);
                }
            }
            if (userInput.text == "") return;
            if (GetUserIsPhone(userInput.text) && !codePanel.activeSelf)
            {
                codePanel.SetActive(true);
            }
            else if (!GetUserIsPhone(userInput.text) && codePanel.activeSelf)
                codePanel.SetActive(false);
        }

        /// <summary>
        /// 发送验证码
        /// </summary>
        private void SendCode()
        {
            code = UnityEngine.Random.Range(111111, 1000000).ToString();
            phone = userInput.text;
            isSend = true;
            time = 60;
            sendCode.gameObject.SetActive(false);
            timer.gameObject.transform.parent.gameObject.SetActive(true);
            
            ssdk.getCode(CodeType.TextCode, phone, "86", null);
        }

        private bool GetUserIsPhone(string username)
        {
            return Regex.IsMatch(username, @"^[1]+[3,5]+\d{9}");
        }

        /// <summary>
        /// 注册
        /// </summary>
        private void Register()
        {
            if (codePanel.activeSelf)
            {
                ssdk.commitCode(phone, "86", codeInput.text);
                return;
            }
            RegisterByCode();
        }

        private void RegisterByCode()
        {
            // 用户名和密码均不为空
            if (userInput.text == ""
                || pwdInput.text == ""
                || pwdInput2.text == "")
            {
                Debug.LogError("用户名和密码均不能为空!");
                Alert.Show("出错了", "用户名和密码均不能为空!");
                return;
            }
            // 密码和确认密码一致
            if (pwdInput.text != pwdInput2.text)
            {
                Debug.LogError("密码不一致!");
                Alert.Show("出错了", "密码不一致!");
                return;
            }
            // 非法字符验证
            if (!StringHelper.IsSafeSqlString(userInput.text)
                || StringHelper.CheckBadWord(userInput.text)
                || !StringHelper.IsSafeSqlString(pwdInput.text)
                || StringHelper.CheckBadWord(pwdInput.text)
               || !StringHelper.IsSafeSqlString(pwdInput2.text)
                || StringHelper.CheckBadWord(pwdInput2.text))
            {
                Debug.LogError("不允许非法字符!");
                Alert.Show("出错了", "不允许非法字符!");
                return;
            }
            // UserVO
            UserVO user = new UserVO(userInput.text, pwdInput.text);
            user.uid = Guid.NewGuid().ToString("N");
            // 发送注册的消息
            SendNotification(NotificationList.REGISTER, user);
        }

        /// <summary>
        /// 显示登录面板
        /// </summary>
        private void ShowLogin()
        {
            // 显示登录面板
            SendNotification( SHOW + NotificationList.LOGIN );
        }

        public void onComplete(int action, object resp)
        {
            Debug.Log(" get code is " + (ActionType)action);
            ActionType act = (ActionType)action;
            if (resp != null)
            {
                //result = resp.ToString();
                //text.text += "\n" + resp.ToString();
                Debug.Log(resp.ToString());
            }
            if (act == ActionType.GetCode)
            {
                string responseString = (string)resp;

                //RegisterByCode();
                Debug.Log("isSmart :" + responseString);
            }
            else if (act == ActionType.GetVersion)
            {
                string version = (string)resp;
                Debug.Log("version :" + version);
                print("Demo*version*********" + version);

            }
            else if (act == ActionType.GetSupportedCountries)
            {

                string responseString = (string)resp;
                Debug.Log("zoneString :" + responseString);

            }
            else if (act == ActionType.GetFriends)
            {
                string responseString = (string)resp;
                Debug.Log("friendsString :" + responseString);

            }
            else if (act == ActionType.CommitCode)
            {
                RegisterByCode();
                string responseString = (string)resp;
                Debug.Log("commitCodeString :" + responseString);

            }
            else if (act == ActionType.SubmitUserInfo)
            {

                string responseString = (string)resp;
                Debug.Log("submitString :" + responseString);

            }
            else if (act == ActionType.ShowRegisterView)
            {

                string responseString = (string)resp;
                Debug.Log("showRegisterView :" + responseString);

            }
            else if (act == ActionType.ShowContractFriendsView)
            {

                string responseString = (string)resp;
                Debug.Log("showContractFriendsView :" + responseString);
            }
        }

        public void onError(int action, object resp)
        {
            Debug.Log("Error :" + resp);
            Alert.Show("出错了", "验证码错误！");
            //text.text += "\n Error : " + resp;
            print("OnError ******resp" + resp);
        }
    }
}