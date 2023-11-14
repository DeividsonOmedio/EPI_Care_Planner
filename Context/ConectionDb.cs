using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epi_Care_Planner.Context
{
    public static class ConectionDb
    {
        public static string DevolverRota(string nomeBaseDados)
        {
            string rotaBaseDados = string.Empty;

            if (DeviceInfo.Platform == DevicePlatform.Android)
            {
                rotaBaseDados = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                rotaBaseDados = Path.Combine(rotaBaseDados, nomeBaseDados);
            }
            else if (DeviceInfo.Platform == DevicePlatform.iOS)
            {
                rotaBaseDados = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                rotaBaseDados = Path.Combine(rotaBaseDados, "..", "Library", nomeBaseDados);
            }
            else
            {

            }
            return rotaBaseDados;
        }
    }
}