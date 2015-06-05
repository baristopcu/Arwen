
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace ARWEN.DTO.Class
{
    public enum Islem
    {
        Ekle,
        Incele,
        Sil,
        Duzenle
    }

    public enum KullaniciTipi
    {
        Yonetici,
        Kullanici
    }


    public class Jarvis
    {
        public SqlConnection NtpDbConnection;
        public SqlCommand NtpCommand;
        public SqlDataAdapter NtpDataAdapter;

        public string GetConnStr(string DatabaseName)
        {
            string connStr = string.Empty;
            connStr = System.Configuration.ConfigurationManager.ConnectionStrings[DatabaseName].ConnectionString;
            return connStr;
        }

        public SqlCommand Command
        {
            get { return NtpCommand; }
        }

        public void ConnectToDb(string connStr)
        {
            NtpDbConnection = new SqlConnection(connStr);
            NtpCommand = new SqlCommand();
            NtpCommand.Connection = NtpDbConnection;
            NtpDataAdapter = new SqlDataAdapter(NtpCommand);
            NtpDbConnection.Open();
        }

        public int InsertData(string cmdStr)
        {
            NtpCommand.CommandText = cmdStr;
            return NtpCommand.ExecuteNonQuery();
        }

        public int InsertData(string cmdStr, List<object> valueArr)
        {
            NtpCommand.CommandText = cmdStr;
            List<int> indexOfAt = new List<int>();
            List<int> indexOfComma = new List<int>();

            int parameterCount = GetParameterArr(cmdStr).Length;

            string[] parameterArr = GetParameterArr(cmdStr);
            NtpCommand.Parameters.Clear();
            for (int i = 0; i < parameterCount; i++)
            {
                NtpCommand.Parameters.AddWithValue(parameterArr[i], valueArr[i]);
            }
            return NtpCommand.ExecuteNonQuery();
        }

        public int UpdateData(string cmdStr)
        {
            NtpCommand.CommandText = cmdStr;
            return NtpCommand.ExecuteNonQuery();
        }

        public int DeleteData(string cmdStr)
        {
            NtpCommand.CommandText = cmdStr;
            return NtpCommand.ExecuteNonQuery();
        }

        public DataTable GetData(string cmdStr)
        {
            NtpCommand.CommandText = cmdStr;
            var tbl = new DataTable();
            NtpDataAdapter.Fill(tbl);
            return tbl;
        }
        public DataTable GetDataForReport(string cmdStr, DataSet ds , string dt)
        {
            NtpCommand.CommandText = cmdStr;
            var tbl = new DataTable();
            NtpDataAdapter.Fill(ds , dt);
            return tbl;
        }
        public DataRow GetDataRow(string sql)
        {
            NtpCommand.CommandText = sql;
            var tblVeri = new DataTable();
            NtpDataAdapter.Fill(tblVeri);
            if (tblVeri.Rows.Count > 0)
            {
                return tblVeri.Rows[0];
            }
            else
            {
                return null;
            }
        }

        public object GetScalarValue(string sql)
        {
            NtpCommand.CommandText = sql;
            return NtpCommand.ExecuteScalar();
        }

        public void FillComboBox(string cmdStr, ComboBox cmb, string DisplayMember, string ValueMember)
        {
            cmb.DisplayMember = DisplayMember;
            cmb.ValueMember = ValueMember;
            cmb.DataSource = GetData(cmdStr);
        }

        public void FillListBox(string cmdStr, ListBox lst, string displayMember, string valueMember)
        {
            lst.DisplayMember = displayMember;
            lst.ValueMember = valueMember;
            lst.DataSource = GetData(cmdStr);
        }

        private string[] GetParameterArr(string cmdStr)
        {
            List<int> indexOfFP = new List<int>();
            List<int> indexOfLP = new List<int>();

            int count = 0;
            foreach (char c in cmdStr)
            {
                if (c == '(')
                {
                    indexOfFP.Add(count);
                }
                else if (c == ')')
                {
                    indexOfLP.Add(count);
                }
                count++;
            }
            string parametersTemp = cmdStr.Substring(indexOfFP[1] + 1, indexOfLP[1] - indexOfFP[1] - 1);
            string[] parameterArr = parametersTemp.Split(',');
            return parameterArr;
        }

        public string ConvertToMD5(string Txt)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bt = Encoding.UTF8.GetBytes(Txt);
            bt = md5.ComputeHash(bt);

            StringBuilder sb = new StringBuilder();
            foreach (byte item in bt)
            {
                sb.Append(item.ToString("x2").ToLower());
            }
            return sb.ToString();
        }

        private const string InitVector = "T=A4rAzu94ez-dra";
        private const int KeySize = 256;
        private const int PasswordIterations = 1000;
        private const string SaltValue = "d=?ustAF=UstenAr3B@pRu8=ner5sW&h59_Xe9P2za-eFr2fa&ePHE@ras!a+uc@";

        public string Decrypt(string encryptedText, string passPhrase)
        {
            byte[] encryptedTextBytes = Convert.FromBase64String(encryptedText);
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(InitVector);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(passPhrase);
            string plainText = null;
            byte[] saltValueBytes = Encoding.UTF8.GetBytes(SaltValue);
            Rfc2898DeriveBytes password = new Rfc2898DeriveBytes(passwordBytes, saltValueBytes, PasswordIterations);
            byte[] keyBytes = password.GetBytes(KeySize / 8);
            RijndaelManaged rijndaelManaged = new RijndaelManaged { Mode = CipherMode.CBC };

            try
            {
                using (ICryptoTransform decryptor = rijndaelManaged.CreateDecryptor(keyBytes, initVectorBytes))
                {
                    using (MemoryStream memoryStream = new MemoryStream(encryptedTextBytes))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                        {
                            byte[] plainTextBytes = new byte[encryptedTextBytes.Length];
                            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                            plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                        }
                    }
                }
            }
            catch { }
            return plainText;
        }

        public void cozunurlukAyarla(DevExpress.XtraEditors.XtraForm frm)
        {
            int SimdikiWidth = 1920;
            int SimdikiHeight = 1080;
            Rectangle ClientCozunurluk = new Rectangle();
            ClientCozunurluk = Screen.GetBounds(ClientCozunurluk);
            float OranWidth = ((float)ClientCozunurluk.Width / (float)SimdikiWidth);
            float OranHeight = ((float)ClientCozunurluk.Height / (float)SimdikiHeight);
            frm.Scale(OranWidth, OranHeight);
        }

        public string Encrypt(string plainText, string passPhrase)
        {
            string encryptedText;
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(InitVector);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(passPhrase);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] saltValueBytes = Encoding.UTF8.GetBytes(SaltValue);
            Rfc2898DeriveBytes password = new Rfc2898DeriveBytes(passwordBytes, saltValueBytes, PasswordIterations);
            byte[] keyBytes = password.GetBytes(KeySize / 8);
            RijndaelManaged rijndaelManaged = new RijndaelManaged { Mode = CipherMode.CBC };
            using (ICryptoTransform encryptor = rijndaelManaged.CreateEncryptor(keyBytes, initVectorBytes))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                        cryptoStream.FlushFinalBlock();
                        byte[] cipherTextBytes = memoryStream.ToArray();
                        encryptedText = Convert.ToBase64String(cipherTextBytes);
                    }
                }
            }
            return encryptedText;
        }
    }
}

