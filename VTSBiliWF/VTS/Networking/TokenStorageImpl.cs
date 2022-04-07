
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace VTS.Networking.Impl{
    public class TokenStorageImpl : ITokenStorage
    {
        private static readonly UTF8Encoding ENCODER = new UTF8Encoding();
        private string _fileName = "token.json";
        private string _path = "";

        public TokenStorageImpl(){
            this._path = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "token");
            Directory.CreateDirectory(this._path);
            this._path = Path.Combine(this._path, this._fileName);
            //Application.OpenURL(Application.persistentDataPath);
        }
        public string LoadToken()
        {
            if(File.Exists(this._path)){
                return File.ReadAllText(this._path);
            }
            return null;
        }

        public void SaveToken(string token)
        {
            File.WriteAllText(this._path, token, ENCODER);
        }

        public void DeleteToken()
        {
            if(File.Exists(this._path)){
                File.Delete(this._path);
            }
        }
    }
}
