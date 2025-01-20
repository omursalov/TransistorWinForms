using System.Reflection;
using TransistorWinForms.Models;

namespace TransistorWinForms.Workers
{
    public class StateWorker
    {
        private const string RESOURCE_NAME = "TransistorWinForms.Data.State.ini";

        /// <summary>
        /// Получает состояние рисунка.
        /// Если что-то уже меняли в проге, забираем состояние,
        /// если нет, берем то, что по умолчанию.
        /// </summary>
        public StateModel Get()
        {
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(RESOURCE_NAME))
            using (StreamReader reader = new StreamReader(stream))
                return new StateModel(reader.ReadToEnd());
        }
    }
}