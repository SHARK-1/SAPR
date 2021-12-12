using System;
using System.Runtime.InteropServices;
using Kompas6API5;

namespace Kompas
{
    public class KompasConnector
    {
        private KompasObject _kompas;
        /// <summary>
        /// Свойства для хранения подключения к компасу
        /// </summary>
        public KompasObject Kompas
        { 
            get { return _kompas; }
        }
        /// <summary>
        /// Подключение к компасу
        /// </summary>
        public void ConnectToKompas()
        {
            if (!GetActiveKompas(out var kompas))
            {
                if (!CreateKompasInstance(out kompas))
                {
                    throw new ArgumentException(
                        "Не удалось создать новый экземпляр КОМПАС-3D."
                    );
                }
            }
            kompas.Visible = true;
            kompas.ActivateControllerAPI();
            _kompas = kompas;
        }
        /// <summary>
        /// Подключение к существующему экземпляру Компас-3D
        /// </summary>
        /// <param name="kompas">Ссылка на экземпляр КОМПАС-3D.</param>
        /// <returns></returns>
        private bool GetActiveKompas(out KompasObject kompas)
        {
            kompas = null;
            try
            {
                kompas = (KompasObject)Marshal.GetActiveObject(
                    "KOMPAS.Application.5");
                return true;
            }
            catch (COMException)
            {
                return false;
            }
        }

        /// <summary>
        /// Создание нового экземпляра КОМПАС-3D.
        /// </summary>
        /// <param name="kompas">Ссылка на экземпляр КОМПАС-3D.</param>
        /// <returns>Результат успешности создания.</returns>
        private bool CreateKompasInstance(out KompasObject kompas)
        {
            try
            {
                var type = Type.GetTypeFromProgID("KOMPAS.Application.5");
                kompas = (KompasObject)Activator.CreateInstance(type);
                return true;
            }
            catch (COMException)
            {
                kompas = null;
                return false;
            }
        }
    }
}
