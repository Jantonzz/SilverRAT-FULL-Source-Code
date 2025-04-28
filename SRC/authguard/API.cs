using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Net;
using System.Net.Security;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;

namespace authguard;

public class API
{
    [DataContract]
    private class response_structure
    {
        [DataMember]
        public bool success { get; set; }

        [DataMember]
        public string response { get; set; }

        [DataMember]
        public string message { get; set; }

        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public user_data_structure user_data { get; set; }
    }

    [DataContract]
    private class user_data_structure
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string username { get; set; }

        [DataMember]
        public string email { get; set; }

        [DataMember]
        public string expires { get; set; }

        [DataMember]
        public string level { get; set; }

        [DataMember]
        public string ip { get; set; }

        [DataMember]
        public string hwid { get; set; }

        [DataMember]
        public string lastlogin { get; set; }

        [DataMember]
        public string totalclients { get; set; }
    }

    public class user_data_class
    {
        public int id { get; set; }

        public string username { get; set; }

        public string email { get; set; }

        public string ip { get; set; }

        public string hwid { get; set; }

        public string lastlogin { get; set; }

        public string expires { get; set; }

        public string level { get; set; }

        public string totalclients { get; set; }
    }

    public string program_version;

    public string program_key;

    public string api_enc_key;

    public string session_iv;

    private bool is_initialized;

    private bool show_messages;

    private bool logged_in;

    public user_data_class user_data = new user_data_class();

    private string api_endpoint = "https://authguard.net/api/v1/";

    public static string user_agent = "AuthGuard Agent";

    private json_wrapper response_decoder = new json_wrapper(new response_structure());

    public API(string version, string program_key, string api_enc_key, bool show_messages = true)
    {
        program_version = version;
        this.program_key = program_key;
        this.api_enc_key = api_enc_key;
        this.show_messages = show_messages;
    }

    public void init()
    {
        try
        {
            session_iv = encryption.iv_key();
            string text = encryption.sha256(session_iv);
            NameValueCollection post_data = new NameValueCollection
            {
                ["version"] = encryption.encrypt(program_version, api_enc_key, text),
                ["program_key"] = encryption.saltStr(program_key),
                ["timestamp"] = encryption.saltStr(DateTime.Now.ToString()),
                ["init_iv"] = encryption.saltStr(text)
            };
            string text2 = do_request("init", post_data);
            errCheck(text2);
            security.End();
            text2 = encryption.decrypt(text2, api_enc_key, text);
            response_structure response_structure = response_decoder.string_to_generic<response_structure>(text2);
            if (!response_structure.success)
            {
                MessageBox.Show(response_structure.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            string[] array = response_structure.response.Split('|');
            if (security.MaliciousCheck(array[1]))
            {
                MessageBox.Show("Possible malicious activity detected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Process.GetCurrentProcess().Kill();
            }
            string text3 = array[0];
            string text4 = text3;
            if (!(text4 == "started_program"))
            {
                if (!(text4 == "update_available"))
                {
                    MessageBox.Show("Something went wrong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    Process.GetCurrentProcess().Kill();
                    return;
                }
                if (array[2].Length > 0)
                {
                    Process.Start(array[2]);
                }
                else
                {
                    MessageBox.Show("Please add a valid download link!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                Process.GetCurrentProcess().Kill();
                return;
            }
            if (array[3] == "0" && array[4].Length > 0)
            {
                if (array[4] != security.Signature(Process.GetCurrentProcess().MainModule.FileName))
                {
                    MessageBox.Show("File has been tampered with, couldn't verify integrity!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    Process.GetCurrentProcess().Kill();
                }
            }
            else
            {
                appSettings.devmode = true;
            }
            if (array[5] == "1")
            {
                appSettings.freemode = true;
            }
            is_initialized = true;
            session_iv += array[2];
        }
        catch (CryptographicException)
        {
            MessageBox.Show("Invalid Encryption key!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            Process.GetCurrentProcess().Kill();
        }
    }

    public bool login(string username, string password, string hwid = null)
    {
        if (hwid == null)
        {
            hwid = security.HWID();
        }
        if (!is_initialized)
        {
            MessageBox.Show("Please initialize your application first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            return false;
        }
        NameValueCollection post_data = new NameValueCollection
        {
            ["username"] = encryption.encrypt(username, api_enc_key, session_iv),
            ["password"] = encryption.encrypt(password, api_enc_key, session_iv),
            ["hwid"] = encryption.encrypt(hwid, api_enc_key, session_iv),
            ["program_key"] = encryption.saltStr(program_key),
            ["timestamp"] = encryption.saltStr(DateTime.Now.ToString()),
            ["sessid"] = encryption.saltStr(session_iv)
        };
        string text = do_request("login", post_data);
        errCheck(text);
        security.End();
        text = encryption.decrypt(text, api_enc_key, session_iv);
        response_structure response_structure = response_decoder.string_to_generic<response_structure>(text);
        logged_in = response_structure.success;
        if (!logged_in && show_messages)
        {
            MessageBox.Show(response_structure.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        else if (logged_in)
        {
            load_user_data(response_structure.user_data);
        }
        return logged_in;
    }

    public bool register(string username, string email, string password, string token, string hwid = null)
    {
        if (hwid == null)
        {
            hwid = security.HWID();
        }
        if (!is_initialized)
        {
            MessageBox.Show("Please initialize your application first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            return false;
        }
        NameValueCollection post_data = new NameValueCollection
        {
            ["username"] = encryption.encrypt(username, api_enc_key, session_iv),
            ["email"] = encryption.encrypt(email, api_enc_key, session_iv),
            ["password"] = encryption.encrypt(password, api_enc_key, session_iv),
            ["token"] = encryption.encrypt(token, api_enc_key, session_iv),
            ["hwid"] = encryption.encrypt(hwid, api_enc_key, session_iv),
            ["program_key"] = encryption.saltStr(program_key),
            ["timestamp"] = encryption.saltStr(DateTime.Now.ToString()),
            ["sessid"] = encryption.saltStr(session_iv)
        };
        string text = do_request("register", post_data);
        errCheck(text);
        security.End();
        text = encryption.decrypt(text, api_enc_key, session_iv);
        response_structure response_structure = response_decoder.string_to_generic<response_structure>(text);
        if (!response_structure.success && show_messages)
        {
            MessageBox.Show(response_structure.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        return response_structure.success;
    }

    public bool extendSubscription(string username, string token)
    {
        if (!is_initialized)
        {
            MessageBox.Show("Please initialize your application first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            return false;
        }
        NameValueCollection post_data = new NameValueCollection
        {
            ["username"] = encryption.encrypt(username, api_enc_key, session_iv),
            ["token"] = encryption.encrypt(token, api_enc_key, session_iv),
            ["program_key"] = encryption.saltStr(program_key),
            ["timestamp"] = encryption.saltStr(DateTime.Now.ToString()),
            ["sessid"] = encryption.saltStr(session_iv)
        };
        string text = do_request("extend", post_data);
        errCheck(text);
        security.End();
        text = encryption.decrypt(text, api_enc_key, session_iv);
        response_structure response_structure = response_decoder.string_to_generic<response_structure>(text);
        if (!response_structure.success && show_messages)
        {
            MessageBox.Show(response_structure.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        return response_structure.success;
    }

    public string variable(string name)
    {
        if (!is_initialized)
        {
            MessageBox.Show("The program wasn't initialized!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            return "not_initialized";
        }
        if (!logged_in)
        {
            MessageBox.Show("You can only grab server sided variables after being logged in!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            return "not_logged_in";
        }
        NameValueCollection post_data = new NameValueCollection
        {
            ["var_name"] = encryption.encrypt(name, api_enc_key, session_iv),
            ["program_key"] = encryption.saltStr(program_key),
            ["timestamp"] = encryption.saltStr(DateTime.Now.ToString()),
            ["sessid"] = encryption.saltStr(session_iv)
        };
        string text = do_request("var", post_data);
        errCheck(text);
        security.End();
        text = encryption.decrypt(text, api_enc_key, session_iv);
        response_structure response_structure = response_decoder.string_to_generic<response_structure>(text);
        if (!response_structure.success && show_messages)
        {
            MessageBox.Show(response_structure.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        return response_structure.response;
    }

    private string do_request(string type, NameValueCollection post_data)
    {
        using WebClient webClient = new WebClient();
        webClient.Headers["User-Agent"] = user_agent;
        security.Start();
        byte[] bytes = webClient.UploadValues(api_endpoint + "?type=" + type, post_data);
        ServicePointManager.ServerCertificateValidationCallback = (RemoteCertificateValidationCallback)Delegate.Combine(ServicePointManager.ServerCertificateValidationCallback, (RemoteCertificateValidationCallback)((object send, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) => true));
        return Encoding.Default.GetString(bytes);
    }

    public void errCheck(string data)
    {
        if (security.breached)
        {
            MessageBox.Show("Possible malicious activity detected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            Process.GetCurrentProcess().Kill();
        }
        switch (data)
        {
            case "program_banned":
                MessageBox.Show("This application has been banned for violating the TOS" + Environment.NewLine + "Contact us at support@authguard.net", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Process.GetCurrentProcess().Kill();
                break;
            case "program_disabled":
                MessageBox.Show("Looks like this application is disabled, please try again later!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Process.GetCurrentProcess().Kill();
                break;
            case "program_doesnt_exist":
                MessageBox.Show("The program key you tried to use doesn't exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Process.GetCurrentProcess().Kill();
                break;
        }
    }

    private void load_user_data(user_data_structure data)
    {
        user_data.id = data.id;
        user_data.username = data.username;
        user_data.email = data.email;
        user_data.ip = data.ip;
        user_data.hwid = data.hwid;
        user_data.lastlogin = data.lastlogin;
        user_data.expires = data.expires;
        user_data.level = data.level;
        user_data.totalclients = data.totalclients;
    }
}
