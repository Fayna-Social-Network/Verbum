namespace Fayna.AdminPanel
{
    internal class Settings
    {
        private string path = Path.Combine(Directory.GetCurrentDirectory(), "DbSettings.dat");

        public void SaveDbConnection(string host, string port, string database, string username, string password) 
        {
         
            string[] Connection = { host, port, database, username, password };

            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                foreach (string item in Connection) 
                {
                    writer.Write(item);
                }
            }    

        }

        public List<string> GetDbSettings() 
        {
            List<string> DbSettings = new List<string>();

            try
            {
                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    while (reader.PeekChar() > -1)
                    {
                        string item = reader.ReadString();
                        DbSettings.Add(item);
                    }
                }

            }
            catch 
            {
                
            }

            return DbSettings;
        } 
    }
}
