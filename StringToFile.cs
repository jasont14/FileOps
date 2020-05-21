using System;
using System.IO;

namespace Thatcher
{
    class FileOps
    {
        public FileOps()
        {

        }

        public bool WriteStringToFile(string result, string writeLocation)
        {
            bool res = false;

            StringReader rdr = null;

            try
            {
                rdr = new StringReader(result);

                string[] lines = rdr.ReadToEnd().Split("\r\n".ToCharArray());

                using (StreamWriter sw = new StreamWriter(writeLocation))
                {
                    foreach (string ln in lines)
                    {
                        sw.Write(ln + "\n");
                    }
                }

                res = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Could Not Write to File: " + ex.Message);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Dispose();
                }
            }

            return res;
        }
    }
}
