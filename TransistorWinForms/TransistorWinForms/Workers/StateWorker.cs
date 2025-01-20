using System.Reflection;
using TransistorWinForms.Data;
using TransistorWinForms.Models;

namespace TransistorWinForms.Workers
{
    public class StateWorker
    {
        /// <summary>
        /// Получает состояние рисунка.
        /// Если что-то уже меняли в проге, забираем состояние,
        /// если нет, берем то, что по умолчанию.
        /// </summary>
        public StateModel Get()
        {
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(Constants.STATE_RESOURCE_NAME))
            using (StreamReader reader = new StreamReader(stream))
                return new StateModel(reader.ReadToEnd());
        }
    }
}